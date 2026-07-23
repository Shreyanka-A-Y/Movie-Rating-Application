import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { MovieService } from '../services/movie-service';
import { Router } from '@angular/router';
import { IMovie } from '../models/IMovies';
import { ToastrService } from 'ngx-toastr';

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
  toastr = inject(ToastrService)

  // private searchSubject = new Subject<string>();
  // filteredMovieList = signal<IMovie[]>([]);

  moviesList = this.movieService.moviesList

  searchText = signal(localStorage.getItem('searchWord')??'');
  selectedRating = signal(parseInt(localStorage.getItem('rating') ?? '0'));
  sortOrder = signal<'Asc' | 'Desc'>('Asc')


  ngOnInit(): void {
      this.GetMovie();

      // this.searchSubject.pipe(debounceTime(5000)).subscribe(value => {
      //   if(!value){
      //     this.movieService.moviesList()
      //     return
      //   }
      // })
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
        this.toastr.warning("Failed to delete", 'Unauthorized')
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

    if(searchWord === ''){
      return movies
    }

    return movies
  })

  searchFilter(event : Event){
    const searchWord = (event.target as HTMLInputElement).value
    this.searchText.set(searchWord)
    localStorage.setItem('searchWord', searchWord)
  }

  filterRating(event : Event){
    const rating = Number((event.target as HTMLSelectElement).value);
    this.selectedRating.set(rating)
    localStorage.setItem('rating', rating.toString())
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