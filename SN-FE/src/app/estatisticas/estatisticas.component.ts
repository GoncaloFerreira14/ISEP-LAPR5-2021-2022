import { Component, OnInit, ViewChild } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { TagService } from '../tag.service';
import { RelacaoService } from 'src/app/relacao.service';
import { RelacaoDto } from 'src/app/relacao';
import { map, Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { JogadorDto } from 'src/app/jogador';
import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y/input-modality/input-modality-detector';
import {MatTableModule} from '@angular/material/table';
import { CloudData, CloudOptions, TagCloudComponent } from 'angular-tag-cloud-module';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RelacoesListNivelDto } from '../relacoesListNivel';
import { leaderboardFortaleza } from '../leaderboardFortaleza';
import { leaderboardDimensao } from '../leaderboardDimensao';



@Component({
  selector: 'app-estatisticas',
  templateUrl: './estatisticas.component.html',
  styleUrls: ['./estatisticas.component.css']
})
export class EstatisticasComponent implements OnInit {
  @ViewChild(TagCloudComponent, {static: true})

  tagCloudComponent!: TagCloudComponent;

  mapauxDim : Map<string,number>;

  mapauxFor : Map<string,number>;

  resFortaleza : Array<leaderboardFortaleza>;

  resDimensao : Array<leaderboardDimensao>;

  data : CloudData[] = [
    {
      text: '',
      weight: 0
    }
  ];

  dataJogador : CloudData[] = [
    {
      text: '',
      weight: 0
    }
  ];

  dataTagsJogadores : CloudData[] = [
    {
      text: '',
      weight: 0
    }
  ];

  dataTagsRelacoes : CloudData[] = [
    {
      text: '',
      weight: 0
    }
  ];

  dataTagsRelacoesJog : CloudData[] = [
    {
      text: '',
      weight: 0
    }
  ];

  relacoesListNivel: RelacoesListNivelDto[] = [];

  amigos3Nivel : number;
  
  options: CloudOptions = {
    // if width is between 0 and 1 it will be set to the width of the upper element multiplied by the value
    width: 1000,
    // if height is between 0 and 1 it will be set to the height of the upper element multiplied by the value
    height: 400,
    overflow: false,
  };

  relacoesList: RelacaoDto[] = [];

	//dataSource = this.mapGeral;

  selected = '';

  selectedLeader = '';
	
	jogadorId: string;
  fortalezaRede : number = 0;
	empData : any[];

  
	

	constructor(private JogadorService: JogadorService,private snackBar: MatSnackBar, private relacaoService: RelacaoService, private tagService : TagService, private router: Router) {
    this.mapauxDim = new Map();
    this.mapauxFor = new Map();
   }

	ngOnInit(): void {
		this.jogadorId = history.state.data.id;
		this.getFortalezaRede();
    this.tamanhoRede3Nivel();
	}


  changeSelected(): void{
    if(this.selected == 'jogadores'){
      this.tagCloudJogadores();
      this.data = this.dataTagsJogadores;
    }
    if(this.selected == 'dataTagsRelacoes'){
      this.tagCloudRelacoes();
      this.data = this.dataTagsRelacoes;
    }
    if(this.selected == 'jogador'){
      this.tagCloudJogador();
      this.data = this.dataJogador;
    }
    if(this.selected == 'relacoesjog'){
      this.tagCloudRelacoesJogador();
      this.data = this.dataTagsRelacoesJog;
    }
  }

  changeSelectedLeader(): void{
    if(this.selectedLeader == 'dimensao'){
      this.resDimensao = [];
      this.resFortaleza = [];
      this.leaderboardDimensao();

    }
    if(this.selectedLeader == 'fortaleza'){
      this.resDimensao = [];
      this.resFortaleza = [];
      this.leaderboardFortaleza();
    }
  }


	
	getFortalezaRede(): void {
		this.JogadorService.GetAllRelacoesJogador(this.jogadorId)
			.subscribe(data => {
				if (data) {
					for (let i = 0; i < data.length; i++){
						this.fortalezaRede = this.fortalezaRede + data[i].forcaLigacao;
						this.empData =[this.fortalezaRede];
					}
					
				}
			});
	}

  async tagCloudJogadores() : Promise<void>{

    this.dataTagsJogadores = [
      {
        text: '',
        weight: 0
      }
    ];

    let mapTagsJogadores = new Map<string,number>();
    this.JogadorService.GetJogadores().subscribe(async data =>{
      data.forEach(element => {
        element.listaTags.forEach(tag => {
          if(mapTagsJogadores.has(tag)){
            let n = mapTagsJogadores.get(tag);
            if(n){
              mapTagsJogadores.delete(tag);
              mapTagsJogadores.set(tag,n+1);
            }
          }else{
            mapTagsJogadores.set(tag,1);
          }
        });
      });

      await new Promise(f => setTimeout(f,1000));
      for (let entry of mapTagsJogadores.entries()) {
        this.dataTagsJogadores.push({
          text: entry[0],
          weight: entry[1] 
        })
    }
      this.tagCloudComponent.reDraw();
    })
  }

  async tagCloudRelacoes(): Promise<void>{
    this.dataTagsRelacoes = [
      {
        text: '',
        weight: 0
      }
    ];

    let mapTagsRelacoes = new Map<string,number>();
    this.relacaoService.GetRelacoes().subscribe( async data =>{
      data.forEach(element => {
        element.listaTags.forEach(tag => {
          if(mapTagsRelacoes.has(tag)){
            let n = mapTagsRelacoes.get(tag);
            if(n){
              mapTagsRelacoes.delete(tag);
              mapTagsRelacoes.set(tag,n+1);
            }
          }else{
            mapTagsRelacoes.set(tag,1);
          }
        });
      });

      await new Promise(f => setTimeout(f,1000));
      for (let entry of mapTagsRelacoes.entries()) {
        this.dataTagsRelacoes.push({
          text: entry[0],
          weight: entry[1] 
        })
    }
      this.tagCloudComponent.reDraw();
    })
  }

  async tagCloudRelacoesJogador() : Promise<void>{

    this.dataTagsRelacoesJog = [
      {
        text: '',
        weight: 0
      }
    ];

    let mapTagsRelacoesJog = new Map<string,number>();
    this.JogadorService.GetAllRelacoesJogador(this.jogadorId).subscribe(async data =>{
      data.forEach(element => {
        element.listaTags.forEach(tag => {
          if(mapTagsRelacoesJog.has(tag)){
            let n = mapTagsRelacoesJog.get(tag);
            if(n){
              mapTagsRelacoesJog.delete(tag);
              mapTagsRelacoesJog.set(tag,n+1);
            }
          }else{
            mapTagsRelacoesJog.set(tag,1);
          }
        });
      });
      
      await new Promise(f => setTimeout(f,1000));
      for (let entry of mapTagsRelacoesJog.entries()) {
        this.dataTagsRelacoesJog.push({
          text: entry[0],
          weight: entry[1] 
        })
    }
      this.tagCloudComponent.reDraw();
    })
  }

  async tagCloudJogador() : Promise<void>{

    this.dataJogador = [
      {
        text: '',
        weight: 0
      }
    ];

    let mapTagsJogador = new Map<string,number>();
    this.JogadorService.GetJogador(this.jogadorId).subscribe(async data =>{
      data.listaTags.forEach(element => {
          if(mapTagsJogador.has(element)){
            let n = mapTagsJogador.get(element);
            if(n){
              mapTagsJogador.delete(element);
              mapTagsJogador.set(element,n+1);
            }
          }else{
            mapTagsJogador.set(element,1);
          }
        });
      });

      await new Promise(f => setTimeout(f,1000));
      for (let entry of mapTagsJogador.entries()) {
        this.dataJogador.push({
          text: entry[0],
          weight: entry[1] 
        })
    }
      this.tagCloudComponent.reDraw();
  }

  async tamanhoRede3Nivel() : Promise<void>{
    this.JogadorService.GetAllRelacoesPorNivelJogador(this.jogadorId,3).subscribe(data =>{
      this.relacoesListNivel = data;
    });
    await new Promise(f => setTimeout(f,1000));
    if(this.relacoesListNivel.length > 0){
      this.amigos3Nivel = this.relacoesListNivel.length;
    }
    
  }


  async leaderboardFortaleza() : Promise<void>{
    this.relacaoService.GetLeaderboard().subscribe(data =>{
      this.resFortaleza = data;
      console.log(this.resFortaleza);
    });
    await new Promise(f => setTimeout(f,1000));
  }

  async leaderboardDimensao() : Promise<void>{
    this.JogadorService.GetLeaderboard().subscribe(data =>{
      this.resDimensao = data;
      console.log(this.resDimensao);
    });

    await new Promise(f => setTimeout(f,1000));
    
  }
}