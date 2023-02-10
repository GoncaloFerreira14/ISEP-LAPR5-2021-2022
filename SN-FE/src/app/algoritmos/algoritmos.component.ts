import { Component, OnInit } from '@angular/core';
import { AlgoritmosService } from 'src/app/algoritmos.service';
import { Router } from '@angular/router';
import { JogadorDto } from 'src/app/jogador';
import { AlgoritmosDto } from '../algoritmos';
@Component({
  selector: 'app-algoritmos',
  templateUrl: './algoritmos.component.html',
  styleUrls: ['./algoritmos.component.css']
})
export class AlgoritmosComponent implements OnInit {
    estadosHumor: [{name: "Joyful"},
    {name: "Distressed"},
    {name: "Hopeful"},
    {name: "Fearful"},
    {name: "Relieved"},
    {name: "Disappointed"},
    {name: "Proud"},
    {name: "Remorseful"},
    {name: "Grateful"},
    {name: "Angry"},
    {name: "Neutral"},
    ];

  jogadorAtivo: JogadorDto;
  jogadorObjetivo: JogadorDto;
  necessita = false;

  constructor(private AlgoritmosService: AlgoritmosService, private router: Router) { }

  ngOnInit(): void {
    this.jogadorAtivo = history.state.data;
    this.ola.y = '';
    this.ola.x = [];
    this.ola2.y = '';
    this.ola2.x = [];
    this.ola3.x = [];
  }
  ola : AlgoritmosDto;
  ola2 : AlgoritmosDto;
  ola3 : AlgoritmosDto;
  
  onSubmit(): void {
    this.AlgoritmosService.getBfs("hugo@gmail.com","pedro@gmail.com",4).subscribe(d=> this.ola = d);
    this.AlgoritmosService.getBfsE("a","h",4).subscribe(d=> this.ola2 = d);
    this.AlgoritmosService.getSugerir("a",2,2).subscribe(d=> this.ola3 = d);
  }

  guardarOpcoes(): void {
    
  }

}
