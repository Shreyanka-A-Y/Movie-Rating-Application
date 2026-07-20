import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { IAddMovie } from '../models/IAddMovie';
import { MovieService } from '../services/movie-service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-movie',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-movie.html',
  styleUrl: './add-movie.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddMovieComponent {


  movieService = inject(MovieService);
  router = inject(Router)

  movie: IAddMovie = {
    title: '',
    genre: '',
    description: '',
    releaseYear: new Date().getFullYear(),
    posterUrl: ''
  };

  addMovie(){
    this.movieService.addMovie(this.movie).subscribe({
      next : () =>{
        this.router.navigate(['/movies']).then(() => {
          setTimeout(() => {
            window.scrollTo({
              top: document.body.scrollHeight,
              behavior: 'smooth'
            });
          }, 100);
        })
      },
      error : (err) =>{
        console.log(err)
      }
    })
  }
}
