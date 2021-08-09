import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfertaClienteComponent } from './oferta-cliente.component';

describe('OfertaClienteComponent', () => {
  let component: OfertaClienteComponent;
  let fixture: ComponentFixture<OfertaClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OfertaClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OfertaClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
