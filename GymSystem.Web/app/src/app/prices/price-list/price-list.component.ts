import { Component } from '@angular/core';
import { IPrice } from 'src/app/shared/interfaces';
import { ApiService } from '../../api.service';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.scss']
})
export class PriceListComponent {
  priceList: IPrice[] | null = null;
  errors: Error | null = null;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getAllPrices().subscribe({
      next: (value: any) => {
        this.priceList = value;
      },
      error: (err: Error) => {
        this.errors = err;
      }
    });
  }
}
