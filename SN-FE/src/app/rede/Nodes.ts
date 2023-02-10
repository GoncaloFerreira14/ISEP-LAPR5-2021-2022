//AQUI VAI BUSCAR AS RELAÇÕES POR NIVEL E VAI CRIAR OS CIRCULOS QUE SÃO OS JOGADORES

import * as THREE from 'three';
import { Vector3 } from 'three';
import { JogadorDto } from '../jogador';
import { JogadorService } from '../jogador.service';
import { RelacaoDto } from '../relacao';
import { RelacoesListNivelDto } from '../relacoesListNivel';
import TextSprite from './TextSprite';
import { EstadoEmocionalDto } from '../estadoEmocional';
import { TextGeometry } from 'three/examples/jsm/geometries/TextGeometry';
import { Font, FontLoader } from 'three/examples/jsm/loaders/FontLoader';

export default class Nodes {


    textSprite: TextSprite;
    spriteEA: THREE.Sprite;

    

    constructor(private JogadorService: JogadorService) {
    }

    /*addNodeJogador(scene: THREE.Scene, nivel: number, relacao: Relacao, nome : string) {
        const object = <THREE.Object3D><any>scene.getObjectByName(relacao.jogadorId);

        if (object == null) {
            const geometryJog = new THREE.SphereGeometry(1.5, 32, 16);
            const materialJog = new THREE.MeshBasicMaterial({ color: 0xFF8000 });
            const sphereJog = new THREE.Mesh(geometryJog, materialJog);

            sphereJog.name = relacao.jogadorId;

            const randx = Math.floor((Math.random() * (13 - 5 + 1) + 5) * (Math.round(Math.random()) ? 1 : -1));

            const randy = Math.floor((Math.random() * (13 - 5 + 1) + 5) * (Math.round(Math.random()) ? 1 : -1));

            sphereJog.position.add(new Vector3(0, 0, 0));

            scene.add(sphereJog);

            this.textSprite = new TextSprite();

            var sprite = this.textSprite.makeTextSprite(relacao.jogadorAmigoId,{});

            var vet = new THREE.Vector3(sphereJog.position.x,sphereJog.position.y,sphereJog.position.z + geometryJog.parameters.radius);

            sprite.position.add(vet);

            scene.add(sprite);
        }
    }*/

    addNodeJogadorAmigo(scene: THREE.Scene, nivel: number, relacao: RelacaoDto, anguloAux: any, camera : any) {
        const object = <THREE.Object3D><any>scene.getObjectByName(relacao.jogadorAmigoId);

        if (object == null) {
            const geometryJog = new THREE.SphereGeometry(1.5, 32, 16);
            const materialJog = new THREE.MeshPhongMaterial({ color: 0xFF8000 });
            const sphereJog = new THREE.Mesh(geometryJog, materialJog);

            sphereJog.name = relacao.jogadorAmigoId;
            /*
            const randx = Math.floor((Math.random() * (13 - 5 + 1) + 5) * (Math.round(Math.random()) ? 1 : -1));

            const randy = Math.floor((Math.random() * (13 - 5 + 1) + 5) * (Math.round(Math.random()) ? 1 : -1));

            */

            const i = Math.random() * (360 - 1) + 1;

            const angle = (i * Math.PI) / 180;

            sphereJog.position.add(new Vector3(nivel * 10 * Math.cos(anguloAux), nivel * 10 * Math.sin(anguloAux), 0));

            sphereJog.receiveShadow = true;
            sphereJog.castShadow = true;

            sphereJog.userData = { type: "sphere" }

            scene.add(sphereJog);

            this.JogadorService.GetJogador(relacao.jogadorAmigoId)
                .subscribe(data => {
                    if (data) {

                        /* this.textSprite = new TextSprite();

                        var spriteNome = this.textSprite.makeTextSprite(data.nome, {});
                        var spriteEmail = this.textSprite.makeTextSprite(data.email, {});

                        var vetJogadorNome = new THREE.Vector3(sphereJog.position.x, sphereJog.position.y, sphereJog.position.z + 1 + geometryJog.parameters.radius);
                        var vetJogadorEmail = new THREE.Vector3(sphereJog.position.x, sphereJog.position.y, sphereJog.position.z + geometryJog.parameters.radius);

                        spriteNome.position.add(vetJogadorNome);
                        spriteEmail.position.add(vetJogadorEmail);

                        scene.add(spriteNome);
                        scene.add(spriteEmail); */


                        //Tip flutuante
                        const loader = new FontLoader();


                        loader.load("https://threejs.org/examples/fonts/droid/droid_sans_bold.typeface.json", function ( font ) {

                        let tipx = sphereJog.position.x + 0.5;
                        let tipy = sphereJog.position.y + 3;
                        const text = new TextGeometry(("Nome: " + data.nome + "\n" + "Email: " + data.email + "\n" + "Tags: " + data.listaTags), {
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
                        sprite.name = "tip " + data.id;
                        sprite.visible = false;
                        
                        //console.log(sprite);
                        scene.add(sprite);
                        sprite.lookAt(camera.position);
                        });

                        this.JogadorService.GetEstadoHumorByJogadorId(relacao.jogadorAmigoId).subscribe(estado => {
                            if (estado) {
                                var vetEstadoHumor = new THREE.Vector3(sphereJog.position.x, sphereJog.position.y + 1, sphereJog.position.z + geometryJog.parameters.radius + 0.5 );

                                this.spriteEA = this.createEstadoEmocionalSprite(estado);

                                //var spriteEsA = this.spriteEA.makeTextSprite(estado.estadoHumor,{});

                                this.spriteEA.position.add(vetEstadoHumor);

                                scene.add(this.spriteEA);
                            }
                        }

                        )
                    }
                });


        }

    }

    createEstadoEmocionalSprite(estado: EstadoEmocionalDto): THREE.Sprite {
        const texture = this.getTextureOfEstadoEmocional(estado);
        const materialC = new THREE.SpriteMaterial({ map: new THREE.TextureLoader().load(texture), color: 0xffffff, fog: true });
        return new THREE.Sprite(materialC);
    }

    getTextureOfEstadoEmocional(estado: EstadoEmocionalDto): string {
        if (estado.estadoHumor.toLowerCase() == 'joyful') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAABLUExURUdwTAAAAAAAAP/JOgAAAAAAAAAAAAAAAAAAAAAAAP////G9NiQcCuCwMoNmGcSaKjssBlNBFJh4H6mEI3FXFO3t7ZeXl4SEhNDQ0AHhJ2AAAAAKdFJOUwAx//9iFLDvh9P6H0vZAAACYElEQVRYw+1Y0XaDIAydoCIDBES7/f+XDnGtBEGg43H3wdOmx9vkJoHAx8c//oShn0ZKCEKE0HHqh/dYuomiAGTqqn25shyg01BFQ1ASpJyqf9Go1UjBMGZCmlW9qPoybZ5BaWMpfDCjnwF25e7MAcsv11zq1HRH41NN9zzjIY3ANxCHWGOeZ8EZLDmmg0fiLOQ9k9OHC1wAwW906h0Pw0Vgjimau87lXeBCCFcFsXqihfoAnWgisAVXYIkGN+yBKVyFvZ7IEMuYqCMSkcw5h2ZcifnqklOI1RLhq0sUOsRmWyY87NyrdQ4T10GHzHMJMz5PxMr2r10gtb6+AZiiVh3ERv1f97/RkjGpfTd3q7pYDYxtAJHNL7lmT7i41cU2gJydxcjPKDXip1VFrK4oeyDR6uVUev10b8UrEGkEbQaFubc6kUagtcRvQQK1SX2f+f1GABF7j4gBIvQ+kWu39kTNQoNiowIkxIbpryKC6Q8LEqFPi/QzWZBhi1QQwRYJmzZLlGpauIzoPJFOLCNwYVvyREtiYYNL7Z7Rz829lnietRIutXDxV7nkq+TiD7cjkyMyye0o2CA5+kpr9HXmjF03SLhl23L9ThF9e00Q2bKDIWJFfIsTbfws3dgQEYw1TFmmGJHlUex2rAkGLTsi8hgR94bMJTFFwtGPqWhZev6kRr8juFMmZtuRPzyltof1cWX5YfQyHsu9e23p2mLe3AfEZcl4HBnYDahxZQoH9tgRQizavcL1IsqPEO0ONe2OWe0Ofu2Oou0Ox+2O6w0vENpdaaQuWWj9JUvLa59/PPEDUl04vFgzDuIAAAAASUVORK5CYII=";
        }
        if (estado.estadoHumor.toLowerCase() == 'distressed') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAA8UExURUdwTAAAAAAAAP/JOgAAAAAAAAAAAAAAAAAAAAAAANaOAPK8MRcPAYJlGN+vMsecK6J/ITosBuWjDllEDT98t6AAAAAKdFJOUwAx//9iFLDvh9P6H0vZAAACW0lEQVRYw+1YyaKjIBB8roDs+v//OgKjQ9MtkgzHV5ckJFZ6p+Dn5xf/hWXmq2BsHBkTK5+X71gGLsYCjA8f24JZEgRfPqJh4yNYO9V803jtrJHTJI112t9Uc1tsLqcOd1LkkO64HByazVG6YPnLpVWjUTz9JU2TqNIveJ1nTaExUwUmBWt953HTC9wbU+Kx0yusqjLF+CgzNcCoSpzmyCOnJsjIROZuYM323DYxqp4EFR+5bTJ/zeMUK/PBsTJf+3YivAmvksodcm4JjnmK5yba9uLrUE9soTJmSrduQ9L7HRpliMxFgzSgSeZcZlyfAJXGJs155vcT25bZk9kXyPY9rwGOUqZBZJABMl/PTAKJG4K310MkTUF1rYTnhiLUB8wVoklUO8zfUfgmQA3JXVYaRcrsWwd9W3LPPkL0bQE5K4rRaE20HV71oLp5WUSpkdBgIlY1CNKK2ixOUzURPVGsOjDgBPqjNOBLImLVgmgz1GfNRKHfGCCS3xFJQDR+TxTX+hNh12J+PJk1X3ENBztsXHgjCANf2UqwcfpP5eGopkWrMP1ryz79vHuvlRZpBmyRmYpsG2DTdhsjxWDLY6kPH1LlD22fQiSeRu0/lkPlclYdmKsctQPhm/FYGpdSDg1/sB1lQwwDjzXxvEFGqEtp26Cz7a2MkUjiL1t2JMondFLG6mXLxiLCKiS1TyrQaZSIoGVNQzEiWUMLrXeRPDdKv5pEfpB+ybmxgxjtJo/7CfZ+R4h+h5p+x6x+B79+R9F+h+N+x/WOFwj9rjSeLlnE55csPa99fnHhD7jWNp8NrzVHAAAAAElFTkSuQmCC";
        }

        if (estado.estadoHumor.toLowerCase() == 'hopeful') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAAS1BMVEVHcEwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/yD06lt3UjACCZh6gsItMPBIeTXLBly4sc6kPKDvuujnisTY1Y2HbAAAADHRSTlMACR5ZwUB1OvHbrI/hgKiXAAAB30lEQVRYw+3Y246CMBCAYVEEqhQpovj+T7otbNuZnjuXxrlpsilfSP3Ndvd0+s2XTdOxcWRdo1eqc5aPq2F6PRPf5/95O4z2Tt3oTUeC1Ast27aMdmUkSAEb5xtcyRCX85Cj1u+BmhBE+fz7ENQTM1ogtBBDusnnZgjN8gc3Yo8rhFZakWd9RAbaD6n+e3vRR2QhdUiXauiuj8hC6pDu1VCrj8hC6pBaUo4fDH0oSZocAURK0uQIIUqSJkcIUZI0OUKIkKTNEUKEJG2OCKpP0uaIoPokbY4Iqk4S5Iig6iRBjgiqThLkiKHaJEGOGKpNEuSIocokYY4YqkwS5uhAVUleGTwiDKlDYtcyph1hRQ60lzS211IGvBCG9lfKU5qBjgNpKUUZZll5HOLrkqYijA+lKcO8X4LnIC5e7zAFmGmaRA4SclOQQowneZA4dlkKXfIs40ouJMw2TSEIMI7kQALuOygETXhEDBLOxhxkpRkF6jp5SEszSt1zCqBD0l+IQ/KdEkhJs/3LaA46RdAkdmfo+2GXQk4Z9Dwc+etpl55UyDgpqQACTkLKQ8iJS1nIcaJSDvKcmJSBAk5E8iB/Bu/acUj+pKEhcH2JSEloCF6DwlIKGiLXqaD0+3dU2fwBBgl3Q247uMEAAAAASUVORK5CYII=";
        }

        if (estado.estadoHumor.toLowerCase() == 'relieved') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAA/UExURUdwTAAAAAAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAAP/JOtiQAfK9MoFkGKOAIeGuLSIYAsmeLFVBDDwtBryUKcReHVgAAAAKdFJOUwDKMf/fFLCH8mKPLtcBAAACaklEQVRYw+1Y2YKDIAysiqKUS+T/v3UrKkKIiF0eO08tlWnIxcTX64d/oZ/o0JCx60bSDHTqv2NpKekACG0f25KyHFz9I5qxu8RYTjV5mkXIWXHGuJqlWDzVVOabZn/eyA9FCC7N/lPTlpsjAMvOJUqNojmakIrmeYbNNYploDZnDfc8kt1A3jFtPDO7xZxncv7RihVA6YyfJsfDWRG4Y0Jj17q4K1YI5bIAy6em0D+Rn5qLg0n2ABI9XL8ebGGPsObT2GMRU8+IFBI5Z5BgDyFSk5yH+FMilppEUoO4en/gyfn6TfHUJBLlEDTIbXM4VvxC9Ni6rwWuNhgNQhRRGXA2EuXQG9sUkr+jXArO1ocn8zugQxjf3Bbyu7P1UcwWYM9VCIFNS5TdNIhZnua0OIgbjRqaDImyGcVDIhk1uLXw7ZH3oS+vj6eCHtBEQVOnSwvaGg/r7Qzb+FV9+LCNnqj7nsiV2wVR8Pnzf/lVQDQCosPxzIZENmiyF0eLnM30WXam02fmYavA2U3U9oXPThH0FnwVhH+Iana11ljOrelixyCrICFp3NbkKc/k3WpcIhO4QSyyI2CS4CaZ8DayiaDPjayhSEJWQRsBje3hJUmuW205YKttvyySpPlj11HpDUkqXJA8vSCrXdlQRFit0ShKfdYuKiKgrNGoSN6EcV7WAKG1DxGRgJv3ASIvtID0O4pEm3WqWWcao/cleyP9gBidNT5k6flWjEJ5LDAeX2gZeZwKdj9VpXNXVrAjIwS3YvONNsLy4hGi3lBTb8yqN/jVG0XrDcf1xvWKLxDqvdKo+JKl5mufHw78AWsDbtKHDQ14AAAAAElFTkSuQmCC";
        }

        if (estado.estadoHumor.toLowerCase() == 'disappointed') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAABOUExURUdwTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP/JOtaOAPK+NvG2JOGxMoFkGCkeA5h3Hw8KAT8wB8idK1VCDK6IJNKWE7aDyD8AAAALdFJOUwAxW7MUccqK8t+t1H4gsQAAAmVJREFUWMPtWMmCqyAQHJdEjQTZgv7/lz4B44SmWZLwblMng1LphW4Kfn7+8BX6duiu0zjP43Tthrb/jKUZphlgGpq3bbkELAfX5R27+mGcoxiHYqrLSfPgUjNKCGVa8sdJdSmLzfX4ft12ilfQbT1eXQti1TpzFAcsBxdXzqg2xzO4v8RpHJX7Ykjz3FxoGEmAuWDdUjyd/USSDKT9rMvYozTJQqskk42PYKQATCTi1FoeSopALROau8bkXTFSCGa8G7H1ZNehH5/lfl+wZxcnuzKRugjztc+9358/zPMS5i6olt449gh5PCLAZNbT2GMZYyHPEvlpw4RkzhrEEzwoEw9NMhFSlCSnhUNUBVGagEEIDzZoTJq8NWS8pRkeZJiaeQ0I9ZrlQV6sINzGs+33dYwHLglCNt+3HngW5QGL9PCt98pVREoDYVrAomy9EHHyEbgXpK6kLcabZecVvv6MSHstYIJ1Vg7mpW30kvZCun/2fFToqE3beBL52X+c29G+8Yj0qPnbeY4QyVfJINOjgMh3jYjfGQIfpRHXQLDZOUfkR71gB+mXdpKQ/t70HI2nv9qCrFYisGjfgF+0sI2UA7QR2NjKARobbLXlgK22ifmm+Sr2PUeJleuYZ01qO3Isq6+wV43lbEpvkKdU9ADEJbJBhlv2huv+LbNlhyJCHTZIbZS/lod9KiMiQlkjrGp/LU+r1VVO1gRCS4tA/FMp1JYTWqj0y7Z9TPrVE6NOHqvv5XE9wf72EeL2/w819Y5Z9Q5+9Y6i9Q7H3nFdfHNcr3iBUO9Ko+Ily3ntc/v+2ucPT/wDchWafSN6lkwAAAAASUVORK5CYII=";
        }
        if (estado.estadoHumor.toLowerCase() == 'proud') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAABFUExURUdwTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP/JOnV1dfTANyUcCd6uMUw6CquGI3RaFYttG8meLERERGVlZZUDtNcAAAAKdFJOUwCwMcsFXxWI8uBYVgUcAAACjUlEQVRYw+1Y3dajIAysYhV1+VP7vf+jriAiCVGxy959c9GeIzDChITB1+sX/4T23VWs58PAe1Z17/Yrkqbu+gGh7+rHc0lZdq72EQ0fTsHzqd6BRk5mUWIchVrMJAPVu8mhqZnvr81KEUMY7ZtYnT+dGbF4rnmf1F2suiuamKq7XF5TbYtS4wXUtsCqueWZxxvMN0yeZxlvsVwzOX2kGjOg3F7oTuLleMSYBeGYcOwai9rFXQkAMBZAuV1Qu6GB6DwfZqwwiQyig+mCJ4soC+WJ4trz+WMhie6nLf0R+JjJdf+hXnzS0seboMcv/pxO6XM6H1uDXGr4lh/Xn5pS0mLsT42SQ4+TL4vwxdIIYSTVsg7RKFHsyozf9kjVLWd8E9J7GQ1cW2ufrgMMoarZ9qMh9NbrC+x/C9JV2u46VdWnmyD0tvVGgtS1Ek2uOqSq7imStmj7eAIiVWEJqd6IKGpZ9iVXgYiFuiiSjYuIhihke61kIGgKiIq6H/Id2AYoEDZ+iIoHhMKr6Ppig8BB9u9EImaKzyUVN8g5XjJJ9BSAiH9PBJfWx2I8AxSb5R2LZ0clIzbkY8ANGVLkOWCKhKR9Dpi0bRJ/pWlrg5+jMuILG3wR5QJsKkosUZ+UWrTNdEqk4zTeH3S4+AukYap/8lTg4u/WNieuZYJuZEp8z4yPo80bicSTyUg4f5IoPCHotlqOveMSLPtqmVSw6wv2krwlbJ9K3R0E9IWKsn9uSprQNgbUzIWMt6SDRMZYAapJESaZuAEw0hp7cVapBGWRGXWZ4cOTsuTN6H+yx4UNe7krRLFLTblrVrmLX7mraMHLcdZ1vdgHhCb/y0iZTxqbVkU+sthJUZ99mtcvvsdfQiqNen1Ey28AAAAASUVORK5CYII=";
        }
        if (estado.estadoHumor.toLowerCase() == 'remorseful') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAA5UExURUdwTAEAAP/JOtaOAAAAAAAAAAAAAAAAAAAAAAAAAPK8MoBkGOGwMSwgA8ecK006CuKeCa+JJJx6IKPYOV8AAAAKdFJOUwD///9iKrDvh9OUC5XkAAACI0lEQVRYw+2Y3aKDIAiAl/2YpKa9/8OeWasJklnHy3G1Mf3GjxL0ev3kX9J346CkbBop1TB2/UPKqBoiarzPSik76x5GNqciy1HdgTHTYjUIAdoukzlQXVlsdqdm/0bEAn7eHezLzZkI5cOaSo0ac5gYdRGpYXNKi4zozcHhmrOIC1muSBvHikuxedIaH6NFgWiTiVO3ckAUCawkNnf9mnctCkWvp4A7T6owPihO6sSxRdyQhXcuODaLWxLOk2Qzpu+BNJe5YNAkbsqUmrRGCO6CRGqSemLQZhJKXP/MIAFhX09CTVMGDDjRzcS34JnHS1zbOspJdR77lnoG7z1tS0FB10LGt5Azg35ft3AWUZJBp3vEOdvMSQ36mNQ6wHkbUUHbrxloly4npPdvEF24AcXaHh61vF+xd+3ho0XRlp97RhbxRyda9LlvEoEgArns2QQXgQCB9uyHf3Pu+oQDOLdbHfYmoCeCQPI5CJIY6eg/IFqW15JgK1T2o882BnFakv4B1X3zLQTz9+bwWnIg8RWZji9TpOa15IrgSxviN1sAO8ehQ1o4ubSkjPhvw+hFXktLpDrZ42kR4+gqU2ohdJ6Gtm2MlpbaasW/2uPo4QMSmGd2rUc230R4PDzYkiaCbWvoGFLS1rCNFuGYokaLa/0sBvmi1q9eM1qtPa7XsNcbIeoNNfXGrHqDX71RtN5wXG9cr/gCoeIrjYovWSq+9vnJLn9LKyXxuEWUMwAAAABJRU5ErkJggg==";
        }
        if (estado.estadoHumor.toLowerCase() == 'grateful') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAABvUExURUdwTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAsHAAAAAP/JOgC98vXEPOy5NS0hA6eDI1E+C9+vMtzGVIRnGcSaKnVaFQCUvy/Az5zFhXvDnQi14AZheVLBuQAkMQB5nABLYL/DZ1+jiJqpYjeKhPZMxmcAAAAKdFJOUwAgDzpg7KzQifuLqMzkAAADfUlEQVRYw+1Y25arIAytVhFQtF6rVmvbmf//xgN4KQG02nUeJ09txG2SnQTC6fQn34pz9jBGQeD7hHIhvh8ECGPv7BzA8HDg01XxA+x9RnM9tIGhoCHP3YA5I0IJ3SV8ITqvwHiBuvJ+f3TD7+vnmTMu+fPn9Tt0j/tdXRN4tsi8Ye7dcI2iqG9YCIQ1PVdfh+6NFhhWeWQGERhRdGvz0CJ5e5OPrzMY0YzCo/oxokRRy8IVYe205PoY38HAnhHmNq2p83BD8n5adhuhFJsc6ddsTdSEH6SZV16ldw50bMK5dnn4UfLuqiC9nROEDdLYgSZxuEPi5C5fiDpB3QIkPLuN+PtwBBK9C6tuwjcLENmJw5EINYGEa5209JXvBcpfFtfUYNfNnmA3tTXYjqz4YSa1brfA8qat55WD7ATOakJKtL5tmmee85rl6cz4j2fTtH2tLDETcnKuYI267oPUDSuMEhlNYrIqd2HVsqaZYZDkrZjL8gk90DH69jmXdAU4E61RQMMU4iFp+76up7jd6rrnUXtCFmLx3lkLURp+IakWJOHZRf1SkfBqqbQ0jyuhLVTtBfrmzqFWHktRwa1aGW4HcJZY3gDv2LUJ4E2EqAIRTEvGylRlwK6VvL2DhMBXiiUT3r80bQXsRCDWpWJt+iYl2daGJYi2AMqWZwooX7atDTNRtQuQD9xWCGQqUGzRStp80CFZ+J0IFv8/kP89EAM92wfBPiQw2JD+QwLpR3pZ7ReYkLBEDgksEa1ohetpag2aoYdF61CdNv7ctuny7RV+UWsjRmOT2ZHaGyIN1xub2WqF62bYTK3eao3mzxJpE3CXSXsSttX8wXa0JBolRO2Q43EVxLrQtyPJGwHfL8f3SFVmjGVlNf0FecuIsdO6vm5SmCXmeT+B3AuDfNdyPoaEj1u7KgUzt0esTzO+hfCsUmGqzJIMvjHbeNRWcOxSJTwQJKkuzFZm1DKNBPRYMympQZlybCO7kTICz+q6cweOx3bHFuaSXTaNuYHXJkhk5txKfGR6ovVZFFG6p1mO5wm0NRyPSOmme3H6GWeZAIv1wa+wzHtW7qbqLKz0xQWxTqCnrSk5vehHv0s6z8T77iO85Q6BV0aZcbg4Ky/V0g18b++lhos3riMIdg/csbg4sMMEh2DGPm5iBfj85d2Ph5G4+BGXPmjPHc2fbMo/N76hAzVnvncAAAAASUVORK5CYII=";
        }
        if (estado.estadoHumor.toLowerCase() == 'angry') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABIBAMAAACnw650AAAAMFBMVEVHcEwSBAEAAAAAAAAAAAAAAAAAAAAAAAABAADwOhevDRlyFwxGDQjXMhWXIQ+/LBI+lxWEAAAACHRSTlMA+duGtBhcOlB5ZJoAAAK+SURBVEjHzZZBaxNBFMfXxLZ+AWUVaqW55BiKQo+CUHIsCOIxQgWPHj26aYx/TIx4c0zSpTed1p6TYvWaFCx4jBXEW6t+gAYRnJl9Mzu7O1t67DskO4/fzJv35r1543nnUlas73s3F/1g8c5DS7WmflFapfHcEkhKj0k1s4QIQqMWLVOGkfotpZqtIoJ8Ut31YUmgVHKahoAVb1b+tz/9Y+zH75Fcq+atKTyGUBIL44CR/BGDRrTDgKCPZGGPGTkk2wcElcG3lWLILOmqafscdYJ+8S0x8QtLyHfB7PIdgqoC4jujDkvJUVvq0SBolwuZpqFQarcIWlbQe5aRtwpaV9Aj7IsRc4hQb6OpoCe45lxILbWJ5wq6hBecT1xQn/N3eKqgAlr8A3PKNz7ADQUV0c66ph0coRJlEcBZjnAflFk+9vKgQzo6Gc1xHtSjWMrDG+ZBXTo6uadJHtQH7Ul4J4ab19PAzwXxo70rQCaAn95YD4FMBYrTfbxUUJAIVigyTPy9wTM64LGagkRG0bhHB7ysnOuLmWPbWLRyl1KlimNK6thgqKdsUKDKmNoGlJzo79AUwkTHJNCQD6Os09FRLKH8SX2a4mSnQfpWOQN0JnPl06C+8W6qXQoyUGjK/DhSDNDSkPncMBU81Bk2jJPN6NatA87N36aVKjmiU6WATj50FBdnPmQVp1UIf/3gs6MQEiXVTV6epqREDK5ay8vb3AxfUwQ870IcxC6S9/AAlwkqxps6iaBX8ZYquhPFNTeIoFZce7qDiZh34rRVl7yJUtP0vYvQiaB7lE4BCiXZm3dF8qtlTdoLHBeLqNem1WeFf/OuhYxvlHjItg3fXHNm69kGBNxO9v2qq5U1Uo+DoqspVtJPiAfZ9nol886YyTbq1exrJN3yg5rrzeJ4PLio7DPEIY4HjUscT6NzKv8Bsdjwn1P2ZF4AAAAASUVORK5CYII=";
        }
        if (estado.estadoHumor.toLowerCase() == 'neutral') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAABIUExURUdwTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP/JOg0IAPXBN+CwMqOAIXVbFMWbK4ZpGjwtBu26NR0UAVRBDDe8zXAAAAALdFJOUwBbdjvfsMryGYprS4IwVQAAAe9JREFUWMPtWNl2hCAMrQ4ujAEEt///0xaYzpGACjZ9m/sY9ZqdhK+vD/6EvuJNy7ph6Fjb8Kq/x/LgbEBg/FGsSx2xvLjqEr163g2H6Hg21fNNM+vRKAkglRn1/KZ65qnTvt7fxh+KPeS4vR61GUpVXh0xLZDAMgmvVHXFw/0vJwkHkJN/g5/zNN41Ck6gvLOaa54JLjBeMTkeYeASRpwyOf+sCjKg1hM/VY5ngSwsjikZu97GXSjIhLLWdal8cnloIBvGZWaiLqx8hAK42D2Ths1QhDllnIuYKiNSicg5hSYoxBSrVNuIyVIiaSNXB0QMKSS1EDomxlKrEgv6s7V2n4raCnTKlEC6WMEDuXrbf+K7DiZyUrGXbMjdDOfQkCSKpWNoW2+fyztE0gr6oFxnuEPkkrIKXKTvEenASU1UZrnOdk5qgsI30Y8ywu97QBsETZ2n3pFUBWHrUDqWVIkttzdRFP0C2G/pichMY+VNLe3stqztH4e/Ke37RwnJU9mXh7BEcNGadTjBag6LtkcN8pQnqDbURnBjyydCjQ232nzTcKuNmn8mouYfHUcFJyT7nwOS7MgmGyLoxhqyQYtu9KMbRsnGY7qBnW6FoFtqPJMgWLPoFj+6VZRuOaZb1wkvEOiuNAgvWSivfT74xTfxaZd+M8vlUQAAAABJRU5ErkJggg==";
         }
        if (estado.estadoHumor.toLowerCase() == 'fearful') {
            return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAMAAABiM0N1AAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAB+UExURUdwTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIS/7f/JOgC98gBks/TAN2VOEXex3518IO7IURB0vdzHaSWBxVeAnxAnNENlf02b1sLEl0ExB5nB0Fyl3CO/1ypBUrDDr2ucwgB8n1vCs9CjLgCl1LWOJ7DFd4XElf6ed1YAAAAKdFJOUwB1FF229+yP2C6mF7WUAAADPUlEQVRYw+2Y28KiIBSFp1LxjIc0M7Xs8Ffv/4IjggQbPM10+a87Ib7Ya7MR/PPnV/8lZ4cM2zJd17RsA+2cf6Qg2wWy0WrWdqNQGGuzXYNBpjsqEy1GbaxhUHE8XGOvU3w9HIuh1dos82YI6nLwgA4XNil7gVc7FtUx9jSKjwy1m+MghvFGxVBommPQoGJvQjEN0JjKFuUcvBkd5kiUc/VmdZ0m9f4UsbdAcTHh0w5yylIeLT5TkjZ3Tp93gZOHYS5y5Oe4XwW69WQDf/ZhJxFEnnPgk62pCzlfTc/ZiyDa0si5U6plS+rrwuedh/0oyfi4J4U5byTrydrqMkbrsynpCMDhpHBfNjG3CWRua9K6aMKPcjXrudDd0Goxt6pDzFD2t41u/TT7zy+6R9UlmxUqx5RjS7HcC6AjTJwzOERC2+fldNGW+Z6GRl1ygNUXZUTdnrIsTf1OaZplp7ZWfnIBdttKzdenzNcoO9XKPmCDyCRK6o8qlVhybKRcC97XZv6Mspb/uJBKFwmb69RkxGkJGy+SNjRqUbsI06NabpIheU3qvuZB4ch1IwwHy61ZzfaAj9sWXUWnz5CImBhBEGw90ZVkcRApNK8Wo6KvHAhSWtOapM3kINLdaoZgLUhqbUmLBGIdr9c6kC+BzE/3+bwOhKXQLN79DoL3apAlpf/Rmxd0Speb7fsPKf1kQSak+U5A98Xp75RICxKx/izolS1bkJyNpKKtiNMUdPaXq5KK1qEevgKm12IOBlskcfs5TGjNlJ5g0+5Negdc76WgCGy1/cEoEMTrDifEBbdK8JLItuT5JoLuQnaZEg0oAZGR12MRSMo+C2dQpJ/QBkR2k0F3haMhJfCVTWrtRwad5bi00WHlEAGtJmK/k6WuavlYowclKiiBgYEjhD60SgVVoO5NWz1fq2br7ljAIHgYRWr6XzMgXOmOx87oghwt1kp/YO9LRHDpPPPCfYxdIehhnc/pPsNJxq8iG3rzvHWz+rkVEZ4MK5q60iCwYEZROJm5+G3cJagBM3UVdQyAip6AhZ9DFc9cjh1kdGvcMhC/rldR8sAdDuNHElUrr+tf/IDwvU8aX/zI8s3PPr8a9BeiLqHN2WXEigAAAABJRU5ErkJggg==";
        }
        return 'null';
    }
}

