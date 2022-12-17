import { Component } from '@angular/core';
import { ISubscription } from 'src/app/shared/interfaces';
import { ApiService } from '../../api.service';
import { NewSubscriptionComponent } from '../new-subscription/new-subscription.component';

@Component({
  selector: 'app-subscription-list',
  templateUrl: './subscription-list.component.html',
  styleUrls: ['./subscription-list.component.scss']
})
export class SubscriptionListComponent {
  subscriptionList: ISubscription[] | null = null;
  errors: Error | null = null;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.loadSubscriptions().subscribe({
      next: (value: any) => {
        this.subscriptionList = value;
      },
      error: (err: Error) => {
        this.errors = err;
      }
    });
  }
}
