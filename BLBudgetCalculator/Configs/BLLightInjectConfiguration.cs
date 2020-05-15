using DALBudgetCalculator.Interfaces;
using DALBudgetCalculator.Repositories;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLBudgetCalculator.Configs
{
    public static class BLLightInjectConfiguration
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return container;
        }
    }
}
