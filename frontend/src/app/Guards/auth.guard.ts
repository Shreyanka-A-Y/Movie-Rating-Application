import { inject } from "@angular/core"
import { AuthService } from "../services/auth-service"
import { CanActivateFn, Router } from "@angular/router"
import { catchError, map, of } from "rxjs"

export const authGuard: CanActivateFn = () =>{
    const authService = inject(AuthService)
    const router = inject(Router)

    return authService.getCurrentUser().pipe(
        map(() => true),
        catchError(() => {
            return of(router.createUrlTree(['/login']))
        })
    )
}