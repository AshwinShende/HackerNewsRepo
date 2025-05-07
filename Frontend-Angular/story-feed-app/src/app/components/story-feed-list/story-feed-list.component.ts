import { Component, OnInit, Pipe } from "@angular/core";
import { StoryFeedService } from "../../services/story-feed.service";
import { StoryFeedListComponentSearch } from "../story-feed-list-search/story-feed-list-search.component";
import { NgxPaginationModule } from 'ngx-pagination';

import { NgModule } from '@angular/core';
import { filter, pipe } from "rxjs";
import { FilterPipe } from "../../pipes/filter-pipe.pipe";
import { NgFor } from "@angular/common";
@Component({
  selector: 'app-story-list',
  templateUrl: './story-feed-list.component.html',
  imports: [NgFor,FilterPipe,NgxPaginationModule,StoryFeedListComponentSearch],
  standalone:true
})
export class StoryFeedListComponent implements OnInit {
  storylist: any[] = [];
  updatedstorylist: any[] = [];
  searchText :string = '';
  page:any = 1;
  pageSize:any = 25;
  totallitems:any;
  
  constructor(private storyFeedService: StoryFeedService) {}

  ngOnInit(): void {
    this.storyFeedService.getNewestStories().subscribe(data => {
      this.storylist = data;
      this.updatedstorylist =  this.storylist;
      this.totallitems = this.storylist.length;
    });
  }
  getDataFromsrchText(text:string) {
    this.updatedstorylist=   this.storylist.filter(x=>x?.title.toLowerCase()?.includes(text.toLowerCase()));
    this.totallitems = this.updatedstorylist.length;
  
  }
 
}