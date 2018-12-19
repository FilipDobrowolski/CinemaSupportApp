import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ShellModule } from './shell/shell.module';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [
    AppComponent
  ],
  exports: [DragDropModule],
  imports: [
    BrowserModule,
    ShellModule,
    AppRoutingModule // must be imported as the last module as it contains the fallback route
  ],
  providers: [DragDropModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
