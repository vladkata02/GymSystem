import { RouterModule, Routes } from '@angular/router';
import { PriceListComponent } from './price-list/price-list.component';

const routes: Routes = [
  {
    path: 'list',
    component: PriceListComponent,
    data: {
      title: 'Prices',
      loginRequired: true,
    },
  },
];

export const PriceRoutingModule = RouterModule.forChild(routes);
