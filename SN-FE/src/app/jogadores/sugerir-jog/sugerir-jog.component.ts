import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { JogadorDto } from 'src/app/jogador';
import { JogadorService } from 'src/app/jogador.service';
import { AddPedLigComponent } from './add-ped-lig/add-ped-lig.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

@Component({
  selector: 'app-sugerir-jog',
  templateUrl: './sugerir-jog.component.html',
  styleUrls: ['./sugerir-jog.component.css']
})
export class SugerirJogComponent implements OnInit {

  displayedColumns: string[] = ['nome', 'email', 'descricao', 'dataNascimento', 'listaTags', 'actions'];

  jogadorAtivo: JogadorDto;
  sugestoes: JogadorDto[] = [];

  constructor(
    private jogadorService: JogadorService,
    private router: Router,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.jogadorAtivo = history.state.data;
    this.getSugestoes();
  }

  getSugestoes(): void {
    this.jogadorService.getSugestoesJogador(this.jogadorAtivo).subscribe(sugestoes => this.sugestoes = sugestoes);
  }

  adicionar(jogadorDto: JogadorDto): void {
    //this.router.navigate(["dashboard/add-ped-lig"], {state : {data : this.jogadorAtivo}});
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.width = "20%";
    dialogConfig.data = { 1: this.jogadorAtivo, 2: jogadorDto };

    this.dialog.open(AddPedLigComponent, dialogConfig);
  }

}
