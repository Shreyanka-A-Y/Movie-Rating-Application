import { Component, inject, OnInit, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../services/auth-service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class NavbarComponent implements OnInit {

  isLoggedIn = signal(false);
  router = inject(Router)
  toastr = inject(ToastrService)


  constructor(private authService : AuthService){}

  ngOnInit(): void {
    this.authService.isLoginSuccessful$.subscribe(val =>{
      this.isLoggedIn.set(val);
    })
  }

  logout(){
    this.authService.logout().subscribe({
      next : ()=>{
      this.authService.setLoginState(false);
      this.router.navigate(['/login'])
      this.toastr.success("Logout Sucessfully", 'Success')
      this.isLoggedIn.set(false);
      },
      error: (err) => {
        console.log(err)
      }
    })
  }



}
