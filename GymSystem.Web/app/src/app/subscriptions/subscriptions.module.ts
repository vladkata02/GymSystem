import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewSubscriptionComponent } from './new-subscription/new-subscription.component';
import { SubscriptionListComponent } from './subscription-list/subscription-list.component';
import { SubscriptionRoutingModule } from './subscriptions-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    NewSubscriptionComponent,
    SubscriptionListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    SubscriptionRoutingModule
  ],
  exports: [
    SubscriptionListComponent
  ],
})
export class SubscriptionsModule { }
