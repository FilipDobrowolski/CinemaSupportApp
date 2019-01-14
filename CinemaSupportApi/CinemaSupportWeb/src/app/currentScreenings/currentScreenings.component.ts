import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HighlightDirective } from '../common/highlight.directive';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Title } from '@angular/platform-browser';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BuyTicketComponent } from '../tickets/buy-ticket.component';
import { BuyTicketModal } from './buyTicketModal.component';

@Component({
    templateUrl: './currentScreenings.component.html',
    styleUrls: ['./currentScreenings.component.scss']
})
export class CurrentScreeningsComponent implements OnInit {

    public apiUrl : string = 'http://localhost:52775/api';
    moviesObservable : Observable<Movie[]>;
    public apiUrlTwo: string = 'http://localhost:52775';
    bsModalRef: BsModalRef;

    ngOnInit(): void {  
        this.getMovies();     
    }

    constructor(private router: Router,
        private http: HttpClient,
        private _modalService: BsModalService) {}

    public getMovies() {

        let url = `${this.apiUrl}/movies`;
        this.moviesObservable = this.http.get<Movie[]>(url);
    }

    public openModalView(screeningid, screeningRoomId): void {
        const initialState = {
            screeningId: screeningid,
            screeningRoomId: screeningRoomId
        }

        this.bsModalRef = this._modalService.show(BuyTicketModal, { initialState })
    }

}

export class Movie {
    movieId: string;
    title: string;
    duration: number;
    picture: string;
    screenings: Array<Screening>;

    public static create(json:any) : Movie {
        const item = new Movie();

        item.movieId = json.movieId;
        item.title = json.title;
        item.duration = json.duration;
        item.picture = json.picture;

        if (json.screenings && json.screenings.lenght) {
            item.screenings = json.screenings.map(screening => Screening.create(screening));
        }
        
        return item;
    }

}

export class Screening {
    screeningId: number;
    status: boolean;
    screeningDate: string;
    screeningRoomId: number;
    movieId: number;   
    
    public static create(json:any) : Screening {
        const item = new Screening();

        item.screeningId = json.screeningId;
        item.status = json.status;
        item.screeningDate = json.screeningDate;
        item.screeningRoomId = json.screeningRoomId;
        item.movieId = json.movieId;

        return item;
    }
}