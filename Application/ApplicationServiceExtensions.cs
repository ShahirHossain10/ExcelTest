using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPatientRepository), typeof(PatientRepository));
        services.AddTransient(typeof(ICommonRepository), typeof(CommonRrepository));
    }
}