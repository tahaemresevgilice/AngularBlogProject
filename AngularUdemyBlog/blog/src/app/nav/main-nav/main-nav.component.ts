import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

enum MainPage {
  home = 1,
  aboutMe = 2,
  contact = 3,
}

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
  pageActive: MainPage = MainPage.home;

  constructor(private router: Router) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.updateActivePage(event.url);
      }
    });
  }

  private updateActivePage(url: string) {
    switch (url) {
      case '/anasayfa':
        this.pageActive = MainPage.home;
        break;
      case '/hakkimda':
        this.pageActive = MainPage.aboutMe;
        break;
      case '/iletisim':
        this.pageActive = MainPage.contact;
        break;
      default:
        this.pageActive = MainPage.home;
    }
  }

  ngOnInit() {}
}
