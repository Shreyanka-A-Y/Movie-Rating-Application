import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import {Observable } from 'rxjs';
import { IMovie } from '../models/IMovies';
import { IAddMovie } from '../models/IAddMovie';
import { IRating } from '../models/IRating';

@Injectable({
    providedIn : "root"
})
export class MovieService {

    private http = inject(HttpClient);

    private apiUrl = 'https://localhost:7028/api';

    moviesList = signal<IMovie[]>([]);

    movies() : Observable<IMovie[]>
    {
        return this.http.get<IMovie[]>(
            `${this.apiUrl}/movie`,{
                withCredentials: true
            }
        );
    }

    rateMovie(movieId: number, ratingStars:number){
        return this.http.post(
            `${this.apiUrl}/Rating/AddRating`,{
                MovieId : movieId,
                RatingStars : ratingStars
            },{
                withCredentials: true
            }
        )
    }

    deleteMovie(movieId:number){
        return this.http.delete(
            `${this.apiUrl}/Movie/Delete`,{
                params : {
                    id : movieId
                },
                withCredentials: true
            }
        )
    }

    addMovie(movie : IAddMovie){ 
        console.log(movie)       
        return this.http.post(
            `${this.apiUrl}/Movie/Create`,
                movie,
            {
                withCredentials: true
            }
        )
    }

    searchMovie(searchWord : string){
        return this.http.get<IMovie[]>(
            `${this.apiUrl}/Movie/Search`,
            {
                 params: { searchWord },
                withCredentials: true
            }
        )
    }

    filterByRating(rating : number){
        return this.http.get<IMovie[]>(
            `${this.apiUrl}/Movie/Filter`,
            {
                 params: { rating },
                withCredentials: true
            }
        )
    }

    SortByYear(sortBy : string){
        return this.http.get<IMovie[]>(
            `${this.apiUrl}/Movie/Sort`,{
                params : {sortBy},
                withCredentials: true
            }
        )
    }

    ratingDetail(movieId : number){
        return this.http.get<IRating[]>(
            `${this.apiUrl}/Rating/RatingDetail`,{
                params: {movieId},
                withCredentials: true
            }
        )
    }

    getMovieById(movieId : number){
        return this.http.get<IMovie>(
            `${this.apiUrl}/Movie/MovieById`,{
                params: {id :movieId},
                withCredentials: true
            }
        )
    }
    

}
