import { Component, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ApiService } from 'src/app/api.service';
import { AuthService } from 'src/app/auth/auth.service';
import { IPrice } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-new-subscription',
  templateUrl: './new-subscription.component.html',
  styleUrls: ['./new-subscription.component.scss'],
})
export class NewSubscriptionComponent {

  loggedIn = false;
  isFormInvalid = false;
  prices: IPrice[] | null = null;
  currentPrice: number | null = null;
  
  @ViewChild(NgForm, { static: true }) form!: ElementRef<HTMLInputElement>;
  
  constructor(
    private apiService: ApiService,
    private authService: AuthService
    ) {}
    
    ngOnInit(): void {
      this.apiService.getAllPrices().subscribe({
        next: (value: IPrice[]) => {
          this.prices = value;
        }
      })
    }

    getPrice(form: NgForm){
        form.value.moneyPaid = this.prices?.find(e => e.months === form.value.months)?.amount;
        this.currentPrice = form.value.moneyPaid;
    }
    
    subscriptionHandler(form: NgForm): void {
      if (form.invalid) {
        this.isFormInvalid = true;
      return;
    }
    const { months, moneyPaid } = form.value;

      this.apiService.createSubscription(months, moneyPaid).subscribe(() => {
        window.location.reload();
      });
  }

  ngDoCheck(): void {
    this.loggedIn = this.authService.isLoggedIn;
  }
}
