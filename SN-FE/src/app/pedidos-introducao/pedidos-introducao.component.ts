import { Component, OnInit, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PedidoIntroducaoService } from '../pedido-introducao.service';
import { JogadorDto } from '../jogador';
import { JogadorService } from '../jogador.service';
import { PedidoIntroducaoDto } from '../pedidoIntroducao';

@Component({
  selector: 'app-pedidos-introducao',
  templateUrl: './pedidos-introducao.component.html',
  styleUrls: ['./pedidos-introducao.component.css']
})
export class PedidosIntroducaoComponent implements OnInit {

  pedidosIntroducao: PedidoIntroducaoDto[] = [];

  pedidosIntroducaoA: PedidoIntroducaoDto[] = [];

  displayedColumns: string[] = ['jogadorOrig', 'jogadorInterm', 'jogadorObj', 'msgIntermedio', 'msgObjetivo', 'estadoPedido', 'actions'];

  pedido: PedidoIntroducaoDto;

  jogadorAtivo: JogadorDto;
  jogadorOrig: JogadorDto;
  jogadorInterm: JogadorDto;
  jogadorObj: JogadorDto;

  constructor(private pedidoIntroducaoService: PedidoIntroducaoService,
    private jogadorService: JogadorService,
    public snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.jogadorAtivo = history.state.data;
    this.getPedidosIntroducaoJogador();
    //this.getPedidosIntroducao();
  }

  /* getPedidosIntroducao(): void {
    this.pedidoIntroducaoService.getPedidosIntroducaoOfUser(this.jogadorAtivo.id).subscribe(pedidosIntroducao => this.pedidosIntroducao = pedidosIntroducao);
  }

  //MELHORAR METODO
  getJogadorObjetivo(jogadorId: string): JogadorDto {
    this.jogadorService.GetJogador(jogadorId).subscribe(jogadorObj => this.jogadorObj = jogadorObj);
    return this.jogadorObj;
  } */
  getPedidosIntroducaoJogador() {
    this.jogadorService.GetPedidosIntroducaoJogador(this.jogadorAtivo.id).subscribe(data => {
      if (data) {
        this.pedidosutillizador(data);
      };
    });
  }

  pedidosutillizador(data: any[]) {
    this.pedidosIntroducaoA = data;
    this.pedidosIntroducaoA.forEach(element => {
      if (element.estadoPedido == "0") {
        element.estadoPedido = "pendente";
      }
      if (element.estadoPedido == "1") {
        element.estadoPedido = "aprovado";
      }
      if (element.estadoPedido == "2") {
        element.estadoPedido = "recusado";
      }
    });
    this.getJogadorAById();
    this.getJogadorBById();
    this.getJogadorCById();

  }
  
  getJogadorAById() {
    this.pedidosIntroducaoA.forEach(element => {
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
    this.pedidosIntroducaoA.forEach(element => {
      this.jogadorService.GetJogador(element.jogadorIntermedioId)
        .subscribe(data => {
          if (data) {
            this.callbackJogadorB(data);
            element.jogadorIntermedioNome = data.nome;
          }
        }
        )
    });
  }

  callbackJogadorB(jogador: any) {
    this.jogadorInterm = jogador;
  }

  getJogadorCById() {
    this.pedidosIntroducaoA.forEach(element => {
      this.jogadorService.GetJogador(element.jogadorObjetivoId)
        .subscribe(data => {
          if (data) {
            this.callbackJogadorC(data);
            element.jogadorObjetivoNome = data.nome;
          }
        }
        )
    });
  }

  callbackJogadorC(jogador: any) {
    this.jogadorObj = jogador;
  }

  isOrigem(pedidoIntroducao: PedidoIntroducaoDto): boolean {
    if (pedidoIntroducao.jogadorId == this.jogadorAtivo.id) {
      return true;
    } else {
      return false;
    }
  }

  isIntermedio(pedidoIntroducao: PedidoIntroducaoDto): boolean {
    if (pedidoIntroducao.jogadorIntermedioId == this.jogadorAtivo.id) {
      return true;
    } else {
      return false;
    }
  }

  isObjetivo(pedidoIntroducao: PedidoIntroducaoDto): boolean {
    if (pedidoIntroducao.jogadorObjetivoId == this.jogadorAtivo.id) {
      return true;
    } else {
      return false;
    }
  }

  aprovarPedido(pedidoIntroducao: PedidoIntroducaoDto): void {
    pedidoIntroducao.estadoPedido = 'aprovado';
    this.pedidoIntroducaoService.updatePedidoIntroducao(pedidoIntroducao).subscribe();
  }

  desaprovarPedido(pedidoIntroducao: PedidoIntroducaoDto): void {
    pedidoIntroducao.estadoPedido = 'recusado';
    this.pedidoIntroducaoService.updatePedidoIntroducao(pedidoIntroducao).subscribe();
  }

}
