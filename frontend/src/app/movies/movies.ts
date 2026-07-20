import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { MovieService } from '../services/movie-service';
import { Router } from '@angular/router';
import { debounceTime, Subject } from 'rxjs';
import { IMovie } from '../models/IMovies';

@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [],
  templateUrl: './movies.html',
  styleUrl: './movies.css',
})
export class MoviesComponent implements OnInit {

  Math = Math;

  router = inject(Router)
  movieService = inject(MovieService)

  private searchSubject = new Subject<string>();
  // filteredMovieList = signal<IMovie[]>([]);

  moviesList = this.movieService.moviesList

  searchText = signal('');
  selectedRating = signal(0);
  sortOrder = signal<'Asc' | 'Desc'>('Asc')


  ngOnInit(): void {
     this.GetMovie();

      this.searchSubject.pipe(debounceTime(500)).subscribe(value => {
        if(!value){
          this.movieService.moviesList()
          return
        }
        this.movieService.moviesList().filter((movie:IMovie) =>{
              return movie.title.toLowerCase().includes(value.toLocaleLowerCase())
       })
      })
   }


  GetMovie(){
    this.movieService.movies().subscribe({
      next : (res) =>{
        this.moviesList.set(res);
      },
      error: (err) =>{
        console.log(err)
      }
    })
  }

  RateMovie(movieId:number, ratingStars:number){
    this.movieService.rateMovie(movieId, ratingStars).subscribe({
      next:()=>{
        this.GetMovie();
      },
      error: (err) => {
        console.log(err)
      }
    })
  }

  deleteMovie(movieId:number){
    this.movieService.deleteMovie(movieId).subscribe({
      next:()=>{
        this.movieService.moviesList.update((movies : IMovie[]) => {
          return movies.filter((movie : IMovie) => movie.id !== movieId)
        })
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  filteredMovieList = computed(() => {

    let movies = [...this.moviesList()]

    const searchWord = this.searchText().trim().toLowerCase();
    const rating = this.selectedRating()
    const sortBy = this.sortOrder()

    if(searchWord){
      movies = movies.filter(movie => {
        return movie.title.toLowerCase().includes(searchWord)
      })
    }

    if(rating >= 0){
      movies = movies.filter(movie => movie.averageRating >= rating)
    }

    if(sortBy){
      movies.sort((a,b) => {
        return sortBy === 'Asc' ? a.releaseYear - b.releaseYear : b.releaseYear - a.releaseYear
      })
    }

    return movies
  })

  searchFilter(event : Event){
    const searchWord = (event.target as HTMLInputElement).value
    this.searchText.set(searchWord)
  }

  filterRating(event : Event){
    const rating = Number((event.target as HTMLSelectElement).value);
    this.selectedRating.set(rating)
  }

  sortDisplay: boolean = true;
  toggle(){
    this.sortDisplay = !this.sortDisplay
    this.sortByYear (this.sortDisplay ? 'Asc' : 'Desc')
  }

  sortByYear(sortBy : 'Asc'|'Desc'){
    this.sortOrder.set(sortBy)    
  }

  ratingDetailPage(movieId : number){
    this.router.navigate(['/rating-page', movieId])
  }
}