using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lms.Core.DTOs;

namespace Lms.Data.Data.AutoMapper
{
    internal class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Tournament, LmsDto>();
        }
    }
}
