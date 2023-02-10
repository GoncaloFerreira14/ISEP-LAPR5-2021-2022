
import * as THREE from 'three';
import { JogadorDto } from '../jogador';
import { JogadorService } from '../jogador.service';
import { RelacaoDto } from '../relacao';
import TextSprite from './TextSprite';

export default class Graph {

    textSprite : TextSprite;

    jog1 : JogadorDto;

    jog2 : JogadorDto;

    constructor(private jogService : JogadorService) {
    }

     criarConexao(scene : THREE.Scene,relacao : RelacaoDto){
        var metade_pi = Math.PI * 0.5;
        var verticeI = new THREE.Vector3(scene.getObjectByName(relacao.jogadorId)?.position.x,scene.getObjectByName(relacao.jogadorId)?.position.y,scene.getObjectByName(relacao.jogadorId)?.position.z);
        var verticeF = new THREE.Vector3(scene.getObjectByName(relacao.jogadorAmigoId)?.position.x,scene.getObjectByName(relacao.jogadorAmigoId)?.position.y,scene.getObjectByName(relacao.jogadorAmigoId)?.position.z);
        var distance = verticeI.distanceTo(verticeF);
        var position  = verticeF.clone().add(verticeI).divideScalar(2);


        var forca = relacao.forcaLigacao /100;


        var material = new THREE.MeshPhongMaterial({color:0x9F9F9F});
        var cylinder = new THREE.CylinderGeometry(0.25+forca,0.25+forca,distance,10,10,false);

        

        var orientation = new THREE.Matrix4();
        var offsetRotation = new THREE.Matrix4();
        orientation.lookAt(verticeI,verticeF,new THREE.Vector3(0,1,0));
        offsetRotation.makeRotationX(metade_pi);
        orientation.multiply(offsetRotation);
        cylinder.applyMatrix4(orientation);

        var mesh = new THREE.Mesh(cylinder,material);
        mesh.position.add(position);
        mesh.castShadow = true;
        mesh.receiveShadow = true;
        this.jogService.GetJogador(relacao.jogadorId).subscribe(data =>{
            this.jogService.GetJogador(relacao.jogadorAmigoId).subscribe(data2 =>{
                mesh.name = data.email + '/' + data2.email;
                console.log(mesh.name);
                mesh.userData = {type: "cilindro"};
                scene.add(mesh);
            })
        })
        
        

        let x = (verticeI.x + verticeF.x) / 2;
        let y = (verticeI.y + verticeF.y) / 2;

        this.textSprite = new TextSprite();
        var sprite = this.textSprite.makeTextSprite(relacao.forcaLigacao,{});

        var vet = new THREE.Vector3(x ,y,0);

        sprite.position.add(vet);

        scene.add(sprite);
    }
}
