using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Utils
{
    public class ValidationUtil
    {
        public static Hashtable GetErrors(ModelStateDictionary modelState)
        {
            var erros = new Hashtable();

            foreach(var state in modelState)
            {
                if(state.Value.Errors.Count > 0)
                {
                    //nome do campo  |  mensagens de erro do campo
                    erros[state.Key] = state.Value.Errors
                                        .Select(e => e.ErrorMessage).ToList();
                }
            }

            return erros;
        }
    }
}
