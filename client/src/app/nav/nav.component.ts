import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit{
  model: any = {}

  constructor(public accountService:AccountService, private router:Router,
    private toastr:ToastrService){}

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
      next: (response: any) => {
        console.log(response);
        //this.loggedIn=true;
        this.router.navigateByUrl('/members');
        this.toastr.success('Successfull');
      },
      //error: (error: any)=>console.log(error)
      error:(error : any)  =>{this.toastr.error(error.error), console.log(error)}
      
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
    //this.loggedIn = false;
  }

}
