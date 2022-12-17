import { RouterModule, Routes } from "@angular/router";
import { SubscriptionListComponent } from "./subscription-list/subscription-list.component";

const routes: Routes = [
  {
    path: 'list',
    component: SubscriptionListComponent
  }
];

export const SubscriptionRoutingModule = RouterModule.forChild(routes);
