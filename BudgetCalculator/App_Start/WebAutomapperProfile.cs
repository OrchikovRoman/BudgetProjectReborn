using AutoMapper;
using BLBudgetCalculator.Models;
using BudgetCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculator.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryModel>().ReverseMap();

            CreateMap<OperationModel, OperationViewModel>().ReverseMap();
            CreateMap<OperationViewModel, OperationModel>().ReverseMap();
        }
    }
}