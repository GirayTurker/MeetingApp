import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path:'', component:HomeComponent}, //localpath
  {path:'members', component:MemberListComponent, canActivate:[authGuard]},//localpath/members
  {path:'members/:id', component:MemberDetailsComponent, canActivate:[authGuard]},//localpath/members/id
  {path:'lists', component:ListsComponent, canActivate:[authGuard]},//localpath/lists
  {path:'messages', component:MessagesComponent, canActivate:[authGuard]},
  {path:'**', component:HomeComponent, pathMatch:"full"} //What if localpath/
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
