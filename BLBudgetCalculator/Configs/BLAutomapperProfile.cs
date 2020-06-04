using AutoMapper;
using BLBudgetCalculator.Models;
using DALBudgetCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLBudgetCalculator.Configs
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<OperationModel, Operation>().ReverseMap();
            CreateMap<Operation, OperationModel>().ReverseMap();

            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
