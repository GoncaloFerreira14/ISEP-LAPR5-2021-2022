import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { JogadorService } from 'src/app/jogador.service';
import { JogadorDto } from 'src/app/jogador';

@Component({
  selector: 'app-edit-jog',
  templateUrl: './edit-jog.component.html',
  styleUrls: ['./edit-jog.component.css']
})
export class EditJogComponent implements OnInit {

  jogador: JogadorDto;

  editForm = this.formBuilder.group({
    id: history.state.data.id,
    nome: "",
    email: history.state.data.email,
    avatar: "",
    dataNascimento: "",
    numeroTelefone: "",
    URLLinkedIn: "",
    URLFacebook: "",
    descricaoBreve: "",
    cidade: "",
    pais: "",
    listaTags: [],
    password: "",
  });

  constructor(
    private JogadorService: JogadorService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.jogador = history.state.data;
  }


  onSubmit(): void {
    this.JogadorService.editJogador(this.editForm.value, this.jogador.id).subscribe();
    console.log(this.editForm.value as JogadorDto);

    console.warn('Perfil editado', this.editForm.value);
    this.editForm.reset();
  }
}
