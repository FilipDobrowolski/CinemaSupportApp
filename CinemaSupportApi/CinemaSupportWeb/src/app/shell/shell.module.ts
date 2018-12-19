import { NgModule, ModuleWithComponentFactories } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ShellComponent } from './shell.component';
import { HeaderComponent } from './header/header.component';
import { CurrentScreeningsComponent } from '../currentScreenings/currentScreenings.component';
import { MyFavoritesComponent } from '../myFavorites/myFavorites.component';
import { BuyTicketComponent } from '../tickets/buy-ticket.component';
import { PremiereComponent } from '../premiere/premiere.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { HighlightDirective } from '../common/highlight.directive';
import { TicketCostPipe } from '../common/ticketCost.pipe';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        DragDropModule,
        RouterModule,
        FormsModule
     ],
     declarations: [
        CurrentScreeningsComponent,
        MyFavoritesComponent,
        BuyTicketComponent,
        PremiereComponent,
        HeaderComponent,
        HighlightDirective,
        TicketCostPipe,
        ShellComponent 
     ],
     
})
export class ShellModule {

}
