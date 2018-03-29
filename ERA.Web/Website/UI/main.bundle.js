webpackJsonp(["main"],{

/***/ "../../../../../src/$$_lazy_route_resource lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../../../../../src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "../../../../../src/app/app-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var routes = [];
var AppRoutingModule = (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* RouterModule */].forRoot(routes)],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* RouterModule */]]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "../../../../../src/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<app-home></app-home>\r\n<router-outlet></router-outlet>\r\n"

/***/ }),

/***/ "../../../../../src/app/app.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = (function () {
    function AppComponent() {
        this.title = 'app';
    }
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-root',
            template: __webpack_require__("../../../../../src/app/app.component.html"),
            styles: [__webpack_require__("../../../../../src/app/app.component.scss")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../../../../../src/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__app_routing_module__ = __webpack_require__("../../../../../src/app/app-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_animations__ = __webpack_require__("../../../platform-browser/esm5/animations.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_angular2_ui_switch__ = __webpack_require__("../../../../angular2-ui-switch/dist/index.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_angular2_ui_switch___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_6_angular2_ui_switch__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__app_component__ = __webpack_require__("../../../../../src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__common_ux_bootstrap_module__ = __webpack_require__("../../../../../src/app/common/ux/bootstrap.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__home_components_home_component__ = __webpack_require__("../../../../../src/app/home/components/home.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__navigation_components_navigation_component__ = __webpack_require__("../../../../../src/app/navigation/components/navigation.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__home_services_employmentContractCalculation_service__ = __webpack_require__("../../../../../src/app/home/services/employmentContractCalculation.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_5__angular_core__["NgModule"])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_7__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_9__home_components_home_component__["a" /* HomeComponent */],
                __WEBPACK_IMPORTED_MODULE_10__navigation_components_navigation_component__["a" /* NavigationComponent */]
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_0__app_routing_module__["a" /* AppRoutingModule */],
                __WEBPACK_IMPORTED_MODULE_8__common_ux_bootstrap_module__["a" /* BootstrapModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_platform_browser__["a" /* BrowserModule */],
                __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_animations__["a" /* BrowserAnimationsModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_4__angular_http__["b" /* HttpModule */],
                __WEBPACK_IMPORTED_MODULE_6_angular2_ui_switch__["UiSwitchModule"]
            ],
            providers: [__WEBPACK_IMPORTED_MODULE_11__home_services_employmentContractCalculation_service__["a" /* EmploymentContractCalculationService */]],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_7__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../../../../../src/app/common/ux/bootstrap.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BootstrapModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_ngx_bootstrap__ = __webpack_require__("../../../../ngx-bootstrap/index.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var BootstrapModule = (function () {
    function BootstrapModule() {
    }
    BootstrapModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            declarations: [__WEBPACK_IMPORTED_MODULE_1_ngx_bootstrap__["a" /* CollapseDirective */]],
            imports: [],
            exports: [__WEBPACK_IMPORTED_MODULE_1_ngx_bootstrap__["a" /* CollapseDirective */]]
        })
    ], BootstrapModule);
    return BootstrapModule;
}());



/***/ }),

/***/ "../../../../../src/app/home/components/home.component.html":
/***/ (function(module, exports) {

module.exports = "<app-navigation></app-navigation>\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h4>Wybierz stosunek pracy</h4>\r\n        <br>\r\n\r\n        <div class-=\"container\">\r\n            \r\n            <div class=\"row\">\r\n                <div class=\"col-1\">\r\n                    <label for=\"enableEmploymentCalculation\" class=\"\">Umowa stała</label>\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    <ui-switch id=\"enableEmploymentCalculation\" [(ngModel)]=\"enableEmploymentCalculation\" size=\"small\" disabled></ui-switch>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"w-100\"></div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-1\">\r\n                    <label for=\"enableContractCalculation\" class=\"\">Umowa B2B</label>\r\n                </div>\r\n                <div class=\"col-1\">\r\n                    <ui-switch id=\"enableContractCalculation\" [(ngModel)]=\"enableContractCalculation\" size=\"small\" disabled></ui-switch>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"card\" (keydown.enter)=\"calculate()\">\r\n    <div class=\"card-body\">\r\n        <h4>Wprowadź informacje o zarobkach</h4>\r\n        <br>\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"salaryBrutto\">Miesięczna pensja brutto (PLN)</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"salaryBrutto\" placeholder=\"brutto\" [(ngModel)]=\"salaryBrutto\" required> \r\n        </div>\r\n    </div>\r\n\r\n    <button id=\"calculateBtn\" type=\"button\" class=\"btn btn-outline-primary btn-lg has-spinner\" (click)=\"calculate(); onClick()\"\r\n        [class.active]=\"wasCalculateClicked\">\r\n        <span class=\"spinner\" [style.display]=\"isLoading ? 'inline' : 'none'\">\r\n            <i class=\"icon-spin icon-refresh icon-large\"></i>\r\n        </span>\r\n        <span [style.display]=\"isLoading ? 'none' : 'inline'\">\r\n            Sprawdź\r\n        </span>\r\n    </button>\r\n\r\n    <br>\r\n    <div class=\"card-body\">\r\n        <label for=\"salaryNetto\">Miesięczna pensja netto (PLN)</label>\r\n        <h1 *ngIf=\"calculationResult\" id=\"salaryNetto\">{{ calculationResult.SalaryNetto }} </h1>\r\n        <br>\r\n        <div *ngIf=\"calculationResult\"> {{ calculationResult | json }} </div>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/home/components/home.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".example-margin {\n  margin: 0 10px; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/home/components/home.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HomeComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Rx__ = __webpack_require__("../../../../rxjs/_esm5/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_employmentContractCalculation_service__ = __webpack_require__("../../../../../src/app/home/services/employmentContractCalculation.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HomeComponent = (function () {
    function HomeComponent(service) {
        this.service = service;
        this.calculationResult = '';
        this.isLoading = false;
        this.wasCalculateClicked = false;
        this.enableEmploymentCalculation = true;
        this.enableContractCalculation = false;
    }
    HomeComponent.prototype.ngOnInit = function () {
    };
    HomeComponent.prototype.calculate = function () {
        var _this = this;
        this.isLoading = true;
        this.service.scheduleCalculation(this.salaryBrutto)
            .subscribe(function (response) {
            console.log(response);
            _this.calculationResult = response;
            //JSON.stringify(response)
            _this.isLoading = false;
        }, function (error) {
            alert('error');
            _this.isLoading = false;
        });
        // setTimeout(() => {
        //   this.calculationResult = this.salaryBrutto.toString();
        //   this.isSpinnerVisible = false;
        // }, 2000);
    };
    HomeComponent.prototype.onClick = function () {
        this.wasCalculateClicked = !this.wasCalculateClicked;
    };
    HomeComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-home',
            template: __webpack_require__("../../../../../src/app/home/components/home.component.html"),
            styles: [__webpack_require__("../../../../../src/app/home/components/home.component.scss")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__services_employmentContractCalculation_service__["a" /* EmploymentContractCalculationService */]])
    ], HomeComponent);
    return HomeComponent;
}());



/***/ }),

/***/ "../../../../../src/app/home/services/employmentContractCalculation.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return EmploymentContractCalculationService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Rx__ = __webpack_require__("../../../../rxjs/_esm5/Rx.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var EmploymentContractCalculationService = (function () {
    function EmploymentContractCalculationService(http) {
        this.http = http;
        this.baseUrl = 'http://localhost:18021/api/ScheduleEmploymentContractCalculation';
    }
    EmploymentContractCalculationService.prototype.scheduleCalculation = function (salaryBrutto) {
        return this.http.get(this.baseUrl + "?salaryBrutto=" + salaryBrutto)
            .map(function (res) { return res.json(); })
            .catch(function (error) {
            console.log(error);
            return __WEBPACK_IMPORTED_MODULE_2_rxjs_Observable__["a" /* Observable */].throw(error);
        });
    };
    EmploymentContractCalculationService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["a" /* Http */]])
    ], EmploymentContractCalculationService);
    return EmploymentContractCalculationService;
}());



/***/ }),

/***/ "../../../../../src/app/navigation/components/navigation.component.html":
/***/ (function(module, exports) {

module.exports = "<nav class=\"navbar navbar-toggleable-sm navbar-expand-lg navbar-dark\" style=\"background-color: #4776db;\">\r\n    \r\n    <a class=\"navbar-brand\" href=\"#\">Asystent wyboru stosunku pracy</a>\r\n\r\n    <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#navbarContent\" aria-controls=\"navbarNavAltMarkup\"\r\n        aria-expanded=\"false\" aria-label=\"Toggle navbar\" (click)=\"isCollapsed = !isCollapsed\">\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    </button>\r\n    \r\n    <!-- <div class=\"collapse navbar-collapse\" id=\"navbarNavAltMarkup\" [collapse]=\"isCollapsed\">\r\n        <div class=\"navbar-nav\">\r\n            <a class=\"nav-item nav-link active\" href=\"#\">Start\r\n                <span class=\"sr-only\">(current)</span>\r\n            </a>\r\n            <a class=\"nav-item nav-link\" href=\"#\">Features</a>\r\n            <a class=\"nav-item nav-link\" href=\"#\">Pricing</a>\r\n            <a class=\"nav-item nav-link disabled\" href=\"#\">Disabled</a>\r\n        </div>\r\n    </div> -->\r\n\r\n</nav>"

/***/ }),

/***/ "../../../../../src/app/navigation/components/navigation.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".example-spacer {\n  -webkit-box-flex: 1;\n      -ms-flex: 1 1 auto;\n          flex: 1 1 auto; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/navigation/components/navigation.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return NavigationComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var NavigationComponent = (function () {
    function NavigationComponent() {
        this.isCollapsed = false;
    }
    NavigationComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-navigation',
            template: __webpack_require__("../../../../../src/app/navigation/components/navigation.component.html"),
            styles: [__webpack_require__("../../../../../src/app/navigation/components/navigation.component.scss")]
        })
    ], NavigationComponent);
    return NavigationComponent;
}());



/***/ }),

/***/ "../../../../../src/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
var environment = {
    production: false
};


/***/ }),

/***/ "../../../../../src/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/esm5/platform-browser-dynamic.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("../../../../../src/app/app.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");




if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["enableProdMode"])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map