import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SalesService } from '../../services/sales.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-new-order',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent {
  model = {
    customerID: 1,
    empID: 0,
    shipperID: 0,
    shipName: '',
    shipAddress: '',
    shipCity: '',
    orderDate: '',
    requiredDate: '',
    shippedDate: '',
    freight: 0,
    shipCountry: '',
    productID: 0,
    unitPrice: 0,
    qty: 1,
    discount: 0
  };

  constructor(private salesService: SalesService) {}

  createOrder() {
    this.salesService.addNewOrder(this.model).subscribe({
      next: res => {
        alert('Orden creada correctamente');
      },
      error: err => console.error('Error al crear orden', err)
    });
  }
}
