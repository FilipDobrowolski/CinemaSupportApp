import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {CdkDragDrop, moveItemInArray} from '@angular/cdk/drag-drop';


@Component({
    templateUrl: './myFavorites.component.html',
    styleUrls: ['./myFavorites.component.scss']
})
export class MyFavoritesComponent implements OnInit {
    
    private movies: string[] = [
        'Star Wars Episode I - The Phantom Menace',
        'Star Wars Episode II - Attack of the Clones',
        'Star Wars Episode III - Revenge of the Sith',
        'Star Wars Episode IV - A New Hope',
        'Star Wars Episode V - The Empire Strikes Back',
        'Star Wars Episode VI - Return of the Jedi',
        'Star Wars Episode VII - The Force Awakens',
        'Star Wars Episode VIII - The Last Jedi'
      ];

    ngOnInit(): void {       
    }

    constructor(private router: Router) {}

    private drop(event: CdkDragDrop<string[]>) {
        moveItemInArray(this.movies, event.previousIndex, event.currentIndex);
      }

}