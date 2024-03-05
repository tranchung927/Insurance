using AutoMapper;
using InsuranceCore.Data.Permission;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Account.Converters;
using InsuranceCore.Models.DTOs.Account;
using InsuranceCore.Models.DTOs.Category.Converters;
using InsuranceCore.Models.DTOs.Category;
using InsuranceCore.Models.DTOs.Permission.Converters;
using InsuranceCore.Models.DTOs.Permission;
using InsuranceCore.Models.DTOs.Post.Converters;
using InsuranceCore.Models.DTOs.Post;
using InsuranceCore.Models.DTOs.Role;
using InsuranceCore.Models.DTOs.User;
using InsuranceCore.Models.DTOs.User.Converter;
using InsuranceCore.Models.DTOs.Role.Converters;
using InsuranceCore.Models.DTOs.Ticket;
using InsuranceCore.Models.DTOs.Ticket.Converters;
using InsuranceCore.Models.DTOs.DeathRate;
using InsuranceCore.Models.DTOs.VehicleProperty;
using InsuranceCore.Models.DTOs.VehicleType;
using InsuranceCore.Models.DTOs.Workplace;
using InsuranceCore.Models.DTOs.HouseType;
using InsuranceCore.Models.DTOs.HouseCoefficient;
using InsuranceCore.Models.DTOs.HouseSize;
using InsuranceCore.Models.DTOs.HouseSize.Converters;
using InsuranceCore.Models.DTOs.DeathRate.Converters;
using InsuranceCore.Models.DTOs.VehicleProperty.Converters;
using InsuranceCore.Models.DTOs.VehicleType.Conveters;
using InsuranceCore.Models.DTOs.Workplace.Converters;
using InsuranceCore.Models.DTOs.HouseType.Converters;
using InsuranceCore.Models.DTOs.HouseCoefficient.Converters;

namespace InsuranceCore
{

    /// <inheritdoc />
    public class AutoMapperProfile : Profile
    {
        /// <inheritdoc />
        public AutoMapperProfile()
        {
            CreateMap<AddCategoryDto, Category>();
            CreateMap<AddPostDto, Post>();
            CreateMap<AddRoleDto, Role>();
            CreateMap<AddTicketDto, Ticket>();
            CreateMap<AddAccountDto, User>();
            CreateMap<AddDeathRateDto, DeathRate>();
            CreateMap<AddVehiclePropertyDto, VehicleProperty>();
            CreateMap<AddVehicleTypeDto, VehicleType>();
            CreateMap<AddWorkplaceDto, Workplace>();
            CreateMap<AddHouseTypeDto, HouseType>();
            CreateMap<AddHouseCoefficientDto, HouseCoefficient>();
            CreateMap<AddHouseSizeDto, HouseSize>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<Post, GetPostDto>();
            CreateMap<Role, GetRoleDto>();
            CreateMap<Ticket, GetTicketDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<User, GetAccountDto>();
            CreateMap<DeathRate, GetDeathRateDto>();
            CreateMap<VehicleProperty, GetVehiclePropertyDto>();
            CreateMap<VehicleType, GetVehicleTypeDto>();
            CreateMap<Workplace, GetWorkplaceDto>();
            CreateMap<HouseType, GetHouseTypeDto>();
            CreateMap<HouseCoefficient, GetHouseCoefficientDto>();
            CreateMap<HouseSize, GetHouseSizeDto>();


            CreateMap<GetCategoryDto, UpdateCategoryDto>();
            CreateMap<GetPostDto, UpdatePostDto>();
            CreateMap<GetRoleDto, UpdateRoleDto>();
            CreateMap<GetTicketDto, UpdateTicketDto>();
            CreateMap<GetAccountDto, UpdateAccountDto>();
            CreateMap<GetDeathRateDto, UpdateDeathRateDto>();
            CreateMap<GetVehiclePropertyDto, UpdateVehiclePropertyDto>();
            CreateMap<GetVehicleTypeDto, UpdateVehicleTypeDto>();
            CreateMap<GetWorkplaceDto, UpdateWorkplaceDto>();
            CreateMap<GetHouseTypeDto, UpdateHouseTypeDto>();
            CreateMap<GetHouseCoefficientDto, UpdateHouseCoefficientDto>();
            CreateMap<GetHouseSizeDto, UpdateHouseSizeDto>();

            CreateMap<UpdateCategoryDto, GetCategoryDto>();
            CreateMap<UpdatePostDto, GetPostDto>();
            CreateMap<UpdateRoleDto, GetRoleDto>();
            CreateMap<UpdateTicketDto, GetTicketDto>();
            CreateMap<UpdateAccountDto, GetAccountDto>();
            CreateMap<UpdateDeathRateDto, GetDeathRateDto>();
            CreateMap<UpdateVehiclePropertyDto, GetVehiclePropertyDto>();
            CreateMap<UpdateVehicleTypeDto, GetVehicleTypeDto>();
            CreateMap<UpdateWorkplaceDto, GetWorkplaceDto>();
            CreateMap<UpdateHouseTypeDto, GetHouseTypeDto>();
            CreateMap<UpdateHouseCoefficientDto, GetHouseCoefficientDto>();
            CreateMap<UpdateHouseSizeDto, GetHouseSizeDto>();

            CreateMap<Post, int>().ConvertUsing(x => x.Id);
            CreateMap<User, int>().ConvertUsing(x => x.Id);
            CreateMap<Category, int>().ConvertUsing(x => x.Id);
            CreateMap<Role, int>().ConvertUsing(x => x.Id);
            CreateMap<Ticket, int>().ConvertUsing(x => x.Id);
            CreateMap<DeathRate, int>().ConvertUsing(x => x.Id);
            CreateMap<VehicleProperty, int>().ConvertUsing(x => x.Id);
            CreateMap<VehicleType, int>().ConvertUsing(x => x.Id);
            CreateMap<Workplace, int>().ConvertUsing(x => x.Id);
            CreateMap<HouseType, int>().ConvertUsing(x => x.Id);
            CreateMap<HouseCoefficient, int>().ConvertUsing(x => x.Id);
            CreateMap<HouseSize, int>().ConvertUsing(x => x.Id);

            CreateMap<int, Post>().ConvertUsing<PostIdConverter>();
            CreateMap<int, User>().ConvertUsing<UserIdConverter>();
            CreateMap<int, Category>().ConvertUsing<CategoryIdConverter>();
            CreateMap<int, Role>().ConvertUsing<RoleIdConverter>();
            CreateMap<int, Ticket>().ConvertUsing<TicketIdConverter>();
            CreateMap<int, DeathRate>().ConvertUsing<DeathRateIdConverter>();
            CreateMap<int, VehicleProperty>().ConvertUsing<VehiclePropertyIdConveter>();
            CreateMap<int, VehicleType>().ConvertUsing<VehicleTypeIdConverter>();
            CreateMap<int, Workplace>().ConvertUsing<WorkplaceIdConverter>();
            CreateMap<int, HouseType>().ConvertUsing<HouseTypeIdConverter>();
            CreateMap<int, HouseCoefficient>().ConvertUsing<HouseCoefficientIdConverter>();
            CreateMap<int, HouseSize>().ConvertUsing<HouseSizeIdConverter>();

            CreateMap<UpdateCategoryDto, Category>().ConvertUsing<UpdateCategoryConverter>();
            CreateMap<UpdateAccountDto, User>().ConvertUsing(new UpdateAccountConverter());
            CreateMap<UpdatePostDto, Post>().ConvertUsing<UpdatePostConverter>();
            CreateMap<UpdateTicketDto, Ticket>().ConvertUsing<UpdateTicketConverter>();
            CreateMap<UpdateDeathRateDto, DeathRate>();
            CreateMap<UpdateVehiclePropertyDto, VehicleProperty>();
            CreateMap<UpdateVehicleTypeDto, VehicleType>();
            CreateMap<UpdateWorkplaceDto, Workplace>();
            CreateMap<UpdateHouseTypeDto, HouseType>();
            CreateMap<UpdateHouseCoefficientDto, HouseCoefficient>();
            CreateMap<UpdateHouseSizeDto, HouseSize>();

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionAction, PermissionActionDto>().ConvertUsing(new PermissionActionConverter());
            CreateMap<PermissionRange, PermissionRangeDto>().ConvertUsing(new PermissionRangeConverter());
            CreateMap<PermissionTarget, PermissionTargetDto>().ConvertUsing(new PermissionTargetConverter());
        }
    }
}
