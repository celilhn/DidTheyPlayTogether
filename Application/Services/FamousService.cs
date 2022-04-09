using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FamousService : IFamousService
    {
        private readonly IFamousRepository famousRepository;
        private readonly IMapper mapper;

        public FamousService(IFamousRepository famousRepository, IMapper mapper)
        {
            this.famousRepository = famousRepository;
            this.mapper = mapper;
        }

        public FamousDto GetFamous(int id)
        {
            return mapper.Map<FamousDto>(famousRepository.GetFamous(id));
        }

        public FamousDto GetFamous(string name)
        {
            return mapper.Map<FamousDto>(famousRepository.GetFamous(name));
        }

        public List<FamousDto> GetFamouses()
        {
            return mapper.Map<List<FamousDto>>(famousRepository.GetFamouses());
        }

        public FamousDto SaveFamous(FamousDto famous)
        {
            if (famous.ID > 0)
            {
                Famous famousTemp = famousRepository.GetFamous(famous.ID);
                famousTemp.Age = famous.Age;
                famousTemp.DateBirh = famous.DateBirh;
                famousTemp.Education = famous.Education;
                famousTemp.Name = famous.Name;
                famousTemp.Size = famous.Size;
                famousTemp.Weight = famous.Weight;
                famousTemp.SourceID = famous.SourceID;
                famousTemp = famousRepository.UpdateFamous(famousTemp);
                famous = mapper.Map<FamousDto>(famousTemp);
            }
            else
            {
                famous = mapper.Map<FamousDto>(famousRepository.AddFamous(mapper.Map<Famous>(famous)));
            }
            return famous;
        }
    }
}
