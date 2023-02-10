import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtilizadorNaoAutenticadoComponent } from './utilizador-nao-autenticado.component';

describe('UtilizadorNaoAutenticadoComponent', () => {
  let component: UtilizadorNaoAutenticadoComponent;
  let fixture: ComponentFixture<UtilizadorNaoAutenticadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UtilizadorNaoAutenticadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UtilizadorNaoAutenticadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
