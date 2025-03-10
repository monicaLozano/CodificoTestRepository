import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { ShippersListComponent } from './shippers-list/shippers-list.component';
import { ProductsListComponent } from './products-list/products-list.component';

const routes: Routes = [
  { path: 'employees', component: EmployeesListComponent },
  { path: 'shippers', component: ShippersListComponent },
  { path: 'products', component: ProductsListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogRoutingModule {}
