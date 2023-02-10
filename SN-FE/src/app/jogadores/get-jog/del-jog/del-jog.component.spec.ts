import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelJogComponent } from './del-jog.component';

describe('DelJogComponent', () => {
  let component: DelJogComponent;
  let fixture: ComponentFixture<DelJogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DelJogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DelJogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
