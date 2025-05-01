import { HttpInterceptorFn } from '@angular/common/http';
import { LoaderService } from '../services/loader.service';
import { finalize } from 'rxjs';

export const loaderInterceptor: HttpInterceptorFn = (req, next) => {
  const loaderService = new LoaderService();
  loaderService.setLoading(true);

  return next(req).pipe(
    finalize(() => loaderService.setLoading(false))
  );
};