import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryFeedListComponent } from './components/story-feed-list/story-feed-list.component';


export const routes: Routes = [
    { path: 'story-feed-list', component: StoryFeedListComponent },
    { path: '', redirectTo: 'story-feed-list' , pathMatch: 'full' },
  ];
  export class AppRoutingModule { }