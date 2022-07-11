using AgricultureServer.Database;
using AgricultureServer.DTO;
using AutoMapper;

namespace AgricultureServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AttractingWorker, AttractingWorkerDTO>().ReverseMap();
            CreateMap<Crop, CropDTO>().ReverseMap();
            CreateMap<CropIncomeAndExpense, CropIncomeAndExpensesDTO>().ReverseMap();
            CreateMap<Field, FieldDTO>().ReverseMap();
            CreateMap<PlannedRequirement, PlannedRequirementDTO>().ReverseMap();
            CreateMap<PlannedWaybill, PlannedWaybillDTO>().ReverseMap();
            CreateMap<SalesInvoice, SalesInvoiceDTO>().ReverseMap();
            CreateMap<TechnologicalOperation, TechnologicalOperationDTO>().ReverseMap();
            CreateMap<WorkerQualification, WorkerQualificationDTO>().ReverseMap();
            CreateMap<WorkOrder, WorkOrderDTO>().ReverseMap();
        }
    }
}