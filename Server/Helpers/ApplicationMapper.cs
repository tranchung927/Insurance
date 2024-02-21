using AutoMapper;
using Server.Data.ClientSupport;
using Server.Data.LifeInsurance;
using Server.Data.Users;
using Server.Models.ClientSupport;
using Server.Models.LifeInsurance;
using Server.Models.Users;

namespace Server.Helpers
{

    public class ApplicationMapper : Profile
    {
        // các cấu hình map
        public ApplicationMapper()
        {
            // bỏ qua id
            CreateMap<InformationModel, InformationEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            // lấy hết
            CreateMap<InformationEntity, InformationModel>();

            // bỏ qua id
            CreateMap<JobsRiskModel, JobsRiskEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            // lấy hết
            CreateMap<JobsRiskEntity, JobsRiskModel>();

            //CreateMap<VehicleTypeModel, VehicleType>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());
            //CreateMap<VehicleType, VehicleTypeModel>();

            // lấy hết hai chiều
            CreateMap<DeathRateEntity, DeathRateModel>().ReverseMap();
            CreateMap<WorkplaceEntity, WorkplaceModel>().ReverseMap();

        }
    }
}
