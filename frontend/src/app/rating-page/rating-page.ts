import { Component, inject, OnInit, signal } from '@angular/core';
import { MovieService } from '../services/movie-service';
import { IRating } from '../models/IRating';
import { ActivatedRoute, Router } from '@angular/router';
import { IMovie } from '../models/IMovies';

@Component({
  selector: 'app-rating-page',
  imports: [],
  templateUrl: './rating-page.html',
  styleUrl: './rating-page.css',
})
export class RatingPageComponent implements OnInit{

  movieService = inject(MovieService)
  route = inject(ActivatedRoute)
  router = inject(Router)

  rating = signal<IRating[]>([]);
  movie = signal<IMovie | null>(null);

  Math = Math


  ngOnInit(): void {
    const movieId = this.route.snapshot.paramMap.get('movieId');

    if(movieId){
      this.movieDetail(+movieId)
      this.ratingDetails(+movieId)
      
    }
  }

  ratingDetails(movieId : number){
    this.movieService.ratingDetail(movieId).subscribe({
      next : (res) =>{
        this.rating.set(res)
      },
      error : (err) => {
        console.log(err)
      }
    })
  }

  movieDetail(movieId : number){
    this.movieService.getMovieById(movieId).subscribe({
      next:(res) =>{
        this.movie.set(res)
      },
      error: (err) => {
        console.log(err)
      }
    })
  }

  Back(){
    this.router.navigate(['/movies'])
  }
}
