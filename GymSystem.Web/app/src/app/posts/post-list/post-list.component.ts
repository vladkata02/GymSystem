import { Component } from '@angular/core';
import { IPost } from 'src/app/shared/interfaces';
import { ApiService } from '../../api.service';
import { NewPostComponent } from '../new-post/new-post.component';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent {
  postList: IPost[] | null = null;
  errors: Error | null = null;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.loadPosts().subscribe({
      next: (value: any) => {
        this.postList = value;
      },
      error: (err: Error) => {
        this.errors = err;
      }
    });
  }
}
