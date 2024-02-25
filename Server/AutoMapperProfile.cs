using AutoMapper;
using Server.Data.Permission;
using Server.Data;
using Server.Models.DTOs.Account.Converters;
using Server.Models.DTOs.Account;
using Server.Models.DTOs.Category.Converters;
using Server.Models.DTOs.Category;
using Server.Models.DTOs.Permission.Converters;
using Server.Models.DTOs.Permission;
using Server.Models.DTOs.Post.Converters;
using Server.Models.DTOs.Post;
using Server.Models.DTOs.Role;
using Server.Models.DTOs.Tag.Converter;
using Server.Models.DTOs.Tag;
using Server.Models.DTOs.User;
using Server.Models.DTOs.User.Converter;
using Server.Models.DTOs.Role.Converters;

namespace Server
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
            CreateMap<AddTagDto, Tag>();
            CreateMap<AddAccountDto, User>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<Post, GetPostDto>();
            CreateMap<Role, GetRoleDto>();
            CreateMap<Tag, GetTagDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<User, GetAccountDto>();

            CreateMap<GetCategoryDto, UpdateCategoryDto>();
            CreateMap<GetPostDto, UpdatePostDto>();
            CreateMap<GetRoleDto, UpdateRoleDto>();
            CreateMap<GetTagDto, UpdateTagDto>();
            CreateMap<GetAccountDto, UpdateAccountDto>();

            CreateMap<UpdateCategoryDto, GetCategoryDto>();
            CreateMap<UpdatePostDto, GetPostDto>();
            CreateMap<UpdateRoleDto, GetRoleDto>();
            CreateMap<UpdateTagDto, GetTagDto>();
            CreateMap<UpdateAccountDto, GetAccountDto>();

            CreateMap<Post, int>().ConvertUsing(x => x.Id);
            CreateMap<User, int>().ConvertUsing(x => x.Id);
            CreateMap<Category, int>().ConvertUsing(x => x.Id);
            CreateMap<Role, int>().ConvertUsing(x => x.Id);
            CreateMap<Tag, int>().ConvertUsing(x => x.Id);

            CreateMap<int, Post>().ConvertUsing<PostIdConverter>();
            CreateMap<int, User>().ConvertUsing<UserIdConverter>();
            CreateMap<int, Category>().ConvertUsing<CategoryIdConverter>();
            CreateMap<int, Role>().ConvertUsing<RoleIdConverter>();
            CreateMap<int, Tag>().ConvertUsing<TagIdConverter>();

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
