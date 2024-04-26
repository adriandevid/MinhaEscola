﻿using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Domain.Base.EnumTypes;

namespace MinhaEscola.Service.Application.UseCases.Component.Requests
{
    public class CreateComponentRequest : IRequest<ApiResponse>
    {
        public string Name { get; set; }
        public long DenominationId { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public long StageId { get; set; }
        public long ModalityId { get; set; }
    }
}
