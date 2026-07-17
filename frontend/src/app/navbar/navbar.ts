import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService } from '../services/auth-service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class NavbarComponent implements OnInit {

  isLoggedIn = signal(false);

  constructor(private authService : AuthService){}

  ngOnInit(): void {
    this.authService.isLoginSuccessful.subscribe(val =>{
      this.isLoggedIn.set(val);
    })
  }

  logout(){
    this.isLoggedIn.set(false)
  }


}
