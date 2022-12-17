import { CurrencyPipe } from "@angular/common";

export interface IPrice {
  priceId: number,
  months?: number,
  amount: number,
  isDefaultPrice: boolean,
}
