import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { PedidoIntroducaoService } from '../../pedido-introducao.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PedidoIntroducaoDto } from '../../pedidoIntroducao';
import { JogadorService } from 'src/app/jogador.service';

@Component({
  selector: 'app-add-pedido',
  templateUrl: './add-pedido.component.html',
  styleUrls: ['./add-pedido.component.css']
})
export class AddPedidoComponent implements OnInit {

  jogadorIntermedioEmail : string;

  jogadorObjetivoEmail : string;

  msgObjetivo : string;

  msgIntermedio : string;

  pedidoForm = this.formBuilder.group({
    jogadorIntermedioEmail: '',
    jogadorObjetivoEmail: '',
    msgIntermedio: '',
    msgObjetivo: '',
  });

  pedidoForm2 = this.formBuilder.group({
    jogadorId: '',
    jogadorIntermedioId: '',
    jogadorObjetivoId: '',
    MsgIntermedio: '',
    MsgObjetivo: '',
  })

  
  jogadorId : string;

  



  constructor(private PedidoIntroducaoService: PedidoIntroducaoService, private formBuilder: FormBuilder, public snackBar: MatSnackBar,
              private jogadorService : JogadorService) { }

  ngOnInit(): void {
    this.jogadorId = history.state.data.id;
  }


  onSubmit(): void {
    
    this.pedidoForm2.value.jogadorId = this.jogadorId;
    this.pedidoForm2.value.msgIntermedio = this.pedidoForm.value.msgIntermedio;
    this.pedidoForm2.value.msgObjetivo = this.pedidoForm.value.msgObjetivo;

    this.jogadorService.GetJogadorByEmail(this.pedidoForm.value.jogadorIntermedioEmail).subscribe(data =>{
     
      this.pedidoForm2.value.jogadorIntermedioId = data.id;
      this.jogadorService.GetJogadorByEmail(this.pedidoForm.value.jogadorObjetivoEmail).subscribe(data =>{
        
        this.pedidoForm2.value.jogadorObjetivoId  = data.id;
        this.PedidoIntroducaoService.addPedidosIntroducao(this.pedidoForm2.value as PedidoIntroducaoDto).subscribe();
      })

    })

    console.warn('A enviar pedido');
    this.snackBar.open("Pedido enviado!", "Close");
  }
}
