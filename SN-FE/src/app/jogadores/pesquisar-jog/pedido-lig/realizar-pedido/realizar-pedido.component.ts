import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { PedidoLigacaoService } from 'src/app/pedido-ligacao.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PedidoLigacaoDto } from 'src/app/pedidoLigacao';

@Component({
  selector: 'app-realizar-pedido',
  templateUrl: './realizar-pedido.component.html',
  styleUrls: ['./realizar-pedido.component.css']
})
export class RealizarPedidoComponent implements OnInit {

  addForm = this.formBuilder.group({
    jogadorId: history.state.data2,
    jogadorObjetivoId: history.state.data.id,
    msgObjetivo: '',
    
  });

  constructor( private PedidoLigacaoService: PedidoLigacaoService, private formBuilder: FormBuilder,public snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  onSubmit() : void {
   this.PedidoLigacaoService.addPedidosLigacao(this.addForm.value as PedidoLigacaoDto).subscribe();
   console.warn('A enviar pedido', this.addForm.value);
    this.snackBar.open("Pedido enviado!","Close");
  }
}
