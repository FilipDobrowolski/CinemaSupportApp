import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {CdkDragDrop, moveItemInArray} from '@angular/cdk/drag-drop';


@Component({
    templateUrl: './myFavorites.component.html',
    styleUrls: ['./myFavorites.component.scss']
})
export class MyFavoritesComponent implements OnInit {
    
    movies = [
        'Episode I - The Phantom Menace',
        'Episode II - Attack of the Clones',
        'Episode III - Revenge of the Sith',
        'Episode IV - A New Hope',
        'Episode V - The Empire Strikes Back',
        'Episode VI - Return of the Jedi',
        'Episode VII - The Force Awakens',
        'Episode VIII - The Last Jedi'
      ];

    ngOnInit(): void {       
    }

    constructor(private router: Router) {}

    drop(event: CdkDragDrop<string[]>) {
        moveItemInArray(this.movies, event.previousIndex, event.currentIndex);
      }

}