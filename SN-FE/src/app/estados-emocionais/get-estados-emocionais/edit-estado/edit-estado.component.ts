import { Component, OnInit } from '@angular/core';
import { EstadoEmocionalDto } from 'src/app/estadoEmocional';
import { EstadosEmocionaisService } from 'src/app/estados-emocionais.service';
import { FormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GetEstadosEmocionaisComponent } from '../get-estados-emocionais.component';
@Component({
  selector: 'app-edit-estado',
  templateUrl: './edit-estado.component.html',
  styleUrls: ['./edit-estado.component.css']
})
export class EditEstadoComponent implements OnInit {

  estado: EstadoEmocionalDto;
  editForm = this.formBuilder.group({
    estadoHumor: '',

  });
  constructor(private estadoService: EstadosEmocionaisService, private formBuilder: FormBuilder, public snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.estado = history.state.data;
  }

  editEstado() {
    this.estado.estadoHumor = (document.getElementById("estadoHumor") as HTMLInputElement).value;
    this.estadoService.editEstado(this.estado).subscribe();
    this.snackBar.open("Estado emocional alterado!", "Close");
  }


}

