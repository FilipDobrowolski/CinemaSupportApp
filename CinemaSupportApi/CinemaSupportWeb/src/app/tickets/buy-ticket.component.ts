import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    templateUrl: './buy-ticket.component.html',
    styleUrls: ['./buy-ticket.component.scss']
})
export class BuyTicketComponent implements OnInit {

    public normal = 5;
    public numer = 4;

    ngOnInit(): void {       
    }

    constructor(private router: Router) {}

    user: User = {
        name: '',
        account: {
          email: '',
          confirm: ''
        }
      };
      onSubmit({ value, valid }: { value: User, valid: boolean }) {
        console.log(value, valid);
      }

}

export interface User {
    name: string;
    account: {
      email: string;
      confirm: string;
    }
  }