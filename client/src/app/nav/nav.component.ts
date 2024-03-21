import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit{
  model: any = {}
  
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  login()
  {
    console.log(this.model);
  }

}
