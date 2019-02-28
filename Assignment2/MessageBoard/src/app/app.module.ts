import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageListComponent } from './message-list/message-list.component';
import { DetailsComponent } from './details/details.component';
import { CommentLikeComponent } from './comment-like/comment-like.component';
import { Routes, RouterModule } from '@angular/router';
import { AddNewComponent } from './add-new/add-new.component';
import { MessageService } from './message.service';
import { DecimalPipe } from '@angular/common';
import { DatePipe } from '@angular/common';

const appRoutes: Routes = [
  { path: '', component: MessageListComponent }];

@NgModule({
  declarations: [
    AppComponent,
    MessageListComponent,
    DetailsComponent,
    CommentLikeComponent,
    AddNewComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [MessageService],
  bootstrap: [AppComponent],

})
export class AppModule { }
