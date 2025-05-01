import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { StoryFeedListComponent } from './components/story-feed-list/story-feed-list.component';
import { StoryFeedListComponentSearch } from './components/story-feed-list-search/story-feed-list-search.component';
import { LoaderComponent } from './components/loader/loader.component';


@Component({
  selector: 'app-root',
  imports: [LoaderComponent,StoryFeedListComponentSearch,StoryFeedListComponent,RouterOutlet, RouterLink, RouterLinkActive,],
 
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'story-feed';
}
