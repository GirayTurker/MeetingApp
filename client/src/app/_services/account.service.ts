import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import {IUser} from '../_models/user'
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
//Responsible for HTTP Request from client to server (API)
export class AccountService {
  
  
  baseUrl = environment.apiUrl;
  
  private currentUserSource = new BehaviorSubject<IUser | null>(null);
  currentIUser$ = this.currentUserSource.asObservable();
  
  constructor(private http: HttpClient) {}
  
  login (model:any){
    return this.http.post<IUser>(this.baseUrl+'account/login', model).pipe(
      map((response: IUser) =>{
        const user = response;
        if(user)
        {
          sessionStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    ) 
  }
  

  register(model:any)
  {
    return this.http.post<IUser>(this.baseUrl+"account/register", model).pipe(
      map((response:IUser) =>
      {
        const user = response;
        if(user)
        {
          sessionStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);  
        }
        //return user;
      })
    )  
  }

  setCurrentUser(user:IUser)
  {
    this.currentUserSource.next(user);
  }

  logout()
  {
    sessionStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
