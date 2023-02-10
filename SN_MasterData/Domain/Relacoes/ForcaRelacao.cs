using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialNetwork.Domain.Relacoes
{
   
    [ComplexType]
    public class ForcaRelacao 
    {
        public int forca{get; set;}
        
        public ForcaRelacao(){
        }

         public void ChangeForcaRelacao(int forca){
             if(!verificarForcaRelacao(forca))
               throw new BusinessRuleValidationException("A força de relação tem de ser entre 0 e 100");
           
            this.forca = forca;
        }


       public ForcaRelacao(int forcaR){
           if(!verificarForcaRelacao(forcaR))
               throw new BusinessRuleValidationException("A força de relação tem de ser entre 0 e 100");
           
           this.forca = forcaR;
        }

        public bool verificarForcaRelacao(int forca){
            if(forca >= 0 && forca <= 100){
                return true;
            }else{
                return false;
            }
        }
    }
}