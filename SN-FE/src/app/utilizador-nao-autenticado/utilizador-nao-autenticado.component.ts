import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JogadorDto } from '../jogador';


@Component({
  selector: 'app-utilizador-nao-autenticado',
  templateUrl: './utilizador-nao-autenticado.component.html',
  styleUrls: ['./utilizador-nao-autenticado.component.css']
})
export class UtilizadorNaoAutenticadoComponent implements OnInit {
  jogador: String;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.jogador = history.state.data;
    this.goToGetFortalezaRede();
  }

  goToGetFortalezaRede() {
    this.router.navigate(["/nao_autenticado/fortaleza_rede"], { state: { data: this.jogador } });
  }
}