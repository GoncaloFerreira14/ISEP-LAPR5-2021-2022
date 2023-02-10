import { Component, OnInit } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { RelacaoService } from 'src/app/relacao.service';
import { RelacaoDto } from 'src/app/relacao';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { JogadorDto } from 'src/app/jogador';
import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y/input-modality/input-modality-detector';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-get-fortaleza-rede',
  templateUrl: './get-fortaleza-rede.component.html',
  styleUrls: ['./get-fortaleza-rede.component.css']
})
export class GetFortalezaRedeComponent implements OnInit {

  relacoesList: RelacaoDto[] = [];

	
  
	displayedColumns: string[] = ['fortalezaRede'];
	dataSource = this.relacoesList;


	
	jogadorId: string;
    fortalezaRede : number = 0;
	empData : any[];
	
	

	

	constructor(private JogadorService: JogadorService, private relacaoService: RelacaoService, private router: Router) { }

	ngOnInit(): void {
		this.jogadorId = history.state.data;
		this.getRelacoes();
		
	}


	
	getRelacoes(): void {
		this.JogadorService.GetAllRelacoesJogador(this.jogadorId)
			.subscribe(data => {
				if (data) {
					console.log(this.jogadorId);
					for (let i = 0; i < data.length; i++){
						this.fortalezaRede = this.fortalezaRede + data[i].forcaLigacao;
						this.empData =[this.fortalezaRede];
					}
					
				}
			});
	}

	

}

