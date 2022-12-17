import { Component, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ApiService } from 'src/app/api.service';
import { AuthService } from 'src/app/auth/auth.service';
import { IPrice } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-new-price',
  templateUrl: './new-price.component.html',
  styleUrls: ['./new-price.component.scss'],
})
export class NewPriceComponent {
  loggedIn = false;
  isFormInvalid = false;
  prices: IPrice[] | null = null;
  currentPrice: number | null = null;

  @ViewChild(NgForm, { static: true }) form!: ElementRef<HTMLInputElement>;

  constructor(
    private apiService: ApiService,
    private authService: AuthService
  ) {}

  radioChanged(form: NgForm) {
    if (form.value.isDefaultPrice === true) {
      form.controls['months'].setValue(null);
    }
  }

  priceHandler(form: NgForm): void {
    if (form.invalid) {
      this.isFormInvalid = true;
      return;
    }
    const { months, amount, isDefaultPrice } = form.value;

    this.apiService.createPrice(Number(amount), isDefaultPrice, months).subscribe(() => {
      window.location.reload();
    });
  }

  ngDoCheck(): void {
    this.loggedIn = this.authService.isLoggedIn;
  }
}
