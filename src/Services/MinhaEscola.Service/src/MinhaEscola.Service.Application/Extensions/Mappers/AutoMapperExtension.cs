using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Address.Responses;
using MinhaEscola.Service.Application.UseCases.Class.Responses;
using MinhaEscola.Service.Application.UseCases.Component.Responses;
using MinhaEscola.Service.Application.UseCases.Discipline.Responses;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Responses;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Responses;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;
using MinhaEscola.Service.Application.UseCases.Modality.Responses;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Application.UseCases.School.Responses;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;
using MinhaEscola.Service.Application.UseCases.Stage.Responses;
using MinhaEscola.Service.Application.UseCases.Student.Requests;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Limits;
using MinhaEscola.Service.Domain.Administractive.Modality.Limits;
using MinhaEscola.Service.Domain.Administractive.Stage.Limits;
using MinhaEscola.Service.Domain.Core.Address.Limits;
using MinhaEscola.Service.Domain.Administractive.Discipline.Limits;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Limits;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;
using MinhaEscola.Service.Domain.Academic.Class.Limits;
using MinhaEscola.Service.Domain.Board.School.Limits;
using MinhaEscola.Service.Domain.Academic.Student.Limits;
using System.Reflection;

namespace MinhaEscola.Service.Application.Extensions.Mappers
{
    public class AutoMapperExtension : Profile
    {
        public AutoMapperExtension()
        {
            CreateMap<SchoolResponse, School>().ReverseMap();
            CreateMap<AddressRequest, Address>().ReverseMap();
            CreateMap<CreateSchoolRequest, School>().ForMember(x => x.Address, opt => opt.MapFrom(y => y.Address)).ReverseMap();
            CreateMap<CreateStudentRequest, Student>().ReverseMap();

            CreateMap<UpdatePhysicalPersonRequest, PhysicalPerson>();
            CreateMap<CreatePhysicalPersonRequest, PhysicalPerson>();

            CreateMap<AddressResponse, Address>().ReverseMap();

            CreateMap<CreateLevelEducationRequest, LevelEducation>();
            CreateMap<UpdateLevelEducationRequest, LevelEducation>();
            CreateMap<LevelEducationResponse, LevelEducation>().ReverseMap();

            CreateMap<CreateStageRequest, Stage>();
            CreateMap<UpdateStageRequest, Stage>();
            CreateMap<StageResponse, Stage>().ReverseMap();
            
            CreateMap<SchoolComponentResponse, SchoolComponent>().ReverseMap();

            CreateMap<CreateModalityRequest, Modality>();
            CreateMap<UpdateModalityRequest, Modality>();
            CreateMap<ModalityResponse, Modality>().ReverseMap();
            CreateMap<ComponentResponse, Component>().ReverseMap();

            CreateMap<DisciplineResponse, Discipline>().ReverseMap();
            
            CreateMap<DenominationResponse, Denomination>().ReverseMap();

            CreateMap<ClassesResponse, Class>().ReverseMap();
            CreateMap<KnowledgeAreaResponse, KnowledgeArea>().ReverseMap();
            CreateMap<SchoolDisciplineResponse, DisciplineComponent>().ReverseMap();

        }
    }
}
