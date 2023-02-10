import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidosIntroducaoComponent } from './pedidos-introducao/pedidos-introducao.component';
import { AddPedidoComponent } from './pedidos-introducao/add-pedido/add-pedido.component';
import { AddJogComponent } from './jogadores/add-jog/add-jog.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { EditEstadoComponent } from './estados-emocionais/get-estados-emocionais/edit-estado/edit-estado.component';
import { EditarRelacoesComponent } from './relacoes/get-relacoes-jog/editar-relacoes/editar-relacoes.component';
import { GetRelacoesJogComponent } from './relacoes/get-relacoes-jog/get-relacoes-jog.component';
import { SugerirJogComponent } from './jogadores/sugerir-jog/sugerir-jog.component';
import { GetEstadosEmocionaisComponent } from './estados-emocionais/get-estados-emocionais/get-estados-emocionais.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { RelacoesComponent } from './relacoes/relacoes.component';
import { RedeComponent } from './rede/rede.component';
import { EditJogComponent } from './jogadores/get-jog/edit-jog/edit-jog.component';
import { GetJogComponent } from './jogadores/get-jog/get-jog.component';
import { PostsComponent } from './posts/posts.component';
import { PesquisarJogComponent } from './jogadores/pesquisar-jog/pesquisar-jog.component';
import { PedidoLigComponent } from './jogadores/pesquisar-jog/pedido-lig/pedido-lig.component';
import { RealizarPedidoComponent } from './jogadores/pesquisar-jog/pedido-lig/realizar-pedido/realizar-pedido.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { PedidosLigacaoComponent } from './pedidos-ligacao/pedidos-ligacao.component';
import { AddPedLigComponent } from './jogadores/sugerir-jog/add-ped-lig/add-ped-lig.component';
import { AlgoritmosComponent } from './algoritmos/algoritmos.component';
import { EstatisticasComponent } from './estatisticas/estatisticas.component';
import { UtilizadorNaoAutenticadoComponent } from './utilizador-nao-autenticado/utilizador-nao-autenticado.component';
import { FortalezaRedeComponent } from './fortaleza-rede/fortaleza-rede.component';
import { GetFortalezaRedeComponent } from './fortaleza-rede/get-fortaleza-rede/get-fortaleza-rede.component';
import { DelJogComponent } from './jogadores/get-jog/del-jog/del-jog.component';
import { AmigosComunsComponent } from './amigos-comuns/amigos-comuns.component';
const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard', component: DashboardComponent, children: [
      {
        path: 'pedidos', //child route path
        component: PedidosComponent, children: [{
          path: 'pedidos introducao', component: PedidosIntroducaoComponent,

        },
        {
          path: 'pedidos ligacao', component: PedidosLigacaoComponent,
        }
        ]
      }, // child router component that the router renders

      {
        path: 'sugerir jogadores', //child route path
        component: SugerirJogComponent, // child router component that the router renders
      },
      {
        path: 'add-ped-lig',
        component: AddPedLigComponent
      },
      {
        path: 'amigoscomuns',
        component: AmigosComunsComponent
      },
      {
        path: 'rede',
        component: RedeComponent,
      },
      { path: 'add-ped-lig', component: AddPedLigComponent },
      { path: 'add pedido introducao', component: AddPedidoComponent },
      { path: 'get relacoes jogador', component: GetRelacoesJogComponent },
      { path: 'relacoes', component: RelacoesComponent },
      { path: 'editar relacao', component: EditarRelacoesComponent },
      { path: 'get estado jogador', component: GetEstadosEmocionaisComponent },
      { path: 'editar estado emocional', component: EditEstadoComponent },
      { path: 'editar perfil proprio', component: EditJogComponent },
      { path: 'get perfil proprio', component: GetJogComponent },
      { path: 'apagar jogador', component: DelJogComponent },
      { path: 'posts', component: PostsComponent },
      { path: 'pesquisar', component: PesquisarJogComponent },
      { path: 'pedir ligacao', component: PedidoLigComponent },
      { path: 'realizar pedido', component: RealizarPedidoComponent },
      { path: 'algoritmos', component: AlgoritmosComponent },
      { path : 'get fortaleza rede', component: GetFortalezaRedeComponent},
      { path : ' fortaleza rede', component: FortalezaRedeComponent},
      { path : 'estatisticas', component: EstatisticasComponent},
    ]
  },


  { path: 'registar jogador', component: AddJogComponent },
  
  { path : 'nao_autenticado', component: UtilizadorNaoAutenticadoComponent}, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
