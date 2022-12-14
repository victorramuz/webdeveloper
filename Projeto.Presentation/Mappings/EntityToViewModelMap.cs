using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projeto.Presentation.ViewModels;
using Projeto.Entities;

namespace Projeto.Presentation.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        //construtor
        public EntityToViewModelMap()
        {
            CreateMap<Cliente, ClienteConsultaViewModel>();
        }
    }
}
