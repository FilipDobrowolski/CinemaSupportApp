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
  putObservable: Observable<any>
  public name: string = window.sessionStorage.getItem('currentUser');
  urlget = `${this.apiUrl}/tickets/getallbyactoruniquename?actorName=${window.sessionStorage.getItem('currentUser')}`;
  constructor( private http: HttpClient, private router: Router) {}
  
  ngOnInit() {
      this.getTickets();      
  }

  public getTickets() {
      let url = `${this.apiUrl}/tickets/getallbyactoruniquename?actorName=${window.sessionStorage.getItem('currentUser')}`;
      this.ticketsObservable = this.http.get<Ticket[]>(url);
  }

  public validate(ticketId) {
        let url = `${this.apiUrl}/tickets/validateticket`;

       this.putObservable = this.http.put(url, {ticketId: ticketId });
       this.putObservable.subscribe(res => { console.log(res); this.ticketsObservable = this.http.get<Ticket[]>(this.urlget); });
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
