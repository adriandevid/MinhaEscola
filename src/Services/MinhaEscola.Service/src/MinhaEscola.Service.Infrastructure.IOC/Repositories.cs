using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinhaEscola.Service.Application.UseCases.Address.Interfaces;
using MinhaEscola.Service.Application.UseCases.Address.Queries;
using MinhaEscola.Service.Application.UseCases.Class.Interfaces;
using MinhaEscola.Service.Application.UseCases.Class.Queries;
using MinhaEscola.Service.Application.UseCases.Component.Interfaces;
using MinhaEscola.Service.Application.UseCases.Component.Queries;
using MinhaEscola.Service.Application.UseCases.Discipline.Interfaces;
using MinhaEscola.Service.Application.UseCases.Discipline.Queries;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Interfaces;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Queries;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Interfaces;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Queries;
using MinhaEscola.Service.Application.UseCases.Modality.Interfaces;
using MinhaEscola.Service.Application.UseCases.Modality.Queries;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;
using MinhaEscola.Service.Application.UseCases.School.Queries;
using MinhaEscola.Service.Application.UseCases.Stage.Interfaces;
using MinhaEscola.Service.Application.UseCases.Stage.Queries;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Modality.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Stage.Interfaces;
using MinhaEscola.Service.Domain.Core.Address.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Discipline.Interfaces;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Services;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Interfaces;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories;
using MinhaEscola.Service.Infrastructure.Data.Resources.EventEvaluator;
using MinhaEscola.Service.Infrastructure.Data.Resources.UnitOfWork;

namespace MinhaEscola.Service.Infrastructure.IOC
{
    public static class Repositories
    {
        public static IServiceCollection RegisterServicesToRepositories(this IServiceCollection services) {
            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IUnitOfWorkResource, UnitOfWorkResource>();
            services.AddScoped<ISchoolQueries, SchoolQueries>();
            services.AddScoped<IEventEvaluatorResource, EventEvaluatorResource>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressQueries, AddressQueries>();
            services.AddScoped<IComponentRepository, ComponentRepository>();
            services.AddScoped<IDisciplineRepository, DisciplineRepository>();
            services.AddScoped<IModalityQueries, ModalityQueries>();
            services.AddScoped<IModalityRepository, ModalityRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IStageQueries, StageQueries>();
            services.AddScoped<ILevelEducationRepository, LevelEducationRepository>();
            services.AddScoped<ILevelEducationQueries, LevelEducationQueries>();

            services.AddScoped<IClassManager, ClassManager>();
            services.AddScoped<IClassRepository, ClassRepository>();

            services.AddScoped<IDisciplineQueries, DisciplineQueries>();
            services.AddScoped<IClassQueries, ClassQueries>();
            services.AddScoped<IDisciplineRepository, DisciplineRepository>();
            services.AddScoped<IComponentQueries, ComponentQueries>();

            services.AddScoped<IKnowledgeAreaRepository, KnowledgeAreaRepository>();
            services.AddScoped<IKnowledgeAreaQueries, KnowledgeAreaQueries>();

            return services;
        }
    }
}
