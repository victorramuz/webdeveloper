﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Projeto.Presentation
{
    public class LoginConfiguration
    {
        //propriedades
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        //construtor
        public LoginConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials
                (Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
