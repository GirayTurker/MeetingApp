import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { IUser } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Hello GT';
  users: any; //type of variable any

  constructor(private http: HttpClient, private accountService: AccountService){}
  
  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();
  } 

  getUsers()
  {
    this.http.get('https://localhost:5001/api/user').subscribe
    ({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Http Request has Completed')
    })
  }

  setCurrentUser(){
    const userString = sessionStorage.getItem('user');
    if(!userString)
    {
      return;
    } 
    const user:IUser = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }

}
