import { Component } from '@angular/core';
import { Member } from '../../_models/member';
import { MembersService } from '../../_services/members.service';
import { Observable, Subscription, map} from 'rxjs';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css'
})
export class MemberListComponent {
  members: Member [] = [];
  userName: string ="username";

  constructor(private memberService: MembersService){}

  //As soon as initialize the root, call loadMembers method
  ngOnInit():void{
    this.loadMembers();
    this.getUserName();
  }

  getUserName()
  {
    const userFromStorage = sessionStorage.getItem('user');
    // console.log(sessionStorage.getItem('user'));
    if(userFromStorage){
      const userNameFromStorage = JSON.parse(userFromStorage);
      this.userName = userNameFromStorage.username;
      // console.log(this.userName);
    }
    else{
      this.userName = "username";
    }
  }

  loadMembers(){
    this.memberService.getMembers().subscribe({
      next: members => this.members = members
    })
  }

}
