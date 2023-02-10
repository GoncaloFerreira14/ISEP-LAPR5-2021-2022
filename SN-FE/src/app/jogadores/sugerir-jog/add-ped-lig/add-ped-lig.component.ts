import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { PedidoLigacaoService } from 'src/app/pedido-ligacao.service';
import { PedidoLigacaoDto } from 'src/app/pedidoLigacao';

@Component({
  selector: 'app-add-ped-lig',
  templateUrl: './add-ped-lig.component.html',
  styleUrls: ['./add-ped-lig.component.css']
})
export class AddPedLigComponent implements OnInit {

  pedidoForm = this.formBuilder.group({
    jogadorId: '',
    jogadorObjetivoId: '',
    msgObjetivo: '',
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private pedidoLigacaoService : PedidoLigacaoService,
    private formBuilder: FormBuilder,
    public dialogRef : MatDialogRef<AddPedLigComponent>,
    public snackBar: MatSnackBar,
    ) {
   }

  ngOnInit(): void {
    console.log(this.data);
  }

  onSubmit() {
    this.pedidoForm.value.jogadorId = this.data[1].id;
    this.pedidoForm.value.jogadorObjetivoId = this.data[2].id;
    console.log(this.pedidoForm)
    this.pedidoLigacaoService.addPedidosLigacao(this.pedidoForm.value as PedidoLigacaoDto).subscribe();

    this.snackBar.open("Pedido enviado com sucesso!", "Close");
    this.pedidoForm.reset();
    this.dialogRef.close();
  }

}
