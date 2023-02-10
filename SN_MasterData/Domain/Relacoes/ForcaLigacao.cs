using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialNetwork.Domain.Relacoes
{
   
    [ComplexType]
    public class ForcaLigacao 
    {
        public int forca{get; set;}
        
        public ForcaLigacao(){
        }

         public void ChangeForcaLigacao(int forca){
             if(!verificarForcaLigacao(forca))
               throw new BusinessRuleValidationException("A força de ligação tem de ser entre 0 e 100");
           
            this.forca = forca;
        }


       public ForcaLigacao(int forcaLig){
           if(!verificarForcaLigacao(forcaLig))
               throw new BusinessRuleValidationException("A força de ligação tem de ser entre 0 e 100");
           
           this.forca = forcaLig;
        }

        public bool verificarForcaLigacao(int forca){
            if(forca >= 0 && forca <= 100){
                return true;
            }else{
                return false;
            }
        }
    }
}