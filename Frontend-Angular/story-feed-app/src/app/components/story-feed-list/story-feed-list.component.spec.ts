import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StoryFeedListComponent } from './story-feed-list.component';
import { StoryFeedService } from '../../services/story-feed.service';
import { of } from 'rxjs';
import { NgFor } from '@angular/common';
import { FilterPipe } from '../../pipes/filter-pipe.pipe';
import { NgxPaginationModule } from 'ngx-pagination';
import { StoryFeedListComponentSearch } from '../story-feed-list-search/story-feed-list-search.component';

describe('StoryFeedListComponent', () => {
  let component: StoryFeedListComponent;
  let fixture: ComponentFixture<StoryFeedListComponent>;
  let storyFeedService: jasmine.SpyObj<StoryFeedService>;

  beforeEach(() => {
    const serviceMock = jasmine.createSpyObj('StoryFeedService', ['getNewestStories']);

    TestBed.configureTestingModule({
      imports: [NgFor, NgxPaginationModule], // Ensure required modules are imported
      declarations: [],
      providers: [{ provide: StoryFeedService, useValue: serviceMock }]
    }).compileComponents();

    fixture = TestBed.createComponent(StoryFeedListComponent);
    component = fixture.componentInstance;
    storyFeedService = TestBed.inject(StoryFeedService) as jasmine.SpyObj<StoryFeedService>;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize story list on ngOnInit', () => {
    const mockStories = [
      { id: 1, title: 'Test123' },
      { id: 2, title: 'Test3456' }
    ];

    storyFeedService.getNewestStories.and.returnValue(of(mockStories));
    component.ngOnInit();

    expect(component.storylist).toEqual(mockStories);
    expect(component.updatedstorylist).toEqual(mockStories);
    expect(component.totallitems).toBe(mockStories.length);
  });

  it('should filter stories based on search text', () => {
    component.storylist = [
      { id: 1, title: 'testing' },
      { id: 2, title: 'Ttest123' },
      { id: 3, title: 'test234' }
    ];

    component.getDataFromsrchText('tech');

    expect(component.updatedstorylist).toEqual([{ id: 2, title: 'Tech Update' }]);
    expect(component.totallitems).toBe(1);
  });

  it('should return empty list if no matching search text', () => {
    component.storylist = [
      { id: 1, title: 'Test345' },
      { id: 2, title: 'Test678' }
    ];

    component.getDataFromsrchText('travel');

    expect(component.updatedstorylist).toEqual([]);
    expect(component.totallitems).toBe(0);
  });
});