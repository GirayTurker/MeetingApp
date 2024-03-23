import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit{
  model: any = {}

  constructor(public accountService:AccountService, private router:Router){}

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
        this.router.navigateByUrl('/members')
      },
      error: error=>console.log(error)
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
    //this.loggedIn = false;
  }

}
