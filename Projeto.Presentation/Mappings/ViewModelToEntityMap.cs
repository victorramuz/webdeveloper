using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projeto.Presentation.ViewModels;
using Projeto.Entities;
using Projeto;

namespace Projeto.Presentation.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        //construtor
        public ViewModelToEntityMap()
        {
            CreateMap<ClienteCadastroViewModel, Cliente>();
            CreateMap<ClienteEdicaoViewModel, Cliente>();

            CreateMap<UsuarioCadastroViewModel, Usuario>()
                .AfterMap((src, dest)
                    => dest.Password = MD5Configuration.Encrypt(src.Password));
        }
    }
}
