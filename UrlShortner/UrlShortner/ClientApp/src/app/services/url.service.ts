import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { URLDetails } from "../models/url-details.model";
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class URLService {

  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
  }

  createShortUrl(longUrl: string): Observable<URLDetails> {
    return this.httpClient.post<URLDetails>(this.apiUrl + 'api/URL', { URL: longUrl })
      .pipe(
        map((data: URLDetails) => ({
          code: data.code,
          shortUrl: this.apiUrl + data.code
        })
      ));
  }
}
