import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HighlightDirective } from '../common/highlight.directive';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
    templateUrl: './currentScreenings.component.html',
    styleUrls: ['./currentScreenings.component.scss']
})
export class CurrentScreeningsComponent implements OnInit {

    public apiUrl : string = 'http://localhost:52775/api';
    moviesObservable : Observable<Movie[]>;
    public apiUrlTwo: string = 'http://localhost:52775';

    ngOnInit(): void {       
    }

    constructor(private router: Router,
        private http: HttpClient) {}

    public getMovies() {

        let url = `${this.apiUrl}/movies`;
        this.moviesObservable = this.http.get<Movie[]>(url);
    }

}

export class Movie {
    id: string;
    title: string;
    duration: number
}