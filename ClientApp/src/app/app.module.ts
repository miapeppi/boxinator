import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginPage } from './login/pages/login/login.page';
import { RegisterPage } from './login/pages/register/register.page';
import { GuestPage } from './login/pages/guest/guest.page';
import { DashboardPage } from './shipment/pages/dashboard/dashboard.page';
import { MyShipmentsPage } from './shipment/pages/my-shipments/my-shipments.page';
import { NewShipmentPage } from './shipment/pages/new-shipment/new-shipment.page';
import { MyAccountPage } from './account/pages/my-account/my-account.page';
import { EditAccountPage } from './account/pages/edit-account/edit-account.page';
import { MenuPage } from './navigation/pages/menu/menu.page';
import { CountrySettingsPage } from './admin/pages/country-settings/country-settings.page';


@NgModule({
  declarations: [
    AppComponent,
    LoginPage,
    RegisterPage,
    GuestPage,
    DashboardPage,
    MyShipmentsPage,
    NewShipmentPage,
    MyAccountPage,
    EditAccountPage,
    MenuPage,
    CountrySettingsPage,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
