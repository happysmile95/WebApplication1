using Data.Repository;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Compositions
{
    public static class ServiceCompositions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyHandler, CompanyHandler>();
            services.AddScoped<IDepartamentHandler, DepartmentHandler>();
            services.AddScoped<IDivisionHandler, DivisionHandler>();
            services.AddScoped<IFileSystemManager, FileSystemManager>();
            services.AddScoped<IImportService, DepartmentHandler>();
            services.AddScoped<IExportService, DepartmentHandler>();
            services.AddScoped<IImportXmlService, ImportXmlService>();
            services.AddScoped<IExportXmlService, ExportXmlService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDepartamentRepository, DepartmentRepository>();
            services.AddScoped<IDivisionRepository, DivisionRepository>();
        }
    }
}
