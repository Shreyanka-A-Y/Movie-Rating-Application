import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth-service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class LoginComponent {

  Credential={
    username : '',
    password : ''
  }
  currentUser : any;

  private router = inject(Router)
  private toastr = inject(ToastrService)
  constructor(private authService : AuthService){}

  login(){
    this.authService.login(this.Credential.username, this.Credential.password).subscribe({
      next: (respose : any) => {

        console.log(respose.message)       

        this.authService.getCurrentUser().subscribe({
          next:(user) =>{
            this.currentUser = user;
            this.authService.setLoginState(true);
            this.router.navigate(['/movies'])
            this.toastr.success(respose.message, 'Success')
          }
        })

      },
      error: (error) =>{
        console.log(error);
      }
    })
  }
}
