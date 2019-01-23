import { AppRoutingModule } from './app-routing.module';
import { BootstrapModule } from './common/ux/bootstrap.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { FusionChartsModule } from 'angular-fusioncharts';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { UiSwitchModule } from 'angular2-ui-switch';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/components/home.component';
import { EmploymentContractCalculationService } from './home/services/employmentContractCalculation.service';
import { NavigationComponent } from './navigation/components/navigation.component';

import * as FusionCharts from 'fusioncharts';
import * as Charts from 'fusioncharts/fusioncharts.charts';
import * as FusionTheme from 'fusioncharts/themes/fusioncharts.theme.fusion';
FusionChartsModule.fcRoot(FusionCharts, Charts, FusionTheme);
import { ChartsTestComponent } from './charts-test/charts-test.component';
 
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent,
    ChartsTestComponent
  ],
  imports: [
    AppRoutingModule,
    BootstrapModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    UiSwitchModule,
    FusionChartsModule
  ],
  providers: [EmploymentContractCalculationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
