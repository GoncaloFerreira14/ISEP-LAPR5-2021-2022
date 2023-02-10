import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JogadorDto } from '../jogador';

@Component({
  selector: 'app-relacoes',
  templateUrl: './relacoes.component.html',
  styleUrls: ['./relacoes.component.css']
})
export class RelacoesComponent implements OnInit {

  jogador: JogadorDto;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.jogador = history.state.data;
    this.goToGetRelacoes();
  }

  goToGetRelacoes() {
    this.router.navigate(["/dashboard/get relacoes jogador"], { state: { data: this.jogador.id } });
  }

}
