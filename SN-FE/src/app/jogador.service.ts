import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { JogadorDto } from './jogador';
import { RelacaoDto } from './relacao';
import { EstadoEmocionalDto } from './estadoEmocional';
import { RelacoesListNivelDto } from './relacoesListNivel';
import { PedidoIntroducaoDto } from './pedidoIntroducao';
import { PedidoLigacaoDto } from './pedidoLigacao';
import { util } from 'utils/util';
import { leaderboardDimensao } from './leaderboardDimensao';
@Injectable({
  providedIn: 'root'
})
export class JogadorService {

  private jogadoresUrl = util.URL+'Jogadores'; // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(
    private http: HttpClient,
  ) { }

  /** GET - obtem as sugestoes para o jogador que estao no server */
  getSugestoesJogador(jogador: JogadorDto): Observable<JogadorDto[]> {
    return this.http.get<JogadorDto[]>(this.jogadoresUrl + "/" + jogador.id + "/jogadoresPorTagComuns")
      .pipe(
        catchError(this.handleError<JogadorDto[]>('sugerirJogadores'))
      );
  }

  /** GET - obtem o jogador com o id fornecido */
  GetJogador(jogadorId: string): Observable<JogadorDto> {
    return this.http.get<JogadorDto>(this.jogadoresUrl + "/" + jogadorId)
      .pipe(
        catchError(this.handleError<JogadorDto>('getJogador'))
      );
  }

  /** GET - obtem todos os jogadores */
  GetJogadores(): Observable<JogadorDto[]> {
    return this.http.get<JogadorDto[]>(this.jogadoresUrl)
      .pipe(
        catchError(this.handleError<JogadorDto[]>('getJogadores'))
      );
  }

  /** GET - obtem o jogador com o email fornecido */
  GetJogadorByEmail(email: string): Observable<JogadorDto> {
    return this.http.get<JogadorDto>(this.jogadoresUrl + "/email/" + email)
      .pipe(
        catchError(this.handleError<JogadorDto>('getJogadorEmail'))
      );
  }

  /** PUT - altera as informações do utilizador*/
  editJogador(jogador: JogadorDto, id: String) {
    return this.http.put(this.jogadoresUrl + "/" + id, jogador, this.httpOptions).pipe(catchError(this.handleError('EditRelacao')));
  }



  /** POST: adiciona um jogador */
  addJogador(jogador: JogadorDto): Observable<JogadorDto> {
    return this.http.post<JogadorDto>(this.jogadoresUrl, jogador, this.httpOptions).pipe(
      catchError(this.handleError<JogadorDto>('addJogador'))
    );
  }

  /** GET: obtem todas as relações do jogador */
  GetAllRelacoesJogador(id: string): Observable<Array<RelacaoDto>> {
    return this.http.get<Array<RelacaoDto>>(this.jogadoresUrl + "/" + id + "/relacoes").pipe(
      catchError(this.handleError<Array<RelacaoDto>>('getRelacoesJog'))
    );
  }

  GetAllRelacoesJogadorAmigo(id: string): Observable<Array<RelacaoDto>> {
    return this.http.get<Array<RelacaoDto>>(this.jogadoresUrl + "/" + id + "/relacoesAmigo").pipe(
      catchError(this.handleError<Array<RelacaoDto>>('getRelacoesJog'))
    );
  }
  validarLogin(email: string, password: string): Observable<any> {
    return this.http.get<any>(this.jogadoresUrl + "/login/" + email + "/" + password, this.httpOptions)
      .pipe(catchError(this.handleError('validarLogin')));
  }

  /** GET: obtem todas as relações do jogador */
  GetEstadoHumorByJogadorId(id: string): Observable<EstadoEmocionalDto> {
    return this.http.get<EstadoEmocionalDto>(this.jogadoresUrl + "/" + id + "/estadosEmocionais").pipe(
      catchError(this.handleError<EstadoEmocionalDto>('getEstado'))
    );
  }

  /** GET: obtem todos os pedidos de introdução em que o jogador está envolvido */
  GetPedidosIntroducaoJogador(id: string): Observable<Array<PedidoIntroducaoDto>> {
    return this.http.get<Array<PedidoIntroducaoDto>>(this.jogadoresUrl + "/" + id + "/pedidosintroducao").pipe(
      catchError(this.handleError<Array<PedidoIntroducaoDto>>('getPedidosIntorducao'))
    );
  }

  /** GET: obtem todos os pedidos de ligacao em que o jogador está envolvido */
  GetPedidosLigacaoJogador(id: string): Observable<Array<PedidoLigacaoDto>> {
    return this.http.get<Array<PedidoLigacaoDto>>(this.jogadoresUrl + "/" + id + "/pedidosligacao").pipe(
      catchError(this.handleError<Array<PedidoLigacaoDto>>('getPedidosIntorducao'))
    );
  }


  GetAllRelacoesPorNivelJogador(id: string, nivel: number): Observable<Array<RelacoesListNivelDto>> {
    return this.http.get<Array<RelacoesListNivelDto>>(this.jogadoresUrl + "/" + id + "/relacoes/" + nivel).pipe(catchError(this.handleError<Array<RelacoesListNivelDto>>('getRelacoesPorNivel')));
  }

  GetLeaderboard(): Observable<Array<leaderboardDimensao>> {
    return this.http.get<Array<leaderboardDimensao>>(this.jogadoresUrl + "/leaderboard/dimensao")
      .pipe(
        catchError(this.handleError<Array<leaderboardDimensao>>('GetLeaderboard'))
      );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  /** GET: obtem todas as relações do jogador */
  PesquisarJogadores(id: string, pesquisa: string): Observable<JogadorDto[]> {
    return this.http.get<JogadorDto[]>(this.jogadoresUrl + "/" + id + "/Pesquisar/" + pesquisa,this.httpOptions).pipe(
      catchError(this.handleError<JogadorDto[]>('pesquisar jogadores'))
    );
  }

  Apagar(jogadorId: string): Observable<JogadorDto> {
    return this.http.delete<JogadorDto>(this.jogadoresUrl+ "/"+ jogadorId+"/hard", this.httpOptions).pipe(
      catchError(this.handleError<JogadorDto>('delJogador'))
    );
  }

  
}
