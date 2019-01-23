import { Component, OnInit, NgModule } from '@angular/core';
//todo: sprobowac wyrzucic
import { BrowserModule } from '@angular/platform-browser'
 

@Component({
  selector: 'app-charts-test',
  template: `<fusioncharts
    width="100%" 
    height="450"
    type="stackedcolumn3d"
    dataFormat="json"
    [dataSource]=dataSource >
  </fusioncharts>
  `,
})
export class ChartsTestComponent {

  dataSource: Object;

  constructor() {
    
    this.dataSource = {
      chart: {
          "xAxisname": "Quarter",
          "yAxisName": "Expenditure (In PLN)",
          "numberPrefix": "",
          "numberSuffix": "",
          "baseFont": "Roboto",
          "baseFontSize": "14",
          "labelFontSize": "15",
          "captionFontSize": "20",
          "subCaptionFontSize": "16",
          "paletteColors": "#2c7fb2,#6cc184,#fed466",
          "bgColor": "#ffffff",
          "legendShadow": "0",
          "valueFontColor": "#ffffff",
          "showXAxisLine": "1",
          "xAxisLineColor": "#999999",
          "divlineColor": "#999999",
          "divLineIsDashed": "1",
          "showAlternateHGridColor": "0",
          "subcaptionFontBold": "0",
          "subcaptionFontSize": "14",
          "showHoverEffect": "1"
        },
        "categories": [{
          "category": [{
            "label": "Q1"
          }]
        }],
        "dataset": [{
          "seriesname": "Marketing",
          "data": [{
            "value": "121000"
          }]
        }, {
          "seriesname": "Management",
          "data": [{
            "value": "190000"
          }]
        }, {
          "seriesname": "Operations",
          "data": [{
            "value": "225000"
          }]
      }]
    }; // end of this.dataSource
  } // end of constructor
} // end of class ChartsTestComponent