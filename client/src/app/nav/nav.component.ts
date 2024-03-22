import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { IUser } from '../_models/user';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit{
  model: any = {}
  
  //loggedIn = false;
  constructor(public accountService:AccountService){}

  ngOnInit(): void {
   
  }

  /*
  getCurrenctUser()
  {
    this.accountService.currentIUser$.subscribe({
      next: user => this.loggedIn = !!user,
      error: error => console.log(error)
    })
  }
  */
  
  login()
  {
    this.accountService.login(this.model).subscribe
    ({
      next: response => {
        console.log(response);
        //this.loggedIn=true;
      },
      error: error=>console.log(error)
    })
  }

  logout(){
    this.accountService.logout();
    //this.loggedIn = false;
  }

}
