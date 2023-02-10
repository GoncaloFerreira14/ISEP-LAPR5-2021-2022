using System;
using System.Collections;
using System.Collections.Generic;
using SocialNetwork.Domain.EstadosEmocionais;

namespace SocialNetwork.Domain.EstadosEmocionais
{
    public class EstadoEmocionalDto
    {

        public string Id{get;set;}
        public EstadosHumor EstadoHumor { get; set; }
        public string Data {get; set;}
        public double ValorEstado {get; set;}
       
    }
}