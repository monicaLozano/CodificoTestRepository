import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // ✅ Importamos CommonModule
import { SalesService } from '../../services/sales.service';

@Component({
  selector: 'app-sales-prediction-list',
  standalone: true,  // ✅ Confirmamos que el componente es standalone
  imports: [CommonModule],  // ✅ Agregamos CommonModule para habilitar *ngFor y pipes
  templateUrl: './sales-prediction-list.component.html',
  styleUrls: ['./sales-prediction-list.component.css']
})
export class SalesPredictionListComponent implements OnInit {
  predictions: any[] = [];

  constructor(private salesService: SalesService) {}

  ngOnInit(): void {
    this.loadPredictions();
  }

  loadPredictions(): void {
    this.salesService.getSalesPrediction().subscribe({
      next: data => this.predictions = data,
      error: err => console.error('Error cargando predicciones', err)
    });
  }
}
