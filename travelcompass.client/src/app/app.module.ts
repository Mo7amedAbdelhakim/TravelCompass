import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { StoreComponent } from './store/store.component';
import { CategoryClient } from './Services/TravelCompassClient';

@NgModule({
  declarations: [
    AppComponent,
    StoreComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [CategoryClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
