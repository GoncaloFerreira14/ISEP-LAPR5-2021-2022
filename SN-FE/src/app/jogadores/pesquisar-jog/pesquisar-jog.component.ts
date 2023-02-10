import { Component, OnInit } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { FormBuilder } from '@angular/forms';
import { JogadorDto } from 'src/app/jogador';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pesquisar-jog',
  templateUrl: './pesquisar-jog.component.html',
  styleUrls: ['./pesquisar-jog.component.css']
})
export class PesquisarJogComponent implements OnInit {

  jogador : JogadorDto;

  pesqForm = this.formBuilder.group({
    id: history.state.data.id,
    pesquisa:"",
  });

  constructor(private formBuilder: FormBuilder, private router : Router) { }

  ngOnInit(): void {
    this.jogador=history.state.data;
  }


  onSubmit() : void {
    this.router.navigate(["/dashboard/pedir ligacao"], {state : {data : this.pesqForm.value}});
    this.pesqForm.reset();
  }
}
