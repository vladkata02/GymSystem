import { Injectable } from '@angular/core';
import { HttpClient, HttpContext, HttpHeaders } from '@angular/common/http'
import { environment } from '../environments/environment';
import { IPost } from './shared/interfaces/post';
import { Observable } from 'rxjs';
import { AuthService } from './auth/auth.service';
import { IPrice, ISubscription } from './shared/interfaces';
import { CurrencyPipe } from '@angular/common';

const apiURL = environment.apiURL;

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient, private authService: AuthService) { }

  authorizedHeaders(){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("id_token")}`
    });
    return { headers: headers}
  }

  createPrice(amount: number, isDefaultPrice: boolean, months?: number ){
    return this.httpClient.post<IPrice>(`${apiURL}/prices/create`, { months, amount, isDefaultPrice}, this.authorizedHeaders());
  }

  getAllPrices(){
    const headers = this.authorizedHeaders();
    return this.httpClient.get<IPrice[]>(`${apiURL}/prices/list`, headers);
  }

  createSubscription(months: number, moneyPaid: number){
    const headers = this.authorizedHeaders();
    return this.httpClient.post<ISubscription>(`${apiURL}/subscriptions/create`, { months, moneyPaid}, headers);
  }

  loadSubscriptions() {
    const headers = this.authorizedHeaders();
    return this.httpClient.get<ISubscription[]>(`${apiURL}/subscriptions/list`, headers);
  }

  createPost(title: string, description: string, imageLink: string): Observable<any> {
    const headers = this.authorizedHeaders();
    return this.httpClient.post<IPost>(`${apiURL}/posts/create`, { title, description, imageLink}, headers);
  }

  loadPosts() {
    return this.httpClient.get<IPost[]>(`${apiURL}/posts/list`);
  }
}
