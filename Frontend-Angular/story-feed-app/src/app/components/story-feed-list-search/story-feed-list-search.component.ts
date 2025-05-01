import { Component,Output, EventEmitter } from '@angular/core';
import {FormsModule} from "@angular/forms"
@Component({
  selector: 'app-search-story-feed-list',
  imports: [FormsModule],
  templateUrl: './story-feed-list-search.component.html',
  styleUrl: './story-feed-list-search.component.css',
  standalone:true
})
export class StoryFeedListComponentSearch {
  @Output() dataToStoryFeed = new EventEmitter<string>();
   
  searchText:string = '';

  constructor() {}

  onSearchTextChange() {
    this.dataToStoryFeed.emit(this.searchText);
  }

}
