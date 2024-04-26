using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Requests
{
    public class UpdateDisciplineRequest : IRequest<ApiResponse>
    {
        public UpdateDisciplineRequest()
        {

        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long KnowledgeAreaId { get; set; }
    }
}
