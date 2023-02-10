import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { JogadorDto } from '../jogador';
import { RelacaoDto } from '../relacao';
import { JogadorService } from '../jogador.service';
import * as THREE from 'three';
import { RelacoesListNivelDto } from '../relacoesListNivel';
import Nodes from '../rede/Nodes';
import Graph from '../rede/Graph';
import { GUI } from 'dat.gui';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls';
import { FlyControls } from 'three/examples/jsm/controls/FlyControls';
import { Material, Object3D, SphereGeometry } from 'three';
import { Camera } from 'three';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FontLoader } from 'three/examples/jsm/loaders/FontLoader';
import { TextGeometry } from 'three/examples/jsm/geometries/TextGeometry';
import { AlgoritmosService } from '../algoritmos.service';

@Component({
  selector: 'app-rede',
  templateUrl: './rede.component.html',
  styleUrls: ['./rede.component.css']
})
export class RedeComponent implements OnInit, AfterViewInit {

  @ViewChild('canvas')
  private canvasRef: ElementRef;

  jogador: JogadorDto;

  emailJogObj : string;

  jogadorObjetivo : JogadorDto;

  meshs : THREE.Mesh[] = []; 

  amigo: JogadorDto;

  obj : Object3D<THREE.Event> | undefined;

  nodes: Nodes;

  graph: Graph;

  nodeTemp : any;

  tiptemp : any;

  light1 : THREE.PointLight;

  light2 : THREE.PointLight;

  light4 : THREE.PointLight;

  sphereMesh: THREE.Mesh;

  raycaster = new THREE.Raycaster;

  scene2d: THREE.Scene;

  scene3d: THREE.Scene;

  jogadoresList : string[] = [];

  camera: THREE.PerspectiveCamera;

  miniMapCamera: THREE.OrthographicCamera;

  firstPersonCamera: THREE.PerspectiveCamera;

  nivel: number;

  renderer: THREE.WebGLRenderer;

  clock: THREE.Clock;

  relacoesList: RelacoesListNivelDto[] = [];

  pickPosition = {x:0, y:0};

  constructor(private jogadorService: JogadorService,public snackBar: MatSnackBar, private algoService : AlgoritmosService) {
  }

  ngOnInit(): void {
    this.clock = new THREE.Clock();
    //nivel de profundidade inicial
    this.nivel = 3;

    //inicializaçao da gui
    const gui = new GUI({
      width: 350,
      autoPlace: false,
    });

    //associar o gui ao template da rede
    var customContainer = document.getElementById('gui-container');
    if (customContainer)
      customContainer.appendChild(gui.domElement);

    //adicionar variaveis ao gui
    const graphParams = {
      nivelParam: this.nivel,
      x: 0,
      y: 0,
      z: 0,
      jogobjetivo: '',
    }
    gui.add(graphParams, 'nivelParam', 0, 10).name('Nível de Profundidade').step(1).
      onFinishChange(() => {
        this.setNivel(graphParams.nivelParam);
      });

      gui.add(graphParams, 'jogobjetivo', 0, 10).name('Jogador Objetivo Caminho').
      onFinishChange(() => {
        this.setJogadorObjetivo(graphParams.jogobjetivo);
      });

    var folder = gui.addFolder("lookAt");
    folder.open();

    folder.add(graphParams, 'x', 0, 1000).name('x').step(1).
      onChange(() => {
        this.updateCamera(graphParams.x, graphParams.y, graphParams.z);
      });

    folder.add(graphParams, 'y', 0, 1000).name('y').step(1).
      onChange(() => {
        this.updateCamera(graphParams.x, graphParams.y, graphParams.z);
      });

    folder.add(graphParams, 'z', 0, 1000).name('z').step(1).
      onChange(() => {
        this.updateCamera(graphParams.x, graphParams.y, graphParams.z);
      });

    //retirar a data do jogador passada no routing
    this.jogador = history.state.data;
    //this.nivel= parseFloat((document.getElementById("nivel") as HTMLInputElement).value);

    //obtem todas as relaçoes em cada nivel de profundidade
    this.jogadorService.GetAllRelacoesPorNivelJogador(this.jogador.id, this.nivel).subscribe(data => {
      this.relacoesList = data;
      this.Scene();
      this.startRenderingLoop();
    });
  }


  private get canvas(): HTMLCanvasElement {
    return this.canvasRef.nativeElement;
  }

  Scene() {

    //criar a scene para o mini-mapa
    this.scene2d = new THREE.Scene();

    //criar a scene para o jogo em si
    this.scene3d = new THREE.Scene();

    //Criar a camera de primeira pessoa
    this.firstPersonCamera = new THREE.PerspectiveCamera(70, window.innerWidth / window.innerHeight, 0.1, 2000);
    this.firstPersonCamera.position.z = 50;
    this.firstPersonCamera.position.y = -20;
    this.firstPersonCamera.position.x = 0;
    this.firstPersonCamera.lookAt(0, 0, 0);

    //creating main camera
    this.camera = new THREE.PerspectiveCamera(5, window.innerWidth / window.innerHeight, 1, 2000);
    this.camera.position.z = 1500;

    //creating mini-map camera
    this.miniMapCamera = new THREE.OrthographicCamera(-100, 100, 100, -100);
    this.miniMapCamera.up = new THREE.Vector3(0, 0, 0);
    this.miniMapCamera.lookAt(new THREE.Vector3(0, -1, 0));
    this.miniMapCamera.position.y = 50;

    //background da scene definido como branco
    this.scene2d.background = new THREE.Color(0xFFFFFF);

    //Criar a esfera do Jogador Central
    const geometryJog = new THREE.SphereGeometry(1.5, 32, 16);
    const materialJog = new THREE.MeshPhongMaterial({ color: 0x2980b9 });
    const sphereJog = new THREE.Mesh(geometryJog, materialJog);

    this.sphereMesh = sphereJog;

    sphereJog.userData = { type: "sphere" };

    sphereJog.name = this.jogador.id;

    this.scene2d.add(sphereJog);

    let jog = this.jogador;
    let scene = this.scene2d;
    let camera = this.firstPersonCamera;

    const loader = new FontLoader();


    /* loader.load("https://threejs.org/examples/fonts/droid/droid_sans_bold.typeface.json", function ( font ) {

      let tipx = sphereJog.position.x + 0.5;
      let tipy = sphereJog.position.y + 3;
      const text = new TextGeometry(("Nome: " + jog.nome + "\n" + "Email: " + jog.email + "\n" + "Tags: " + jog.listaTags), {
      font: font,
      size: 0.3,
      height: 0.01,
      curveSegments: 12});

      text.center();
      const material = new THREE.MeshBasicMaterial({ color: 'black' });
      const sprite = new THREE.Mesh(text, material);
      sprite.position.z = 1.5;
      sprite.position.y += tipy;
      sprite.position.x = tipx;
      sprite.name = "tip " + jog.id;
      sprite.visible = false;
                        
      //console.log(sprite);
      scene.add(sprite);
      sprite.lookAt(camera.position);
    }); */

    
    this.nodes = new Nodes(this.jogadorService);
    this.graph = new Graph(this.jogadorService);
    var nivel1 = 0;
    var nivel2 = 0;
    var nivel3 = 0;
    var nivel4 = 0;
    var nivel5 = 0;
    var nivel6 = 0;
    var nivel7 = 0;
    var nivel8 = 0;
    var nivel9 = 0;
    var nivel10 = 0;
    var angulo1 = 10;
    var angulo2 = 20;
    var angulo3 = 30;
    var angulo4 = 40;
    var angulo5 = 50;
    var angulo6 = 60;
    var angulo7 = 70;
    var angulo8 = 80;
    var angulo9 = 90;
    var angulo10 = 100;
    var anguloAux = 0;

    //Criar as esferas dos outros jogadores
    this.relacoesList.forEach(element => {
      if (element.key == 1) {
        nivel1++;
      } else if (element.key == 2) {
        nivel2++;
      } else if (element.key == 3) {
        nivel3++;
      } else if (element.key == 4) {
        nivel4++;
      } else if (element.key == 5) {
        nivel5++;
      } else if (element.key == 6) {
        nivel6++;
      } else if (element.key == 7) {
        nivel7++;
      } else if (element.key == 8) {
        nivel8++;
      } else if (element.key == 9) {
        nivel9++;
      } else if (element.key == 10) {
        nivel10++;
      }
    });

    this.relacoesList.forEach(element => {
      if (element.key <= this.nivel) {
       
      if (element.key == 1) {
        angulo1 = angulo1 + 2 * Math.PI / nivel1;
        anguloAux = angulo1;
      } else if (element.key == 2) {
        angulo2 = angulo2 + 2 * Math.PI / nivel2;
        anguloAux = angulo2;
      } else if (element.key == 3) {
        angulo3 = angulo3 + 2 * Math.PI / nivel3;
        anguloAux = angulo3;
      } else if (element.key == 4) {
        angulo4 = angulo4 + 2 * Math.PI / nivel4;
        anguloAux = angulo4;
      } else if (element.key == 5) {
        angulo5 = angulo5 + 2 * Math.PI / nivel5;
        anguloAux = angulo5;
      } else if (element.key == 6) {
        angulo6 = angulo6 + 2 * Math.PI / nivel6;
        anguloAux = angulo6;
      } else if (element.key == 7) {
        angulo7 = angulo7 + 2 * Math.PI / nivel7;
        anguloAux = angulo7;
      } else if (element.key == 8) {
        angulo8 = angulo8 + 2 * Math.PI / nivel8;
        anguloAux = angulo8;
      } else if (element.key == 9) {
        angulo9 = angulo9 + 2 * Math.PI / nivel9;
        anguloAux = angulo9;
      } else if (element.key == 10) {
        angulo10 = angulo10 + 2 * Math.PI / nivel10;
        anguloAux = angulo10;
      }
      this.nodes.addNodeJogadorAmigo(this.scene2d, element.key, element.value, anguloAux, this.firstPersonCamera);
      //Cria a conexão com os amigos se estes já existirem
      this.graph.criarConexao(this.scene2d, element.value);
    }
    });

    this.light1 = new THREE.PointLight(0xffffff, 0.5, 100);
    this.light1.position.set(20, 0, 20);
    this.light1.castShadow = true;
    this.light1.shadow.mapSize.width = 100;
    this.light1.shadow.mapSize.height = 100;
    this.light1.name = 'light1';

    this.light2 = new THREE.PointLight(0xffffff, 0.5, 100);
    this.light2.position.set(-20, 0, 20);
    this.light2.castShadow = true;
    this.light2.shadow.mapSize.width = 100;
    this.light2.shadow.mapSize.height = 100;
    this.light2.name = 'light2';
    this.scene2d.add(this.light1);
    this.scene2d.add(this.light2);
    this.light4 = new THREE.PointLight(0xffffff, 0.8, 200);
    this.light4.position.set(this.firstPersonCamera.position.x, this.firstPersonCamera.position.y, this.firstPersonCamera.position.z);
    this.light4.castShadow = true;
    this.light4.shadow.mapSize.width = 20;
    this.light4.shadow.mapSize.height = 20;
    this.light4.name = 'light4';
    this.scene2d.add(this.light4);

    const light3 = new THREE.AmbientLight(0x404040); // soft white light
    this.scene2d.add(light3);
  }

  private startRenderingLoop() {
    this.renderer = new THREE.WebGLRenderer({
      canvas: this.canvas,
      antialias: true,
    });

    this.renderer.setPixelRatio(devicePixelRatio);
    this.renderer.setSize(this.canvas.clientWidth, this.canvas.clientHeight);
    let component: RedeComponent = this;

    //Adicao de controlos pan e move para o mini mapa
    const controlsMiniMap = new OrbitControls(this.miniMapCamera, this.renderer.domElement);
    controlsMiniMap.enableRotate = false;
    controlsMiniMap.enableDamping = true;
    controlsMiniMap.enablePan = true;
    controlsMiniMap.update();

    //Criaçao de controlos em primeira pessoa
    const controlsFirstPerson = new FlyControls(this.firstPersonCamera,this.renderer.domElement);
    controlsFirstPerson.rollSpeed = 50;
    controlsFirstPerson.movementSpeed = 100;
    controlsFirstPerson.dragToLook = true;
    controlsFirstPerson.autoForward = false;
    controlsFirstPerson.update(this.clock.getDelta());

    let rayc = this.raycaster;
    let camera = this.firstPersonCamera;
    let scene = this.scene2d;
    let renderer = this.renderer;

    const mouse = {
      x: 0,
      y: 0
    }

    var rect = this.renderer.domElement.getBoundingClientRect();

    let canvas = this.canvas;

    let nodeTemp = this.nodeTemp;

    let tiptemp = this.tiptemp;

    let light4 = this.light4;


    let relacoesList = this.relacoesList;

    let firstPersonCamera = this.firstPersonCamera;

    scene.children.forEach(element => {
      //@ts-ignore
      if(element.userData.type === "sphere"){
        this.jogadoresList.push(element.name);
      }
    });

    let jogadores = this.jogadoresList;
    let t = this;
    let email = this.emailJogObj;
    
    (function render() {

      let cameraPosition = new THREE.Vector3(0,0,0) ;
      cameraPosition.x = camera.position.x
      cameraPosition.y = camera.position.y
      cameraPosition.z = camera.position.z;
      
      requestAnimationFrame(render);

      light4.position.set(firstPersonCamera.position.x, firstPersonCamera.position.y, firstPersonCamera.position.z);

      //Setup dos viewports
      component.createViewPorts(component, canvas); 

      //controls update
      controlsMiniMap.update();
      controlsFirstPerson.update(component.clock.getDelta());

      //detetar a relação com as esferas dos jogadores
      jogadores.forEach(element => {
        let node = scene.getObjectByName(element);
        
        //@ts-ignore
        let distance = Math.sqrt( Math.pow(node?.position.x - camera.position.x, 2) + Math.pow(node?.position.y - camera.position.y, 2) + Math.pow(node?.position.z - camera.position.z, 2) )
        if(distance < 2){
          camera.position.x = cameraPosition.x
          camera.position.y = cameraPosition.y
          camera.position.z = cameraPosition.z
        }
      });
      
      //detetar a colisão com o cilindro da relação
      let posicao1;
      let posicao2;
      let pontoMedio = new THREE.Vector3(0,0,0);
        relacoesList.forEach(element => {
          let node1 = scene.getObjectByName(element.value.jogadorId);
          let node2 = scene.getObjectByName(element.value.jogadorAmigoId);
          //@ts-ignore
          let posicao1 = node1?.position;
  
          //@ts-ignore
          let posicao2 = node2?.position;
          let angle;
          //@ts-ignore
          posicao1.sub( camera.position );
          //@ts-ignore
            posicao2.sub( camera.position  );
          //@ts-ignore
            angle = posicao1.angleTo( posicao2 );
  
          //@ts-ignore
          posicao1.add( camera.position );
          //@ts-ignore
          posicao2.add( camera.position );
  
          if(angle > 2.9){
          camera.position.x = cameraPosition.x
          camera.position.y = cameraPosition.y
          camera.position.z = cameraPosition.z
          }
          
        });
      
      
    }());

    this.renderer.domElement.addEventListener('mousemove', onMouseMove, false)

function onMouseMove(event: MouseEvent) {
  const rect = renderer.domElement.getBoundingClientRect();
    const mouse = {
        x: ( ( event.clientX - rect.left ) / ( rect.right - rect.left ) ) * 2 - 1 ,
        y: -( ( event.clientY - rect.top ) / ( rect.bottom - rect.top) ) * 2 + 1,
    }

    //console.log(mouse)

    rayc.setFromCamera(mouse, camera)

    const intersects = rayc.intersectObjects(scene.children, true);

    if(tiptemp != null){
      tiptemp.visible = false;
    }
    
    if(nodeTemp != null){
      nodeTemp.material.opacity = 1;
    }

    if (intersects.length > 0) {  
      
      for(let i=0; i<intersects.length;i++){
        //console.log(tiptemp);
        
        let objeto
        
        //@ts-ignore
        if(intersects[i].object.userData.type === "sphere"){
          var tip = scene.getObjectByName("tip " + intersects[i].object.name);

          //console.log(tip);
          //@ts-ignore
          tip?.visible = true;
          tip?.lookAt(camera.position);
          //@ts-ignore
          objeto = intersects[i].object;
          //@ts-ignore
          intersects[i].object.material.transparent = true;
          //@ts-ignore
          intersects[i].object.material.opacity = 0.2;

          tiptemp = tip;
          nodeTemp = objeto;
        }
      }
    }
}
  }

  ngAfterViewInit() {
    this.Scene();
    this.startRenderingLoop();

  }


  setNivel(niv: number) {
    this.nivel = niv;
    this.ngAfterViewInit();
  }


  createViewPorts(component: RedeComponent, canvas: HTMLCanvasElement) {
    //viewport do jogo
    component.renderer.setViewport(0, 0, canvas.clientWidth, canvas.clientHeight);
    component.renderer.setScissor(0, 0, canvas.clientWidth, canvas.clientHeight);
    component.renderer.setScissorTest(true);
    component.camera.updateProjectionMatrix();
    component.renderer.render(component.scene2d, component.firstPersonCamera);

    //borda do mini-mapa
    component.renderer.setScissorTest(true);
    component.renderer.setScissor(canvas.clientWidth - 202, 0, 202, 202);
    component.renderer.setClearColor(0x000000, 1);
    component.renderer.clearColor();

    //viewport do mini-mapa
    component.renderer.setViewport(canvas.clientWidth - 200, 1, 200, 200);
    component.renderer.setScissor(canvas.clientWidth - 200, 1, 200, 200);
    component.renderer.setScissorTest(true);
    component.miniMapCamera.updateProjectionMatrix();
    component.renderer.render(component.scene2d, component.miniMapCamera);
  }

  updateCamera(x: number, y: number, z: number) {
    this.firstPersonCamera.lookAt(x, y, z);
  }

  setJogadorObjetivo(jogadorObj : string){
    this.emailJogObj = jogadorObj;
    this.drawCaminho(this.emailJogObj);
  }


  async drawCaminho(jogadorObj : string) : Promise<void>{

    
    this.jogadorService.GetJogadorByEmail(jogadorObj).subscribe(data =>{
      this.jogadorObjetivo = data;
    })

    await new Promise(f => setTimeout(f,1000));

    let jogadorpassado = this.jogador.email;
    let jogatual;

     this.algoService.getBfs(this.jogador.email,this.jogadorObjetivo.email,100).subscribe( data =>{
      data.x.forEach( element => {
        if(element != jogadorpassado){

          if (this.scene2d.getObjectByName(jogadorpassado + "/" + element) != null) {
            ((this.scene2d.getObjectByName(jogadorpassado + "/" + element) as THREE.Mesh).material as THREE.Material) = new THREE.MeshBasicMaterial({ color: 0xff9538 });
          }
          if (this.scene2d.getObjectByName(element + "/" + jogadorpassado) != null) {
            ((this.scene2d.getObjectByName(element + "/" + jogadorpassado) as THREE.Mesh).material as THREE.Material) = new THREE.MeshBasicMaterial({ color: 0xff9538 });
          }
          //this.obj = this.scene2d.getObjectByName(jogadorpassado + "/" + element);
          jogadorpassado = element;
        }
      });
    })
  }
}
