import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesService } from '../../services/sales.service';

@Component({
  selector: 'app-orders-list',
  standalone: true,  // ✅ Confirmamos que es standalone
  imports: [CommonModule],
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  orders: any[] = [];

  // Un ejemplo de CustomerID hardcodeado; puedes ajustarlo 
  // o leerlo de un input, query param, etc.
  customerId: number = 1;

  constructor(private salesService: SalesService) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders(): void {
    this.salesService.getClientOrders(this.customerId).subscribe({
      next: data => this.orders = data,
      error: err => console.error('Error al obtener órdenes', err)
    });
  }
}
