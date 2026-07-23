import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { HomeComponent } from './home/home';
import { MoviesComponent } from './movies/movies';
import { AddMovieComponent } from './add-movie/add-movie';
import { RatingPageComponent } from './rating-page/rating-page';
import { authGuard } from './Guards/auth.guard';

export const routes: Routes = [
    {
        path: "",
        component: MoviesComponent,
        canActivate: [authGuard],
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
        component: MoviesComponent,
        canActivate: [authGuard],
    },
    {
        path: "add",
        component: AddMovieComponent,
        canActivate: [authGuard],

    },
    {
        path: "rating-page/:movieId",
        component: RatingPageComponent,
        canActivate: [authGuard],
    }
];
