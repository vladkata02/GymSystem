import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, NgForm, NgModel, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { AuthService } from 'src/app/auth/auth.service';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.scss'],
})
export class NewPostComponent {

  loggedIn = false;
  isFormInvalid = false;
  
  @ViewChild(NgForm, { static: true }) form!: ElementRef<HTMLInputElement>;
  
  constructor(
    private apiService: ApiService,
    private http: HttpClient,
    private router: Router,
    private authService: AuthService
    ) {}
    
    
    postHandler(form: NgForm): void {
      if (form.invalid) {
        this.isFormInvalid = false;
      return;
    }
    const { title, description, imageLink } = form.value;

      this.apiService.createPost(title, description, imageLink).subscribe(() => {
        window.location.reload();
      });
  }

  ngDoCheck(): void {
    this.loggedIn = this.authService.isLoggedIn;
  }
}
