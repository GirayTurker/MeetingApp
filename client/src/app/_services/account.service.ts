import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import {IUser} from '../_models/user'

@Injectable({
  providedIn: 'root'
})
//Responsible for HTTP Request from client to server (API)
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  
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
