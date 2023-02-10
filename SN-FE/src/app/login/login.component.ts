import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JogadorService } from '../jogador.service';
import { JogadorDto } from '../jogador';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  password: string;
  loggingIn : boolean = false;

  utilizadores : number = 0;

  jogador: JogadorDto = {
    id: '',
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
    password: ''
  };

  email: string;

  constructor(private jogadorService: JogadorService, private router: Router) { }

  ngOnInit(): void {
    this.getNumeroUtilizadores();
  }

  validarLogin() {
    this.loggingIn = true;

    this.email = (document.getElementById("email") as HTMLInputElement).value;
    this.password = (document.getElementById("pass") as HTMLInputElement).value;

    this.jogadorService.validarLogin(this.email, this.password).subscribe(data => {
      this.jogador = data;
      if (this.jogador.email != "") {
        this.loggingIn = false;
        this.router.navigate(["/dashboard/rede"], { state: { data: this.jogador } });
      } else {
        this.loggingIn = false;
        console.log("erro");
        return;
      }
    });
  }


  getNumeroUtilizadores(){
    this.jogadorService.GetJogadores().subscribe( data => {
      this.callBackUtilizadores(data);
    })
  }


  callBackUtilizadores(data : JogadorDto[]){
    data.forEach(element => {
      this.utilizadores = this.utilizadores + 1;
    });
  }


}
