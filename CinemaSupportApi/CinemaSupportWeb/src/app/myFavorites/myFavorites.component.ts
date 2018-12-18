import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    templateUrl: './myFavorites.component.html',
    styleUrls: ['./myFavorites.component.scss']
})
export class MyFavoritesComponent implements OnInit {

    ngOnInit(): void {       
    }

    constructor(private router: Router) {}



}