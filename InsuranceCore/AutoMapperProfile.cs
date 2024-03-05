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

            CreateMap<Category, GetCategoryDto>();
            CreateMap<Post, GetPostDto>();
            CreateMap<Role, GetRoleDto>();
            CreateMap<Ticket, GetTicketDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<User, GetAccountDto>();

            CreateMap<GetCategoryDto, UpdateCategoryDto>();
            CreateMap<GetPostDto, UpdatePostDto>();
            CreateMap<GetRoleDto, UpdateRoleDto>();
            CreateMap<GetTicketDto, UpdateTicketDto>();
            CreateMap<GetAccountDto, UpdateAccountDto>();

            CreateMap<UpdateCategoryDto, GetCategoryDto>();
            CreateMap<UpdatePostDto, GetPostDto>();
            CreateMap<UpdateRoleDto, GetRoleDto>();
            CreateMap<UpdateTicketDto, GetTicketDto>();
            CreateMap<UpdateAccountDto, GetAccountDto>();

            CreateMap<Post, int>().ConvertUsing(x => x.Id);
            CreateMap<User, int>().ConvertUsing(x => x.Id);
            CreateMap<Category, int>().ConvertUsing(x => x.Id);
            CreateMap<Role, int>().ConvertUsing(x => x.Id);
            CreateMap<Ticket, int>().ConvertUsing(x => x.Id);

            CreateMap<int, Post>().ConvertUsing<PostIdConverter>();
            CreateMap<int, User>().ConvertUsing<UserIdConverter>();
            CreateMap<int, Category>().ConvertUsing<CategoryIdConverter>();
            CreateMap<int, Role>().ConvertUsing<RoleIdConverter>();
            CreateMap<int, Ticket>().ConvertUsing<TicketIdConverter>();

            CreateMap<UpdateCategoryDto, Category>().ConvertUsing<UpdateCategoryConverter>();
            CreateMap<UpdateAccountDto, User>().ConvertUsing(new UpdateAccountConverter());
            CreateMap<UpdatePostDto, Post>().ConvertUsing<UpdatePostConverter>();

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionAction, PermissionActionDto>().ConvertUsing(new PermissionActionConverter());
            CreateMap<PermissionRange, PermissionRangeDto>().ConvertUsing(new PermissionRangeConverter());
            CreateMap<PermissionTarget, PermissionTargetDto>().ConvertUsing(new PermissionTargetConverter());
        }
    }
}
