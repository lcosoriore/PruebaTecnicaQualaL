import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { SucursalesComponent } from './sucursales/sucursales.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MonedaComponent } from './moneda/moneda.component';
import { HttpClientModule } from '@angular/common/http';
import {DataTablesModule } from 'angular-datatables'

//const router: Routes = [
//  {
//    path: 'sucursales',
//    component: SucursalesComponent
//  }
//]
const routes = [
  //{ path: '', redirectTo: '/monedas', pathMatch: 'full' },
  { path: 'moneda', component: MonedaComponent },
  { path: 'sucursales', component: SucursalesComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    SucursalesComponent,    
    MonedaComponent
    
  ],
  imports: [
    BrowserModule,
    DataTablesModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
    
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
