import { TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { EstadoEmocionalDto } from './estadoEmocional';
import { EstadosEmocionaisService } from './estados-emocionais.service';

describe('EstadosEmocionaisService', () => {
  let service: EstadosEmocionaisService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EstadosEmocionaisService]
    });
    service = TestBed.inject(EstadosEmocionaisService);
  });

  it('can load instance', () => {
    expect(service).toBeTruthy();
  });
});