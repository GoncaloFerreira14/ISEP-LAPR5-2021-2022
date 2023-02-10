import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { PedidoIntroducaoService } from './pedido-introducao.service';

describe('PedidoIntroducaoService', () => {
  let service: PedidoIntroducaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [HttpClientTestingModule]});
    service = TestBed.inject(PedidoIntroducaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
