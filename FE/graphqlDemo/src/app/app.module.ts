import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ApolloModule } from 'apollo-angular';
import { HttpLinkModule } from 'apollo-angular-link-http';

import { AppComponent } from './app.component';
import { GraphqlModule } from './graphql/graphql.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    GraphqlModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
