import { RouterModule, Routes } from "@angular/router";
import { SubscriptionListComponent } from "./subscription-list/subscription-list.component";

const routes: Routes = [
  {
    path: 'list',
    component: SubscriptionListComponent,
    data: {
      title: 'Subscriptions',
      loginRequired: true,
    },
  }
];

export const SubscriptionRoutingModule = RouterModule.forChild(routes);
