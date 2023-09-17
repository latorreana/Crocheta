using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crocheta.Models
{
    public class Contato
   {
        public int idContato {get;set;}
        public string nomeContato {get;set;}
        public string telefone {get;set;}
        public string email {get;set;}
        public string mensagem {get;set;}
        
        public Contato(string nomeContato, string telefone, string email, string mensagem) 
        {
            
        }    
        public Contato()
        {

        }
    }
}