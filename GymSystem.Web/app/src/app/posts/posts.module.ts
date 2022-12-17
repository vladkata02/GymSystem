import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewPostComponent } from './new-post/new-post.component';
import { PostListComponent } from './post-list/post-list.component';
import { PostRoutingModule } from './posts-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    NewPostComponent,
    PostListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PostRoutingModule
  ],
  exports: [
    PostListComponent
  ],
})
export class PostsModule { }
