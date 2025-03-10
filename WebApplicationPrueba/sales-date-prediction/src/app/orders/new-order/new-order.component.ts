import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; // ✅ Importamos FormsModule aquí
import { SalesService } from '../../services/sales.service';
import { CommonModule } from '@angular/common'; // ✅ También importar CommonModule

@Component({
  selector: 'app-new-order',
  standalone: true, // ✅ Confirma que el componente es standalone
  imports: [CommonModule, FormsModule],
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent {
  // Modelo para el formulario de nueva orden
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
    // Establecer fechas si se requieren
    this.model.orderDate = new Date().toISOString();
    this.model.requiredDate = new Date().toISOString();
    this.model.shippedDate = new Date().toISOString();

    this.salesService.addNewOrder(this.model).subscribe({
      next: res => {
        alert('Orden creada correctamente');
      },
      error: err => console.error('Error al crear orden', err)
    });
  }
}
