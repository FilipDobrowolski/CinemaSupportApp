import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HighlightDirective } from '../common/highlight.directive';

@Component({
    templateUrl: './currentScreenings.component.html',
    styleUrls: ['./currentScreenings.component.scss']
})
export class CurrentScreeningsComponent implements OnInit {

    ngOnInit(): void {       
    }
    
    constructor(private router: Router) {}



}