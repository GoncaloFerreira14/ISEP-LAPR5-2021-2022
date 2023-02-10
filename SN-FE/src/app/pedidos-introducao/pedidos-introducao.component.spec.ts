import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { PedidosIntroducaoComponent } from './pedidos-introducao.component';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
describe('PedidosIntroducaoComponent', () => {
  let component: PedidosIntroducaoComponent;
  let fixture: ComponentFixture<PedidosIntroducaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,MatSnackBarModule],
      declarations: [ PedidosIntroducaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PedidosIntroducaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
