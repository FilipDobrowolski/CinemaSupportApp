import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { TranslateService } from '@ngx-translate/core';


@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

    ngOnInit(): void {       
    }

    constructor(private router: Router, private translateService: TranslateService) {}

    changeLanguage(language: string): void {
        this.translateService.use(language);
      }

}