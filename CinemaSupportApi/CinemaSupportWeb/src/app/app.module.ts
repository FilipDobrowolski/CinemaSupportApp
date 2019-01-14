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
import { httpInterceptorProviders } from './http-interceptors/index';
import { AuthRoutingModule } from './auth/auth-routing.module';
import { AuthModule } from './auth/auth.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';



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
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    AuthModule,
    AppRoutingModule // must be imported as the last module as it contains the fallback route
  ],
  providers: [DragDropModule, httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
