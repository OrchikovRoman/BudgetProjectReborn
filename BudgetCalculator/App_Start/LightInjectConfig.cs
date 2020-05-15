using AutoMapper;
using BLBudgetCalculator.Configs;
using BLBudgetCalculator.Interfaces;
using BLBudgetCalculator.Services;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BudgetCalculator.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectConfiguration.Configuration(container);

            container.Register<ICategoryService, CategoryService>();
            container.Register<IOperationService, OperationService>();

            container.EnableMvc();
        }
    }
}