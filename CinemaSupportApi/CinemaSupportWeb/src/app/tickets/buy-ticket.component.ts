import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
    templateUrl: './buy-ticket.component.html',
    styleUrls: ['./buy-ticket.component.scss']
})
export class BuyTicketComponent implements OnInit {

  public apiUrl : string = 'http://localhost:52775/api';
  ticketsObservable : Observable<Ticket[]>;

 
  constructor( private http: HttpClient) {}
  
  ngOnInit() {
      this.getTickets();      
  }

  public getTickets() {
      let url = `${this.apiUrl}/tickets/getallbyactoruniquename?actorName=filip`;
      this.ticketsObservable = this.http.get<Ticket[]>(url);
  }

  public validate() {
    
  }
}
export class Ticket {
  ticketId: number;
  price: number;
  ticketType: number;
  purchased: boolean;
  validated: boolean;
  screeningId: number;
}
