import { Routes } from '@angular/router';

export const appRoutes: Routes = [
  { path: '', redirectTo: 'sales-prediction', pathMatch: 'full' },
  {
    path: 'sales-prediction',
    loadChildren: () =>
      import('./sales-prediction/sales-prediction.module').then(m => m.SalesPredictionModule)
  },
  {
    path: 'orders',
    loadChildren: () =>
      import('./orders/orders.module').then(m => m.OrdersModule)
  },
  {
    path: 'catalog',
    loadChildren: () =>
      import('./catalog/catalog.module').then(m => m.CatalogModule) // ✅ Cargar catálogo
  }
];
