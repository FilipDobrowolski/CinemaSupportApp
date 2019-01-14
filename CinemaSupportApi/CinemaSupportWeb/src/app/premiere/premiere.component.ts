import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { trigger,state,style,transition,animate,keyframes } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
    templateUrl: './premiere.component.html',
    styleUrls: ['./premiere.component.scss'],
    animations:[
        trigger('myAwesomeAnimation', [
            state('small', style({
                transform: 'scale(1)',
            })),
            state('large', style({
                transform: 'scale(1.2)',
            })),
            transition('small => large', animate('800ms ease-in')),
            transition('large => small', animate('800ms ease-in')),
        ]),
    ]
})
export class PremiereComponent implements OnInit {

    private color: string = 'blue';

    constructor(private router: Router, private http: HttpClient) {}

    private state: string = 'small';

    animateMe() {
        this.state = (this.state === 'small' ? 'large' : 'small');
    }


    public apiUrl : string = 'http://localhost:52775/api';
    screeningRoomsObservable : Observable<ScreeningRoom[]>;
  
    
    ngOnInit() {
        this.getScreeningRooms();      
    }
  
    public getScreeningRooms() {
        let url = `${this.apiUrl}/screeningrooms/all`;
        this.screeningRoomsObservable = this.http.get<ScreeningRoom[]>(url);
    }

}
export class ScreeningRoom {
    screeningRoomId: number;
    name: string;
    floor: number;
    seats: Array<Seat>;

    public static create(json:any) : ScreeningRoom {
        const item = new ScreeningRoom();
        item.screeningRoomId = json.screeningId;
        item.name = json.name;
        item.floor = json.floor;

        if (json.seats && json.seats.lenght) {
            item.seats = json.seats.map(seat => Seat.create(seat));
        }

        return item;
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
