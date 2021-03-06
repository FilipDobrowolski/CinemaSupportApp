import { OnInit, Component, Input } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
    selector: 'modal-content',
    templateUrl: './buyTicketModal.component.html'
})
export class BuyTicketModal implements OnInit {

    public apiUrl : string = 'http://localhost:52775/api';
    seatsObservable : Observable<Seat[]>;
    private currentTicketNumber: number;
    private currentTicketType: number;
    private isDisabled: boolean = true;
    @Input() screeningId: number;
    @Input() screeningRoomId: number;
    seatsSubscription: Subscription;
    constructor(public bsModalRef: BsModalRef,
        private http: HttpClient,) {}
    
    ngOnInit() {
        this.getSeats();      
    }

    public getSeats() {
        let url = `${this.apiUrl}/seats/screeningseats?screeningId=${this.screeningId}&screeningroomid=${this.screeningRoomId}`;
        this.seatsObservable = this.http.get<Seat[]>(url);
        this.seatsSubscription = this.seatsObservable.subscribe(res => console.log(res));
    }

    public ticketNumber(ticketnumber) {
        this.currentTicketNumber = ticketnumber;
        this.isDisabledButton();

    }
    public ticketType(tickettype) {
        this.currentTicketType = tickettype;
        this.isDisabledButton();
    }
    public isDisabledButton() {
        if (!!this.currentTicketNumber && !!this.currentTicketType)
        {
            this.isDisabled = false;
        }
        else {
            this.isDisabled = true;
        }
    }
    public submit() {
        let url = `${this.apiUrl}/tickets/buyticket`;

        this.http.post(url, {ticketId: this.currentTicketNumber , screeningId: this.screeningId , ticketType: this.currentTicketType, actorName: window.sessionStorage.getItem('currentUser') }).subscribe(res => console.log(res));
        this.bsModalRef.hide();
    }
}

export class Seat {
    seatId: number;

    public static create(json:any) : Seat {
        const item = new Seat();
       
        item.seatId = json.seatId;

        return item;
}
}