import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    templateUrl: './premiere.component.html',
    styleUrls: ['./premiere.component.scss']
})
export class PremiereComponent implements OnInit {

    ngOnInit(): void {       
    }

    constructor(private router: Router) {}



}