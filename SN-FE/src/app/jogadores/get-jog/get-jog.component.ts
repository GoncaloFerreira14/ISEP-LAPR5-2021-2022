import { Component, OnInit } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { Router } from '@angular/router';
import { JogadorDto } from 'src/app/jogador';

@Component({
  selector: 'app-get-jog',
  templateUrl: './get-jog.component.html',
  styleUrls: ['./get-jog.component.css']
})
export class GetJogComponent implements OnInit {

  jogadorAtivo: JogadorDto;

  constructor(private JogadorService: JogadorService, private router: Router) { }

  ngOnInit(): void {
    this.jogadorAtivo = history.state.data;

  }

  editProfile() {
    this.router.navigate(["/dashboard/editar perfil proprio"], { state: { data: this.jogadorAtivo } });
  }

  goToApagarConta(){
    this.router.navigate(["/dashboard/apagar jogador"], {state : {data : this.jogadorAtivo}});
  }
}
