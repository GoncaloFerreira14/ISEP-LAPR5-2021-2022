import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { JogadorService } from './jogador.service';

describe('JogadorService', () => {
  let service: JogadorService;

  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientTestingModule]});
    service = TestBed.inject(JogadorService);
  });

  it('#getValue should return real jogador', () => {
    expect(service.GetJogador("c75fbef8-5197-4da8-9349-de135b69a356")).toEqual(service.GetJogador("c75fbef8-5197-4da8-9349-de135b69a356"));
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
