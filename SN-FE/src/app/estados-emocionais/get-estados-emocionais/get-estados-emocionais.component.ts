import { Component, OnInit } from '@angular/core';
import { JogadorService } from 'src/app/jogador.service';
import { EstadosEmocionaisService } from 'src/app/estados-emocionais.service';
import { EstadoEmocionalDto } from 'src/app/estadoEmocional';
import { Router } from '@angular/router';

@Component({
  selector: 'app-get-estados-emocionais',
  templateUrl: './get-estados-emocionais.component.html',
  styleUrls: ['./get-estados-emocionais.component.css']
})
export class GetEstadosEmocionaisComponent implements OnInit {

  estadoList: EstadoEmocionalDto[] = [];

  estado: EstadoEmocionalDto;

  jogadorId: string;

  
  dataSource = this.estadoList;

  constructor(private JogadorService: JogadorService, private estadoService: EstadosEmocionaisService, private router: Router) { }

  ngOnInit(): void {
    this.jogadorId = history.state.data;
    this.getEstado();

  }

  getJogadorId() {
    return this.jogadorId;
  }

  setEstado(est: EstadoEmocionalDto) {
    this.estado = est;
    this.router.navigate(["/dashboard/editar estado emocional"], { state: { data: this.estado } });
  }
  getEstado(): void {
    this.JogadorService.GetEstadoHumorByJogadorId(this.jogadorId).subscribe(data => {
      this.estado = data;
      this.estadoList.push(this.estado);
      this.dataSource = this.estadoList;
      console.log(this.estado);
    }
    );

  }

}
