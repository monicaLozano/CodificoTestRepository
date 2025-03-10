import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesService } from '../../services/sales.service';

@Component({
  selector: 'app-shippers-list',
  standalone: true,
  imports: [CommonModule], // ⬅️ Agregar CommonModule aquí
  templateUrl: './shippers-list.component.html',
  styleUrls: ['./shippers-list.component.css']
})
export class ShippersListComponent implements OnInit {
  shippers: any[] = [];

  constructor(private salesService: SalesService) {}

  ngOnInit() {
    this.salesService.getShippers().subscribe({
      next: (data) => {
        console.log('Shippers recibidos:', data);
        this.shippers = data;
      },
      error: (err) => console.error('Error al obtener shippers', err)
    });
  }
}
