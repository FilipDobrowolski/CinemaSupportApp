import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { trigger,state,style,transition,animate,keyframes } from '@angular/animations';

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

    ngOnInit(): void {       
    }
    private color: string = 'blue';

    constructor(private router: Router) {}

    private state: string = 'small';

    animateMe() {
        this.state = (this.state === 'small' ? 'large' : 'small');
    }


}