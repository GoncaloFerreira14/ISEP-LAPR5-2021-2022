import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { JogadorDto } from 'src/app/jogador';
import { JogadorService } from 'src/app/jogador.service';
import { HttpErrorResponse } from '@angular/common/http';
import { TermosCondicoesComponent } from './termos-condicoes/termos-condicoes.component';

@Component({
  selector: 'app-add-jog',
  templateUrl: './add-jog.component.html',
  styleUrls: ['./add-jog.component.css']
})
export class AddJogComponent implements OnInit {

  lista: Array<string>;
  listaFinalTags: Array<string> = [];
  data: Date;
  jogador: JogadorDto;
  aceitar : boolean;

  registerForm = this.formBuilder.group({
    nome: '',
    email: '',
    avatar: '',
    dataNascimento: '',
    numeroTelefone: '',
    URLLinkedIn: '',
    URLFacebook: '',
    descricaoBreve: '',
    cidade: '',
    pais: '',
    listaTags: [],
    estadoHumor: '',
    password: '',
  });

  constructor(
    private jogadorService: JogadorService,
    private formBuilder: FormBuilder,
    public snackBar: MatSnackBar,
    private router: Router,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.aceitar = false;
  }

  onSubmit(): void {
    if(this.aceitar == false){
      this.snackBar.open("Precisa de ler e aceitar os nossos termos e condições primeiro!", "Close");
      return;
      }
    if (this.registerForm.value.listaTags != null) {
      this.lista = this.registerForm.value.listaTags.split(",");
      this.lista.forEach(tag => {
        this.listaFinalTags.push(tag.trim());
      });
      this.registerForm.value.listaTags = this.listaFinalTags;
    }

    this.data = this.registerForm.value.dataNascimento;
    this.registerForm.value.dataNascimento = this.data.toLocaleDateString();


    this.jogadorService.addJogador(this.registerForm.value as JogadorDto).subscribe(jogador => {
      console.warn('Utilizador criado', jogador.estadoHumor);
      this.jogadorService.validarLogin(jogador.email, jogador.password).subscribe(data => {
        if (jogador.email != "") {
          this.router.navigate(["/dashboard/rede"], { state: { data: jogador } });
        } else {
          console.log("erro");
          return;
        }
      });
    });

    console.warn('Perfil em criaçao', this.registerForm.value);

    this.snackBar.open("Utilizador registado com sucesso!", "Close");
  }
  termos(){
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(TermosCondicoesComponent, dialogConfig);

    dialogRef.afterClosed();
    this.aceitar = true;
  }
}
