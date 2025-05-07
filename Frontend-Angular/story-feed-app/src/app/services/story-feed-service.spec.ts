import { TestBed } from '@angular/core/testing';
import { StoryFeedService } from './story-feed.service';
import { provideHttpClientTesting, HttpTestingController, HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('StoryFeedService', () => {
  let service: StoryFeedService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        StoryFeedService
      ]
    });

    service = TestBed.inject(StoryFeedService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch newest stories successfully', () => {
    const mockStories = [
      { id: 1, title: 'My news', content: 'Test content' },
      { id: 2, title: 'Test Title', content: 'test content' }
    ];
    service.getNewestStories().subscribe(stories => {
      expect(stories).toEqual(mockStories);
    });

    const req = httpMock.expectOne(service['API_URL']);
    expect(req.request.method).toBe('GET');
    req.flush(mockStories);
  });

  it('should handle errors while fetching stories', () => {
    service.getNewestStories().subscribe({
      next: () => fail('Expected an error, but got data'),
      error: (error) => {
        expect(error.status).toBe(500);
        expect(error.statusText).toBe('Internal Server Error');
      }
    });

    const req = httpMock.expectOne('https://localhost:44306/api/news');
    req.flush('Server error', { status: 500, statusText: 'Internal Server Error' });
  });

});