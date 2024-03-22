import { Component, EventEmitter, Input, OnInit, Output, output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{

  @Input() usersFromHomeComponent: any;

  @Output() cancelRegister = new EventEmitter();

  model:any={}

  constructor(){}
  
  ngOnInit(): void {
    
  }



  register(){
    console.log(this.model);
  }

  cancel()
  {
    this.cancelRegister.emit(false);
    console.log('canceled');
  }
}
