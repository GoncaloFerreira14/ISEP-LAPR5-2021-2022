import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { util } from 'utils/util';
import { Post } from '../model/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private postsUrl = util.URL + 'Posts';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) { }

  /** GET - obtem todos os posts */
  GetPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.postsUrl)
      .pipe(
        catchError(this.handleError<Post[]>('getPosts'))
      );
  }

  /** POST: adiciona um post */
  addPost(post: Post): Observable<Post> {
    console.log(post);
    return this.http.post<Post>(this.postsUrl, post, this.httpOptions).pipe(
      catchError(this.handleError<Post>('addPost'))
    );
  }

    /** PUT: update post on the server */
  updatePost(post: Post): Observable<any> {
    return this.http.put(this.postsUrl + "/" + post.id, post, this.httpOptions).pipe(
      catchError(this.handleError<Array<Post>>('updatePost'))
    );
  }

    /** PUT: update post on the server with extra like from user*/
    likePost(post: Post): Observable<Post> {
      console.log(post);
      return this.http.put<Post>(this.postsUrl + "/" + post.id + "/like", post, this.httpOptions).pipe(
        catchError(this.handleError<Post>('LikePost'))
      );
    }

    /** PUT: update post on the server with extra dislike from user*/
    dislikePost(post: Post): Observable<Post> {
      return this.http.put<Post>(this.postsUrl + "/" + post.id + "/dislike", post, this.httpOptions).pipe(
        catchError(this.handleError<Post>('DislikePost'))
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
