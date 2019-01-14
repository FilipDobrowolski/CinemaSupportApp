import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute  } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  constructor( private router: Router,
    private activatedRoute: ActivatedRoute, 
    private translate: TranslateService) {
      translate.addLangs(['en', 'pl']);

      translate.setDefaultLang('pl');
    
      const browserLang = this.translate.getBrowserLang();
      translate.use(browserLang.match(/en|pl/) ? browserLang : 'pl');
     }

  title = 'app';
}
