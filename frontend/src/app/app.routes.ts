import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { HomeComponent } from './home/home';
import { MoviesComponent } from './movies/movies';
import { AddMovieComponent } from './add-movie/add-movie';
import { RatingPageComponent } from './rating-page/rating-page';

export const routes: Routes = [
    {
        path: "",
        component: LoginComponent
    },
    {
        path:"home",
        component: HomeComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "logout",
        component: LoginComponent
    },
    {
        path: "movies",
        component: MoviesComponent
    },
    {
        path: "add",
        component: AddMovieComponent
    },
    {
        path: "rating-page/:movieId",
        component: RatingPageComponent
    }
];
