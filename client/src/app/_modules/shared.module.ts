import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    ToastrModule.forRoot({
      //positioning
      positionClass:'toast-bottom-right'
    })
  ],
  exports:[
    ToastrModule
  ]
})
export class SharedModule { }
