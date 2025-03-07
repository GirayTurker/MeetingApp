import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { IUser } from './_models/user';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  //title = 'Hello GT';
  
  constructor( private accountService: AccountService){}
  
  ngOnInit(): void {
    this.setCurrentUser();
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
