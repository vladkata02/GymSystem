import { Injectable } from '@angular/core';
import { HttpClient, HttpContext, HttpHeaders } from '@angular/common/http'
import { environment } from '../environments/environment';
import { IPost } from './shared/interfaces/post';
import { Observable } from 'rxjs';
import { AuthService } from './auth/auth.service';

const apiURL = environment.apiURL;

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient, private authService: AuthService) { }

  authorizedHeaders(){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.authService.idToken}`
    });
    return { headers: headers}
  }

  // makeRequest() {
  //   return new HttpHeaders().set('Cookie', 'jwt=your-jwt-token');
  // }

  createPost(title: string, description: string, imageLink: string): Observable<any> {
    const headers = this.authorizedHeaders();
    return this.httpClient.post<IPost>(`${apiURL}/posts/create`, { title, description, imageLink}, headers);
  }

  loadPosts() {
    return this.httpClient.get<IPost[]>(`${apiURL}/posts/list`);
  }
}
