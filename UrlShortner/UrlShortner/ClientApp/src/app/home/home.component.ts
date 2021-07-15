import { Component } from '@angular/core';
import { URLService } from '../services/url.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  shortURL: string;
  longURL: string = "";
  urlError: boolean = false;

  constructor(private urlService: URLService) { }

  addUrl() {
    this.validateUrl();
    if (!this.urlError) {
      this.urlService.createShortUrl(this.longURL)
        .subscribe(data => {
          this.shortURL = data.shortUrl;
        });
    }
  }

  validateUrl() {
    try {
      new URL(this.longURL);
      this.urlError = false;
    } catch {
      this.urlError = true;
    }
  }

  copyUrl() {
    document.addEventListener('copy', (e: ClipboardEvent) => {
      e.clipboardData.setData('text/plain', (this.shortURL));
      e.preventDefault();
      document.removeEventListener('copy', null);
    });
    document.execCommand('copy');
  }

  resetVals() {
    this.longURL = "";
    this.shortURL = null;
  }
}
