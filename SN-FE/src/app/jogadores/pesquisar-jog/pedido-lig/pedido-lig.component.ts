import { Component, OnInit } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { FormBuilder } from '@angular/forms';
import { JogadorDto } from 'src/app/jogador';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pedido-lig',
  templateUrl: './pedido-lig.component.html',
  styleUrls: ['./pedido-lig.component.css']
})
export class PedidoLigComponent implements OnInit {

  jogadorinicialId : String;
  pesquisados: JogadorDto[] = [];

  constructor(private jogadorService: JogadorService, private router: Router ) { }

  ngOnInit(): void {
    this.getSugestoes();
    this.jogadorinicialId=history.state.data.id;
  }

  getSugestoes(): void {
    this.jogadorService.PesquisarJogadores(history.state.data.id,history.state.data.pesquisa).subscribe(pesquisados => this.pesquisados = pesquisados);
  }
  adicionar(jogador: JogadorDto) : void{
    this.router.navigate(["/dashboard/realizar pedido"], {state : {data : jogador,data2 : this.jogadorinicialId}});
  }

}
