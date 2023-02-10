import { Component, OnInit } from '@angular/core';
import { JogadorService } from '../jogador.service';
import { JogadorDto } from '../jogador';
import { RelacaoService } from '../relacao.service';
import { RelacaoDto } from '../relacao';

@Component({
  selector: 'app-amigos-comuns',
  templateUrl: './amigos-comuns.component.html',
  styleUrls: ['./amigos-comuns.component.css']
})
export class AmigosComunsComponent implements OnInit {

  jogador  : JogadorDto

  input : string

  amigosJog1 : RelacaoDto[] = []

  amigosJog2 : RelacaoDto[] = []

  jogadores : string[] = []

  jogadoresAux : string[] = []

  displayedColumns: string[] = ['nome'];
	dataSource = this.jogadores;

  constructor(private relacoesService : RelacaoService, private jogService : JogadorService) { }

  ngOnInit(): void {
    this.jogador = history.state.data;
  }


  async getAmigosComuns() : Promise<void>{

    this.input = (document.getElementById("Input")  as HTMLInputElement).value;


    this.jogService.GetJogadorByEmail(this.input).subscribe(data =>{
      this.jogService.GetAllRelacoesJogador(data.id).subscribe(data =>{
        this.amigosJog1 = data;
      })
    })

    this.jogService.GetAllRelacoesJogador(this.jogador.id).subscribe(data =>{
      this.amigosJog2 = data;
    });

    await new Promise(f => setTimeout(f,1000));

    this.amigosJog1.forEach(a1 => {
      this.amigosJog2.forEach(a2 => {
        if(a1.jogadorAmigoId == a2.jogadorAmigoId && this.jogadores.includes(a1.jogadorAmigoId) == false){
          this.jogadoresAux.push(a1.jogadorAmigoId);
        }
      })
    });

    this.jogadoresAux.forEach(element => {
      this.jogService.GetJogador(element).subscribe(data =>{
        this.jogadores.push(data.email);
      })
    });

    this.dataSource = this.jogadores;

  }

}
