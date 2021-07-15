import { Component } from '@angular/core';
import { URLService } from '../services/url.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  shortURL: string;
  longURL: string;

  constructor(private urlService: URLService) { }

  inputChange(value: string) {
    this.longURL = value;
  }

  addUrl() {
    this.urlService.createShortUrl(this.longURL)
      .subscribe(data => {
        this.shortURL = data.shortValue;
      });
  }
}
