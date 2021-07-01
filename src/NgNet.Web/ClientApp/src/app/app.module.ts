import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ConsHttpInterceptor } from './interceptors/ngnet-interceptor';
import { AddEmployeeComponent } from './components/add-employee/add-employee-component';
import { MasterComponent } from './components/master/master.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavBarComponent } from './components/navbar/navbar.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee-component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddEmployeeComponent,
    EditEmployeeComponent,
    MasterComponent,
    NavBarComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot()
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:ConsHttpInterceptor,
    multi:true
  }],
  schemas: [ NO_ERRORS_SCHEMA ],
  bootstrap: [AppComponent]
})
export class AppModule { }
