using Microsoft.Extensions.DependencyInjection;
using QLHS.Repository;
using QLHS.Services;

namespace QLHS.RegisterService
{
    public static class ConfigRegister
    {
        public static IServiceCollection ListServices(this IServiceCollection services)
        {
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IGradesService, GradesService>();
            services.AddScoped<IRegulationService, RegulationService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReportService, ReportServices>();
            return services;
        }
        public static IServiceCollection ListRepository(this IServiceCollection services)
        {
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IGradesRepository, GradesRepository>();
            services.AddScoped<IRegulationRepository, RegulationRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            return services;
        }
    }
}
