using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = Ex.DAL.DO.Objetos;

namespace Ex.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Libros, DataModels.Libros>().ReverseMap();
            CreateMap<data.Autores, DataModels.Autores>().ReverseMap();
        }
    }
}
