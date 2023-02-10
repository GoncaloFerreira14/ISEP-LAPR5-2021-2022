import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { PedidoLigacaoService } from './pedido-ligacao.service';

describe('PedidoLigacaoService', () => {
  let service: PedidoLigacaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientTestingModule],});
    service = TestBed.inject(PedidoLigacaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
