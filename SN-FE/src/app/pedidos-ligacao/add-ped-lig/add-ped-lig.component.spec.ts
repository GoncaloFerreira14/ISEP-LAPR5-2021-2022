import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPedLigComponent } from './add-ped-lig.component';

describe('AddPedLigComponent', () => {
  let component: AddPedLigComponent;
  let fixture: ComponentFixture<AddPedLigComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPedLigComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPedLigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
