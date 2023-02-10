import { Comentario } from "./comentario";

export interface Post {
    id: string;
    jogadorId: string;
    jogadorNome: string;
    data: string;
    texto: string;
    likes: string;
    dislikes: string;
    tagsPost: string[];
    comentarios: Comentario[];
}
