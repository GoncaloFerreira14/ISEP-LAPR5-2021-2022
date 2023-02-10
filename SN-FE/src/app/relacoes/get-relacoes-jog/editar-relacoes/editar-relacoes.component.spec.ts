import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { EditarRelacoesComponent } from './editar-relacoes.component';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
describe('EditarRelacoesComponent', () => {
  let component: EditarRelacoesComponent;
  let fixture: ComponentFixture<EditarRelacoesComponent>;

  beforeEach(async () => {
    
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,MatSnackBarModule],
      declarations: [ EditarRelacoesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarRelacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
