import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table'
import { AppComponent } from './app.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { AppRoutingModule } from './app-routing.module';
import { AddJogComponent } from './jogadores/add-jog/add-jog.component';
import { RelacoesComponent } from './relacoes/relacoes.component';
import { GetRelacoesJogComponent } from './relacoes/get-relacoes-jog/get-relacoes-jog.component';
import { PedidosIntroducaoComponent } from './pedidos-introducao/pedidos-introducao.component';
import { SugerirJogComponent } from './jogadores/sugerir-jog/sugerir-jog.component';
import { RedeComponent } from './rede/rede.component';
import { EditarRelacoesComponent } from './relacoes/get-relacoes-jog/editar-relacoes/editar-relacoes.component';
import { EstadosEmocionaisComponent } from './estados-emocionais/estados-emocionais.component';
import { EditEstadoComponent } from './estados-emocionais/get-estados-emocionais/edit-estado/edit-estado.component';
import { GetEstadosEmocionaisComponent } from './estados-emocionais/get-estados-emocionais/get-estados-emocionais.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { GetJogComponent } from './jogadores/get-jog/get-jog.component';
import { AddPedidoComponent } from './pedidos-introducao/add-pedido/add-pedido.component';
import { EditJogComponent } from './jogadores/get-jog/edit-jog/edit-jog.component';
import { PostsComponent } from './posts/posts.component';
import { PesquisarJogComponent } from './jogadores/pesquisar-jog/pesquisar-jog.component';
import { PedidoLigComponent } from './jogadores/pesquisar-jog/pedido-lig/pedido-lig.component';
import { RealizarPedidoComponent } from './jogadores/pesquisar-jog/pedido-lig/realizar-pedido/realizar-pedido.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { PedidosLigacaoComponent } from './pedidos-ligacao/pedidos-ligacao.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import { AddPedLigComponent } from './jogadores/sugerir-jog/add-ped-lig/add-ped-lig.component';
import { AlgoritmosComponent } from './algoritmos/algoritmos.component';
import { TermosCondicoesComponent } from './jogadores/add-jog/termos-condicoes/termos-condicoes.component';
import { EstatisticasComponent } from './estatisticas/estatisticas.component';
import { UtilizadorNaoAutenticadoComponent } from './utilizador-nao-autenticado/utilizador-nao-autenticado.component';
import { FortalezaRedeComponent } from './fortaleza-rede/fortaleza-rede.component';
import { GetFortalezaRedeComponent } from './fortaleza-rede/get-fortaleza-rede/get-fortaleza-rede.component';
import { DelJogComponent } from './jogadores/get-jog/del-jog/del-jog.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { TagCloudModule } from 'angular-tag-cloud-module';
import { MatSelect, MatSelectModule } from '@angular/material/select';
import { AmigosComunsComponent } from './amigos-comuns/amigos-comuns.component';
import {MatListModule} from '@angular/material/list';

@NgModule({

  declarations: [
    AppComponent,
    JogadoresComponent,
    AddJogComponent,
    RelacoesComponent,
    GetRelacoesJogComponent,
    PedidosIntroducaoComponent,
    SugerirJogComponent,
    RedeComponent,
    EditarRelacoesComponent,
    EstadosEmocionaisComponent,
    EditEstadoComponent,
    GetEstadosEmocionaisComponent,
    LoginComponent,
    DashboardComponent,
    GetJogComponent,
    AddPedidoComponent,
    EditJogComponent,
    PostsComponent,
    PesquisarJogComponent,
    PedidoLigComponent,
    RealizarPedidoComponent,
    PedidosComponent,
    PedidosLigacaoComponent,
    AddPedLigComponent,
    AlgoritmosComponent,
    TermosCondicoesComponent,
    EstatisticasComponent,
    UtilizadorNaoAutenticadoComponent,
    FortalezaRedeComponent,
    GetFortalezaRedeComponent,
    DelJogComponent,
    AmigosComunsComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatDividerModule,
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatCardModule,
    MatCheckboxModule,
    TagCloudModule,
    MatSelectModule,
    MatListModule
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
