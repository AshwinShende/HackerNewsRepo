import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryFeedListComponent } from './story-feed-list.component';

describe('StoryFeedListComponent', () => {
  let component: StoryFeedListComponent;
  let fixture: ComponentFixture<StoryFeedListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoryFeedListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoryFeedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
