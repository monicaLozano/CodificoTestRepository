import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesService } from '../../services/sales.service';

@Component({
  selector: 'app-products-list',
  standalone: true, // ✅ Standalone component
  imports: [CommonModule], // ✅ Agrega CommonModule aquí
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products: any[] = [];

  constructor(private salesService: SalesService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.salesService.getProducts().subscribe({
      next: data => this.products = data,
      error: err => console.error('Error al obtener productos:', err)
    });
  }
}
