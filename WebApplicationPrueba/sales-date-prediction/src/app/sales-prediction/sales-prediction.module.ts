import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SalesPredictionListComponent } from './sales-prediction-list/sales-prediction-list.component';

const routes: Routes = [
  { path: '', component: SalesPredictionListComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class SalesPredictionModule {}
