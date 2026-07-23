import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn : "root"
})
export class AuthService {

    private http = inject(HttpClient);

    private apiUrl = 'https://localhost:7028/api/auth';

    private isLoginSuccessful = new BehaviorSubject<boolean>(false);
    isLoginSuccessful$ = this.isLoginSuccessful.asObservable();

    setLoginState(value: boolean){
        this.isLoginSuccessful.next(value)
    }

    login(username: string, password: string) 
    {
        return this.http.post(
            `${this.apiUrl}/login`,
            {
                username: username,
                password: password
            },
            {
                withCredentials: true
            }
        );
    }

    logout(){
        return this.http.post(
            `${this.apiUrl}/logout`,{},
            {
                withCredentials : true
            }
        );
    }

    getCurrentUser(){
        return this.http.get(
            `${this.apiUrl}/currentUser`,{
                withCredentials: true
            }
        )
    }



}
