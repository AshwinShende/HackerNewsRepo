import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class StoryFeedService {
  private API_URL = 'https://localhost:44306/api/news';

  constructor(private http: HttpClient) {}

  getNewestStories(): Observable<any[]> {
    debugger;
    return this.http.get<any[]>(this.API_URL);
  }
}