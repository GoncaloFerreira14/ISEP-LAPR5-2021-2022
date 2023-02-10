import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetFortalezaRedeComponent } from './get-fortaleza-rede.component';

describe('GetFortalezaRedeComponent', () => {
  let component: GetFortalezaRedeComponent;
  let fixture: ComponentFixture<GetFortalezaRedeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetFortalezaRedeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetFortalezaRedeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
