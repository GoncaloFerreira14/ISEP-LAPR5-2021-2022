import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms'
import { JogadorDto } from '../jogador';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {


  jogador : JogadorDto;

  pesqForm = this.formBuilder.group({
    id: history.state.data.id,
    pesquisa:"",
  });



  constructor(private formBuilder: FormBuilder, private router : Router) { }

  ngOnInit(): void {
    this.jogador = history.state.data;
    console.log(this.jogador);
  }

  goToRelacoes(){
    this.router.navigate(["dashboard/relacoes"], {state : {data : this.jogador}});
  }

  goToLogin(){
    this.router.navigate(["/login"]);
  }

  goToGetEstado(){
    this.router.navigate(["/dashboard/get estado jogador"], {state : {data : this.jogador.id}});
  }

  goToSugestoes(){
    this.router.navigate(["dashboard/sugerir jogadores"], {state : {data : this.jogador}});
  }

  goToPedidos(){
    this.router.navigate(["dashboard/pedidos"], {state : {data : this.jogador}});
  }

  goToAddPedidosIntroducao(){
    this.router.navigate(["dashboard/add pedido introducao"], {state : {data : this.jogador}});
  }

  goToRede(){
    this.router.navigate(["dashboard/rede"], {state : {data : this.jogador}});
  }

  goToGetJogador(){
    this.router.navigate(["dashboard/get perfil proprio"], {state : {data : this.jogador}});
  }
  goToPosts(){
    this.router.navigate(["dashboard/posts"], {state : {data : this.jogador}});
  }
  goToPesquisarJogadores(){
    this.router.navigate(["dashboard/pesquisar"], {state : {data : this.jogador}});
  }
  goToAlgoritmos(){
    this.router.navigate(["dashboard/algoritmos"], {state : {data : this.jogador}});
  }
  goToEstatisticas() {
    this.router.navigate(["dashboard/estatisticas"], { state: { data: this.jogador } });
  }
  onSubmit() : void {
    this.router.navigate(["/dashboard/pedir ligacao"], {state : {data : this.pesqForm.value}});
    this.pesqForm.reset();
  }

  goToAmigosComuns(){
    this.router.navigate(["dashboard/amigoscomuns"], { state: { data: this.jogador } });
  }
}
