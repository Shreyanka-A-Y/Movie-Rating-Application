import { Component, inject, OnInit, signal } from '@angular/core';
import { MovieService } from '../services/movie-service';
import { Router } from '@angular/router';

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

  moviesList : any;
  constructor(private movieServie : MovieService){
    this.moviesList = this.movieServie.moviesList
  }

   ngOnInit(): void {
     this.GetMovie();
   }


  GetMovie(){
    this.movieServie.movies().subscribe({
      next : (res) =>{
        this.moviesList.set(res);
      },
      error: (err) =>{
        console.log(err)
      }
    })
  }

  RateMovie(movieId:number, ratingStars:number){
    this.movieServie.rateMovie(movieId, ratingStars).subscribe({
      next:()=>{
        this.GetMovie();
      },
      error: (err) => {
        console.log(err)
      }
    })
  }

  deleteMovie(movieId:number){
    this.movieServie.deleteMovie(movieId).subscribe({
      next:(res)=>{
        console.log("Delete successful", res);
        this.GetMovie();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  searchMovie(event : Event){
    const searchWord = (event.target as HTMLInputElement).value

    this.movieServie.searchMovie(searchWord).subscribe({
      next:(res)=>{
        this.movieServie.moviesList.set(res)
      },
      error: (err) => {
        console.log(err)
      }
    })
  }

  filterRating(event : Event){
    const rating = Number((event.target as HTMLSelectElement).value);
    this.movieServie.filterByRating(rating).subscribe({
      next:(res) => {
        this.movieServie.moviesList.set(res)
      }
    })
  }

  sortDisplay: boolean = true;
  toggle(){
    this.sortDisplay = !this.sortDisplay
    this.sortByYear (this.sortDisplay ? 'Asc' : 'Desc')
  }

  sortByYear(sortBy : string){
    this.movieServie.SortByYear(sortBy).subscribe({
      next:(res) => {
        this.movieServie.moviesList.set(res)
      }
    })
  }

  ratingDetailPage(movieId : number){
    this.router.navigate(['/rating-page', movieId])
  }
}