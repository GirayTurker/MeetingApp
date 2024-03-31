import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error:HttpErrorResponse) =>{
        if(error)
        {
          switch(error.status)
          {
            case 400:
              if(error.error.errors)
              {
                //there are 2 types of 400 error. array is created for store types of 400 array
                const modelStateError=[];
                for(const key in error.error.errors)
                {
                  if(error.error.errors[key])
                  {
                    modelStateError.push(error.error.errors[key])
                  }
                }
                //flat is flattern 2 array to single arrray
                this.toastr.error(modelStateError.flat().toString());
                throw modelStateError;
              }
              else
              {
                this.toastr.error(error.error.statusText, error.status.toString())
              }
              
              break;

              case 401:
                this.toastr.error('Unauthorised', error.status.toString());
                break;
              case 404:
                this.toastr.error(error.error.statusText, error.status.toString())
                this.router.navigateByUrl('/not-found');
                break;
              case 500:
                this.toastr.error(error.error.statusText, error.status.toString())
                const navigationExtras:NavigationExtras = {state:{error:error.error}} 
                this.router.navigateByUrl('/server-error', navigationExtras); 
                break;
              default:
                this.toastr.error('Unexpected Error, Check console');
                console.log(error); 
                break; 
          }
        }
        throw error;
      })
      
    )
  }
}