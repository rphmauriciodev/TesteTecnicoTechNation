using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteTecnicoTechNation.Application.DTOs;
using TesteTecnicoTechNation.Domain.Entities;

namespace TesteTecnicoTechNation.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<NotaFiscal, NotaFiscalDTO>().ReverseMap();
            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<DadosGerais, DadosGeraisDTO>().ReverseMap();
            CreateMap<Receita, ReceitaDTO>().ReverseMap();
            CreateMap<Inadimplencia, InadimplenciaDTO>().ReverseMap();
        }
    }
}
