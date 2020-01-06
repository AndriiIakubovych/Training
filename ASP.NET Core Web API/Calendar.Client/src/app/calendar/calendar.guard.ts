import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot } from "@angular/router";
import { HttpService } from "../http.service";
import { Observable, of } from "rxjs";
import { map, catchError } from "rxjs/operators";

@Injectable()
export class CalendarGuard implements CanActivate
{
    constructor(private httpService: HttpService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | boolean
    {
        if (this.httpService.isAuthorized())
        {
            return this.httpService.getUserData().pipe(map(result =>
            {
                if (result != null)
                {
                    route.queryParams = result;
                    return true;
                }
                else
                    return this.forbidAccess();
            }),
            catchError(() =>
            {
                return of(this.forbidAccess());
            }));
        }
        else
            return this.forbidAccess();
    }

    forbidAccess(): boolean
    {
        this.router.navigate(["/login"]);
        return false;
    }
}