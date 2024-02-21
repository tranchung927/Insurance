using AutoMapper;
using Server.Data.ClientSupport;
using Server.Data.HomeInsurance;
using Server.Data.LifeInsurance;
using Server.Data.VehicleInsurance;
using Server.Models.ClientSupport;
using Server.Models.HomeInsurance;
using Server.Models.LifeInsurance;
using Server.Models.VehicleInsurance;

namespace Server.Helpers
{

    public class ApplicationMapper : Profile
    {
        // các cấu hình map
        public ApplicationMapper()
        {
            // Information 
            CreateMap<InformationModel, InformationEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<InformationEntity, InformationModel>();

            // JobsRisk
            CreateMap<JobsRiskModel, JobsRiskEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<JobsRiskEntity, JobsRiskModel>();

            // VehicleType
            CreateMap<VehicleTypeModel, VehicleTypeEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<VehicleTypeEntity, VehicleTypeModel>();

            // VehicleType
            CreateMap<VehiclePropertyModel, VehiclePropertyEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<VehiclePropertyEntity, VehiclePropertyModel>();

            // HomeCoefficient
            CreateMap<HomeCoefficientModel, HomeCoefficientEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<HomeCoefficientEntity, HomeCoefficientModel>();

            // HomeType
            CreateMap<HomeTypeModel, HomeTypeEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<HomeTypeEntity, HomeTypeModel>();

            // RiskCoefficient
            CreateMap<RiskCoefficientModel, RiskCoefficientEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<RiskCoefficientEntity, RiskCoefficientModel>();


            // SizeType
            CreateMap<SizeTypeModel, SizeTypeEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SizeTypeEntity, SizeTypeModel>();

            // lấy hết hai chiều
            CreateMap<DeathRateEntity, DeathRateModel>().ReverseMap();
            CreateMap<WorkplaceEntity, WorkplaceModel>().ReverseMap();

        }
    }
}
