import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { RelacaoService } from './relacao.service';

describe('RelacaoService', () => {
  let service: RelacaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [HttpClientTestingModule]});
    service = TestBed.inject(RelacaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
