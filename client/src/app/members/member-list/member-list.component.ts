import { Component } from '@angular/core';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css'
})
export class MemberListComponent {

  constructor(public accountService:AccountService){}

}
