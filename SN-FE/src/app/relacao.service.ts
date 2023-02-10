import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { RelacaoDto } from './relacao';
import { util } from 'utils/util';
import { leaderboardFortaleza } from './leaderboardFortaleza';
@Injectable({
  providedIn: 'root'
})
export class RelacaoService {

  private Url = util.URL+'Relacoes';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  GetRelacoes(): Observable<RelacaoDto[]> {
    return this.http.get<RelacaoDto[]>(this.Url)
      .pipe(
        catchError(this.handleError<RelacaoDto[]>('getRelacoes'))
      );
  }

  GetLeaderboard(): Observable<Array<leaderboardFortaleza>> {
    return this.http.get<Array<leaderboardFortaleza>>(this.Url + "/leaderboard/fortaleza")
      .pipe(
        catchError(this.handleError<Array<leaderboardFortaleza>>('GetLeaderboard'))
      );
  }

  editRelacao(relacao: RelacaoDto) {
    return this.http.put(this.Url + "/" + relacao.id, relacao, this.httpOptions).pipe(catchError(this.handleError('EditRelacao')));
  }

  apagarRelacoesJog(relacaoId: string): Observable<RelacaoDto> {
    console.log("AQUI RI! "+relacaoId);
    return this.http.delete<RelacaoDto>(this.Url+ "/"+ relacaoId+"/hard", this.httpOptions).pipe(
      catchError(this.handleError<RelacaoDto>('delRelacao'))
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
}
