import { TestBed } from '@angular/core/testing';
import { LoaderService } from './loader.service';

describe('LoaderService', () => {
  let service: LoaderService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LoaderService]
    });

    service = TestBed.inject(LoaderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should have a default loading state as false', (done) => {
    service.loading$.subscribe(isLoading => {
      expect(isLoading).toBeFalse();
      done();
    });
  });

  it('should update loading state when setLoading is called', (done) => {
    service.setLoading(true);
    service.loading$.subscribe(isLoading => {
      expect(isLoading).toBeTrue();
      done();
    });
  });
});