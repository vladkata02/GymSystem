import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewPriceComponent } from './new-price/new-price.component';
import { PriceListComponent } from './price-list/price-list.component';
import { PriceRoutingModule } from './prices-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    NewPriceComponent,
    PriceListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PriceRoutingModule
  ]
})
export class PricesModule { }
