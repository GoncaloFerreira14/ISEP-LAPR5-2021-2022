import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AmigosComunsComponent } from './amigos-comuns.component';

describe('AmigosComunsComponent', () => {
  let component: AmigosComunsComponent;
  let fixture: ComponentFixture<AmigosComunsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AmigosComunsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AmigosComunsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
