import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ShellModule } from './shell/shell.module';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { HighlightDirective } from './common/highlight.directive';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
  ],
  exports: [DragDropModule],
  imports: [
    BrowserModule,
    ShellModule,
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule // must be imported as the last module as it contains the fallback route
  ],
  providers: [DragDropModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
