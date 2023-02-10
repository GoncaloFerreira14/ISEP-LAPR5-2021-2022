import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstadosEmocionaisComponent } from './estados-emocionais.component';

describe('EstadosEmocionaisComponent', () => {
  let component: EstadosEmocionaisComponent;
  let fixture: ComponentFixture<EstadosEmocionaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstadosEmocionaisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstadosEmocionaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
