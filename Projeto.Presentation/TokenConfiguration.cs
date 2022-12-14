using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation
{
    public class TokenConfiguration
    {
        //quem poderá utilizar o token
        public string Audience { get; set; }

        //armazenar as informações de credencial
        //do usuario para o qual o token é gerado
        public string Issuer { get; set; }

        //tempo de expiração do token
        public int Seconds { get; set; }
    }
}
