import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryFeedListComponentSearch } from './story-feed-list-search.component';
import { HttpClient } from '@angular/common/http';

describe('SearchStoryFeedListComponent', () => {
  let component: StoryFeedListComponentSearch;
  let fixture: ComponentFixture<StoryFeedListComponentSearch>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoryFeedListComponentSearch],
      providers: [HttpClient]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoryFeedListComponentSearch);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have an empty searchText by default', () => {
    expect(component.searchText).toBe('');
  });

  it('should emit searchText on text change on submit button click', () => {
    spyOn(component.dataToStoryFeed, 'emit');

    component.searchText = 'Angular';
    component.onSearchTextChange();

    expect(component.dataToStoryFeed.emit).toHaveBeenCalledWith('Angular');
  });

});
