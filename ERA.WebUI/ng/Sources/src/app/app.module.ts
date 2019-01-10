import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { UiSwitchModule } from 'angular2-ui-switch';

import { AppComponent } from './app.component';
import { BootstrapModule } from './common/ux/bootstrap.module';
import { HomeComponent } from './home/components/home.component';
import { NavigationComponent } from './navigation/components/navigation.component';
import { EmploymentContractCalculationService } from './home/services/employmentContractCalculation.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent
  ],
  imports: [
    AppRoutingModule,
    BootstrapModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    UiSwitchModule
  ],
  providers: [EmploymentContractCalculationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
