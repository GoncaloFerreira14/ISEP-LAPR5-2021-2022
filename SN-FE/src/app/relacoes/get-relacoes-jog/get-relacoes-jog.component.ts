import { Component, OnInit } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { RelacaoService } from 'src/app/relacao.service';
import { RelacaoDto } from 'src/app/relacao';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { JogadorDto } from 'src/app/jogador';

@Component({
	selector: 'app-get-relacoes-jog',
	templateUrl: './get-relacoes-jog.component.html',
	styleUrls: ['./get-relacoes-jog.component.css']
})
export class GetRelacoesJogComponent implements OnInit {

	relacoesList: RelacaoDto[] = [];

	relacao: RelacaoDto;

	displayedColumns: string[] = ['forcaLigacao','forcaRelacao', 'data', 'listaTags', 'Amigo', 'actions'];
	dataSource = this.relacoesList;


	jogadorId: string;

	jogadorAmigo: JogadorDto;

	constructor(private JogadorService: JogadorService, private relacaoService: RelacaoService, private router: Router) { }

	ngOnInit(): void {
		this.jogadorId = history.state.data;
		this.getRelacoes();
	}


	getJogadorId() {
		return this.jogadorId; 
	}

	setRelacao(rel: RelacaoDto) {
		this.relacao = rel;
		this.router.navigate(["/dashboard/editar relacao"], { state: { data: this.relacao } });
	}

	getRelacoes(): void {
		this.JogadorService.GetAllRelacoesJogador(this.jogadorId)
			.subscribe(data => {
				if (data) {
					this.callback(data);
				}
			});
	}

	callback(listaRelacoes: any) {
		this.relacoesList = listaRelacoes;
		this.dataSource = this.relacoesList;
		this.getJogadorAmigoById();
	}

	getJogadorAmigoById() {
		this.relacoesList.forEach(element => {
			this.JogadorService.GetJogador(element.jogadorAmigoId)
				.subscribe(data => {
					if (data) {
						this.callbackJogador(data);
						element.jogadorAmigoNome = data.nome;
					}
				}
				)
		});
	}

	callbackJogador(jogador: any) {
		this.jogadorAmigo = jogador;
	}

}


