import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getMembers(){
    return this.http.get<Member[]>(this.baseUrl+'user',this.getHttpOptions())
  }

  getMember(userName:string)
  {
    return this.http.get<Member>(this.baseUrl+'user/'+userName, this.getHttpOptions()) 
  }
 
//Pass Auth Token with Header  
getHttpOptions(){
  //Token Passed sessionStorage in account services, fish it out
  const userString = sessionStorage.getItem('user');
  if(!userString) return;

  const user = JSON.parse(userString);
  return{
    headers:new HttpHeaders({
      Authorization: 'Bearer '+user.token
    })
  }
}

}
