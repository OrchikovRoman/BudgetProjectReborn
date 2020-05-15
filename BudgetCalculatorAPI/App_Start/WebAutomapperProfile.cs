using AutoMapper;
using BLBudgetCalculator.Models;
using BudgetCalculatorAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculatorAPI.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<CategoryModel, CategoryData>().ReverseMap();
            CreateMap<CategoryData, CategoryModel>().ReverseMap();

            CreateMap<OperationModel, OperationData>().ReverseMap();
            CreateMap<OperationData, OperationModel>().ReverseMap();
        }
    }
}