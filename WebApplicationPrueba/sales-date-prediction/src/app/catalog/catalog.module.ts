import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogRoutingModule } from './catalog-routing.module';

@NgModule({
  imports: [
    CommonModule,
    CatalogRoutingModule // ✅ Asegurar que las rutas de catalog se cargan correctamente
  ]
})
export class CatalogModule {}
