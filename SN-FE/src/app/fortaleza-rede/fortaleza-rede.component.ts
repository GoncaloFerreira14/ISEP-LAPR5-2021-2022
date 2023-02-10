import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JogadorDto } from '../jogador';
@Component({
  selector: 'app-fortaleza-rede',
  templateUrl: './fortaleza-rede.component.html',
  styleUrls: ['./fortaleza-rede.component.css']
})
export class FortalezaRedeComponent implements OnInit {

  jogador: JogadorDto;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.jogador = history.state.data;
    this.goToGetFortalezaRede();
  }

  goToGetFortalezaRede() {
    this.router.navigate(["/dashboard/get fortaleza rede"], { state: { data: this.jogador.id } });
  }

}
