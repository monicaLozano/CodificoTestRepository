// src/app/services/sales.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesService {
  private baseUrl = 'http://localhost:5171/api'; // Ajusta a la URL real de tu API

  constructor(private http: HttpClient) {}

  getSalesPrediction(): Observable<any> {
    return this.http.get(`${this.baseUrl}/Orders/SalesPrediction`);
  }

  getClientOrders(customerId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/Orders/ClientOrders/${customerId}`);
  }

  addNewOrder(orderData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Orders/NewOrder`, orderData);
  }

  // Métodos para obtener employees, shippers, products...
  getEmployees(): Observable<any> {
    return this.http.get(`${this.baseUrl}/Catalog/Employees`);
  }

  getShippers(): Observable<any> {
    return this.http.get(`${this.baseUrl}/Catalog/Shippers`);
  }

  getProducts(): Observable<any> {
    return this.http.get(`${this.baseUrl}/Catalog/Products`);
  }
}
