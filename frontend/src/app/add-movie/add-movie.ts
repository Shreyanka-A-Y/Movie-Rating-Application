import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { IAddMovie } from '../models/IAddMovie';
import { MovieService } from '../services/movie-service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-movie',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './add-movie.html',
  styleUrl: './add-movie.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddMovieComponent {


  movieService = inject(MovieService);
  router = inject(Router)

  movieForm = new FormGroup({
    title: new FormControl('',[Validators.required]),
    genre: new FormControl(''),
    description: new FormControl(''),
    releaseYear: new FormControl<Number>(new Date().getFullYear()),
    posterUrl: new FormControl('')
  });

  addMovie(){
    const movie = this.movieForm.value as IAddMovie

    this.movieService.addMovie(movie).subscribe({
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
