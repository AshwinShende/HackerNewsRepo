import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptors } from '@angular/common/http';
import { StoryFeedListComponent } from './app/components/story-feed-list/story-feed-list.component';
import { loaderInterceptor } from './app/interceptors/loader.interceptor';


bootstrapApplication(AppComponent,{
  providers: [provideHttpClient(withInterceptors([loaderInterceptor]))]
})
  .catch((err) => console.error(err));

