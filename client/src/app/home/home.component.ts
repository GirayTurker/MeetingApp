import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  registerMode = false;

  users:any; //type of variable any
  
  constructor(public accountService:AccountService){}

  ngOnInit(): void {
    // this.getUsers();
  } 

  registerToggle(){
    this.registerMode = !this.registerMode
  }

  // getUsers()
  // {
  //   this.http.get('https://localhost:5001/api/user').subscribe
  //   ({
  //     next: response => this.users = response,
  //     error: error => console.log(error),
  //     complete: () => console.log('Http Request has Completed'),
  //   })   
  // }

  calcelRegisterMode(event:boolean)
  {
    this.registerMode = event;
  }
}
