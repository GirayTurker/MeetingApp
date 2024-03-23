import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{

  //@Input() usersFromHomeComponent: any;

  @Output() cancelRegister = new EventEmitter();

  model:any={}

  constructor(private accountService:AccountService, private toastr:ToastrService){}
  
  ngOnInit(): void {
    
  }

  register(){
    this.accountService.register(this.model).subscribe({
      next: ()=>{
        this.cancel();
        //console.log(response);
        this.toastr.success('Successfull');
      },
      //error: error=>console.log(error)
      error: (error:any) =>{
        this.toastr.error(error.error),
        console.log(error)
      } 
    });
  }

  cancel()
  {
    this.cancelRegister.emit(false);
    console.log('canceled');
  }
}
