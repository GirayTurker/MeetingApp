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
  {path:'',
    runGuardsAndResolvers:'always',
    canActivate:[authGuard],
    children:[
      {path:'members', component:MemberListComponent},//localpath/members
      {path:'members/:id', component:MemberDetailsComponent},//localpath/members/id
      {path:'lists', component:ListsComponent},//localpath/lists
      {path:'messages', component:MessagesComponent},//localpath/messages
    ]  
  },
  
  {path:'**', component:HomeComponent, pathMatch:"full"} //What if localpath/
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
