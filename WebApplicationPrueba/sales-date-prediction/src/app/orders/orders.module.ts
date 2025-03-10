import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { NewOrderComponent } from './new-order/new-order.component';

const routes: Routes = [
  { path: '', component: OrdersListComponent },
  { path: 'new', component: NewOrderComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    OrdersListComponent, // ✅ Importar el componente standalone
    NewOrderComponent // ✅ Importar el componente standalone
  ]
})
export class OrdersModule {}
