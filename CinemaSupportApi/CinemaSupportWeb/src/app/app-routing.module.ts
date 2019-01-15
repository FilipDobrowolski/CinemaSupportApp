import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './shell/shell.component';
import { PremiereComponent } from './premiere/premiere.component';
import { CurrentScreeningsComponent } from './currentScreenings/currentScreenings.component';
import { BuyTicketComponent } from './tickets/buy-ticket.component';
import { MyFavoritesComponent } from './myFavorites/myFavorites.component';
import { AuthGuard } from './auth/auth.guard';



const routes: Routes = [
  // Fallback when no prior route is matched
  {
    path: '',
    component: ShellComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'premiere'
    },
    {
        path: 'premiere',
        component: PremiereComponent
    },
    {
        path: 'currentScreenings',
        component: CurrentScreeningsComponent
    },
    {
      path: 'buyTicket',
      component: BuyTicketComponent
    },
    {
      path: 'myFavorites',
      component: MyFavoritesComponent
    }
    ]
  },
  { 
    path: '**',
    redirectTo: '',
    pathMatch: 'full' 
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
