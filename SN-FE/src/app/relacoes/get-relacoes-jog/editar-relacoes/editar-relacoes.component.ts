import { Component, Input, OnInit } from '@angular/core';
import { RelacaoService } from 'src/app/relacao.service';
import { RelacaoDto } from 'src/app/relacao';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editar-relacoes',
  templateUrl: './editar-relacoes.component.html',
  styleUrls: ['./editar-relacoes.component.css']
})
export class EditarRelacoesComponent implements OnInit {

  relacao: RelacaoDto;

  lista: Array<string>;

  constructor(private relacaoService: RelacaoService,
    public snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.relacao = history.state.data;
  }

  editRelacao() {
    this.relacao.forcaLigacao = parseFloat((document.getElementById("forca") as HTMLInputElement).value);
    this.lista = ((document.getElementById("lista") as HTMLInputElement).value).split(",");
    console.log(this.lista);
    this.relacao.listaTags = [];
    this.lista.forEach(tag => {
      this.relacao.listaTags.push(tag.trim());
    });
    this.relacaoService.editRelacao(this.relacao).subscribe();
    this.snackBar.open("Relação editada com sucesso!", "Close");
  }

}
