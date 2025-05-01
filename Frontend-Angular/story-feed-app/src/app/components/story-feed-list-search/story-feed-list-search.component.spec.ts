import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryFeedListComponentSearch } from './story-feed-list-search.component';

describe('SearchStoryFeedListComponent', () => {
  let component: StoryFeedListComponentSearch;
  let fixture: ComponentFixture<StoryFeedListComponentSearch>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoryFeedListComponentSearch]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoryFeedListComponentSearch);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
