import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippersListComponent } from './shippers-list.component';

describe('ShippersListComponent', () => {
  let component: ShippersListComponent;
  let fixture: ComponentFixture<ShippersListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShippersListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShippersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
