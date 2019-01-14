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
import { HttpClientModule } from '@angular/common/http';
import { BuyTicketModal } from '../currentScreenings/buyTicketModal.component';
import { DemoDropdownSplitComponent } from '../currentScreenings/demoDropdownSplitComponent';

@NgModule({
    imports: [
        CommonModule,
        DragDropModule,
        RouterModule,
        FormsModule,
        HttpClientModule
     ],
     declarations: [
        CurrentScreeningsComponent,
        MyFavoritesComponent,
        BuyTicketModal,
        DemoDropdownSplitComponent,
        BuyTicketComponent,
        PremiereComponent,
        HeaderComponent,
        HighlightDirective,
        TicketCostPipe,
        ShellComponent 
     ],
     exports: [ BuyTicketModal ],
     entryComponents: [ BuyTicketModal ],
     
})
export class ShellModule {

}
