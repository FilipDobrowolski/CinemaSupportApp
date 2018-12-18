import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    templateUrl: './buy-ticket.component.html',
    styleUrls: ['./buy-ticket.component.scss']
})
export class BuyTicketComponent implements OnInit {

    ngOnInit(): void {       
    }

    constructor(private router: Router) {}



}