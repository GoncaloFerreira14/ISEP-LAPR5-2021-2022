import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { JogadorService } from '../jogador.service';
import { JogadorDto } from '../jogador';
import { Post } from '../model/post';
import { PostService } from '../services/post.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComentariosService } from '../services/comentarios.service';
import { Comentario } from '../model/comentario';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  jogadorAtivo: JogadorDto;
  jogadorPosterNome: string;
  posts: Post[];
  lista: Array<string>;
  listaFinalTags: Array<string> = [];

  postForm = this.formBuilder.group({
    id: '',
    jogadorId: '',
    data: '',
    texto: ['', Validators.required],
    likes: '',
    dislikes: '',
    tagsPost: [],
    comentarios: [],
  })

  comentarioForm = this.formBuilder.group({
    id: '',
    jogadorId: '',
    postId: '',
    data: '',
    texto: ['', Validators.required],
  })

  constructor(
    private jogadorService: JogadorService,
    private formBuilder: FormBuilder,
    private postService: PostService,
    private comentariosService: ComentariosService,
    public snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.jogadorAtivo = history.state.data;
    console.log(this.jogadorAtivo);
    this.getPosts();
  }

  getPosts(): void {
    this.postService.GetPosts().subscribe(posts => {this.posts = posts;console.log(posts);});
  }

  getNomeJogadorById(jogadorPosterId: string): string {
    this.jogadorService.GetJogador(jogadorPosterId).subscribe(jog => this.jogadorPosterNome = jog.nome);

    return this.jogadorPosterNome;
  }

  onSubmit() {
    this.postForm.value.jogadorId = this.jogadorAtivo.nome;

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    var todayString = mm + '/' + dd + '/' + yyyy;

    this.postForm.value.data = todayString;

    this.postForm.value.likes = 0;
    this.postForm.value.dislikes = 0;

    if (this.postForm.value.tagsPost != null) {
      this.lista = this.postForm.value.tagsPost.split(",");
      this.lista.forEach(tag => {
        this.listaFinalTags.push(tag.trim());
      });
      this.postForm.value.tagsPost = this.listaFinalTags;
    }

    console.log("postForm"+this.postForm.value);

    this.postService.addPost(this.postForm.value as Post).subscribe(post => {
      console.warn('post criado', post);
    });

    this.snackBar.open("Post criado com sucesso!", "Close");
  }

  likePost(post : Post) {
    this.postService.likePost(post).subscribe();
  }

  dislikePost(post : Post) {
    this.postService.dislikePost(post).subscribe();
  }

  comentarPost(post : Post) {
    this.comentarioForm.value.jogadorId = this.jogadorAtivo.nome;
    this.comentarioForm.value.postId = post.id;

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    var todayString = mm + '/' + dd + '/' + yyyy;

    this.comentarioForm.value.data = todayString;

    console.log(this.comentarioForm.value);

    this.comentariosService.add(this.comentarioForm.value as Comentario).subscribe(comentario => {
      console.warn('comentario criado', comentario);
    });

    this.snackBar.open("Comentario criado com sucesso!", "Close");
  }

}
