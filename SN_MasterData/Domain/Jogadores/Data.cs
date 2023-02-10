using System;
using SocialNetwork.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Domain.Jogadores
{
    [ComplexType]
    public class Data : IValueObject
    {
      
        public DateTime DataNascimento;



        private Data()
        { }

        public Data(string dataNascimento)
        {
           this.Atualizar(dataNascimento);
        }

        public bool Atualizar(string dataNascimento)
        {
            try{
                this.DataNascimento = DateTime.Parse(dataNascimento);
                return VerificarIdade(this.DataNascimento);
            }catch{
                return false;
            }
        }

        private bool VerificarIdade(DateTime dataNascimento)
        {

            int AnoBase = DateTime.Today.Year - 16;

            if (dataNascimento.Year < AnoBase) {
                return true;
            }

            if (AnoBase == dataNascimento.Year){
                if (dataNascimento.Month < DateTime.Now.Month){
                    return true;
                }

                if (dataNascimento.Month == DateTime.Now.Month){
                    if (dataNascimento.Day <= DateTime.Now.Day){
                         return true;
                     }
                }
             }
            return false;
        }

    }
}