import { Component, OnInit, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PedidoIntroducaoService } from '../pedido-introducao.service';
import { JogadorDto } from '../jogador';
import { JogadorService } from '../jogador.service';
import { PedidoLigacaoDto } from '../pedidoLigacao';
import { PedidoLigacaoService } from '../pedido-ligacao.service';

@Component({
  selector: 'app-pedidos-ligacao',
  templateUrl: './pedidos-ligacao.component.html',
  styleUrls: ['./pedidos-ligacao.component.css']
})
export class PedidosLigacaoComponent implements OnInit {
  pedidosIntroducao: PedidoLigacaoDto[] = [];

  pedidosligacao : PedidoLigacaoDto[] = [];

  displayedColumns: string[] = ['jogadorOrig', 'jogadorObj', 'msgObjetivo', 'estadoPedido', 'actions'];

  pedido : PedidoLigacaoDto;

  jogadorAtivo: JogadorDto;
  jogadorOrig : JogadorDto;
  jogadorObj: JogadorDto;

  constructor(private pedidoLigacaoService: PedidoLigacaoService,
    private jogadorService: JogadorService,
    public snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.jogadorAtivo = history.state.data;
    this.getPedidosIntroducaoJogador();
  }

  isOrigem(pedidoIntroducao: PedidoLigacaoDto): boolean {
    if (pedidoIntroducao.jogadorId == this.jogadorAtivo.id) {
      return true;
    } else {
      return false;
    }
  }

  isObjetivo(pedidoIntroducao: PedidoLigacaoDto): boolean {
    if (pedidoIntroducao.jogadorObjetivoId == this.jogadorAtivo.id) {
      return true;
    } else {
      return false;
    }
  }

  getPedidosIntroducaoJogador(){
    this.jogadorService.GetPedidosLigacaoJogador(this.jogadorAtivo.id).subscribe( data => {
      if(data){
        this.pedidosutillizador(data);
      };
    });
  }

  pedidosutillizador(data : any[]){
    this.pedidosligacao = data;
    this.pedidosligacao.forEach(element => {
      if(element.estadoPedido == "0"){
        element.estadoPedido = "pendente";
      }
      if(element.estadoPedido == "1"){
        element.estadoPedido = "aceitado";
      }
      if(element.estadoPedido == "2"){
        element.estadoPedido = "recusado";
      }
    });
    this.getJogadorAById();
    this.getJogadorBById();

  }
  getJogadorAById() {
    this.pedidosligacao.forEach(element => {
     this.jogadorService.GetJogador(element.jogadorId)
        .subscribe(data => {
         if (data) {
            this.callbackJogadorA(data);
            element.jogadorNome = data.nome;
          }
        }
        )
    });
  }

callbackJogadorA(jogador: any) {
  this.jogadorOrig = jogador;
}

getJogadorBById() {
  this.pedidosligacao.forEach(element => {
    this.jogadorService.GetJogador(element.jogadorObjetivoId)
      .subscribe(data => {
        if (data) {
          this.callbackJogadorB(data);
          element.jogadorObjetivoNome = data.nome;
        }
      }
      )
  });
}

callbackJogadorB(jogador: any) {
  this.jogadorObj = jogador;
}

aceitarPedido(pedido : PedidoLigacaoDto){
  pedido.estadoPedido = "aceitado";
  this.pedidoLigacaoService.updatePedidoLigacao(pedido).subscribe();
}

rejeitarPedido(pedido : PedidoLigacaoDto){
  pedido.estadoPedido = "recusado";
  this.pedidoLigacaoService.updatePedidoLigacao(pedido).subscribe();
}
}
