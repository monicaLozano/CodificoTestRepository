import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesPredictionListComponent } from './sales-prediction-list.component';

describe('SalesPredictionListComponent', () => {
  let component: SalesPredictionListComponent;
  let fixture: ComponentFixture<SalesPredictionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesPredictionListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalesPredictionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
