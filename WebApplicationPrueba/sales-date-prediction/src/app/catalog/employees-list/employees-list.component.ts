import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesService } from '../../services/sales.service';

@Component({
  selector: 'app-employees-list',
  standalone: true, // ✅ Standalone component
  imports: [CommonModule],
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  employees: any[] = [];

  constructor(private salesService: SalesService) {}

  ngOnInit(): void {
    this.salesService.getEmployees().subscribe({
      next: (data) => {
        console.log('Employees recibidos:', data);
        this.employees = data;
      },
      error: (err) => console.error('Error al obtener Employees', err)
    });
  }
}
