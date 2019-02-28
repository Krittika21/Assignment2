import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MessageListComponent } from './message-list/message-list.component';
import { DetailsComponent } from './details/details.component';
import { CommentLikeComponent } from './comment-like/comment-like.component';

const routes: Routes = [
  { path: 'message-list', component: MessageListComponent },
  { path: 'details', component: DetailsComponent },
  { path: 'comment-like', component: CommentLikeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
 })
export class AppRoutingModule { }
