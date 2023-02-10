import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { JogadorService } from 'src/app/jogador.service';
import { RelacaoService } from 'src/app/relacao.service';
import { PedidoLigacaoService } from 'src/app/pedido-ligacao.service';
import { JogadorDto } from 'src/app/jogador';
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
@Component({
  selector: 'app-del-jog',
  templateUrl: './del-jog.component.html',
  styleUrls: ['./del-jog.component.css']
})
export class DelJogComponent implements OnInit {
  jogador: JogadorDto;

  validRole: Boolean = false;

  constructor(
    private JogadorService: JogadorService,
    private RelacaoService : RelacaoService,
    private PedidoLigacaoService : PedidoLigacaoService,
    private formBuilder: FormBuilder,
    private dialog: MatDialog,
    private router : Router,
    public snackBar: MatSnackBar) { }

 


  ngOnInit(): void {
    this.jogador = history.state.data;
    
  }

 async apagaConta(): Promise<void> { 
    this.JogadorService.GetAllRelacoesJogador(this.jogador.id).subscribe(data => {
      if(data){
      for (let i = 0; i < data.length; i++){
      this.RelacaoService.apagarRelacoesJog(data[i].id).subscribe(d=>console.log("oi"));
    }
      }
    });
    this.JogadorService.GetAllRelacoesJogadorAmigo(this.jogador.id).subscribe(data => {
      if(data){
      for (let i = 0; i < data.length; i++){
      this.RelacaoService.apagarRelacoesJog(data[i].id).subscribe(d=>console.log("oi"));
    }
      }
    });
      this.JogadorService.GetPedidosLigacaoJogador(this.jogador.id).subscribe(d => {
        if(d){
          for (let i = 0; i < d.length; i++){
        this.PedidoLigacaoService.apagarPedidosLigacaoJog(d[i].id).subscribe(d=>console.log("oi2"));
          }
        }
    });
  
    await new Promise(f => setTimeout(f, 2000));
     this.JogadorService.Apagar(this.jogador.id).subscribe(da => {
      this.router.navigate(["/login"]);
        this.snackBar.open("Conta apagada com sucesso!", "Close");
  });
  
         
           
      
        
      }
      
      goToRede(){
        this.router.navigate(["dashboard/rede"], {state : {data : this.jogador}});
      }
  }
