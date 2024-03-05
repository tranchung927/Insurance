using AutoMapper;
using FluentValidation;
using InsuranceCore.Data.JoiningEntity;
using InsuranceCore.Data;
using InsuranceCore.Models.DTOs.Post;
using InsuranceCore.Models.Exceptions;
using InsuranceCore.Repositories.Category;
using InsuranceCore.Repositories.Post;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Repositories.User;
using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.SortSpecification;
using InsuranceCore.Specifications;

namespace InsuranceCore.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<IPostDto> _dtoValidator;

        public PostService(IPostRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository,
            ICategoryRepository categoryService, IValidator<IPostDto> dtoValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _categoryRepository = categoryService;
            _dtoValidator = dtoValidator;
        }

        public async Task<IEnumerable<GetPostDto>> GetAllPosts()
        {
            return (await _repository.GetAllAsync()).Select(x =>
            {
                var postDto = _mapper.Map<GetPostDto>(x);
                return postDto;
            }).ToList();
        }

        public async Task<IEnumerable<GetPostDto>> GetPosts(FilterSpecification<Post>? filterSpecification = null,
            PagingSpecification? pagingSpecification = null,
            SortSpecification<Post>? sortSpecification = null)
        {
            return (await _repository.GetAsync(filterSpecification, pagingSpecification, sortSpecification))
                .Select(x =>
                {
                    var postDto = _mapper.Map<GetPostDto>(x);
                    return postDto;
                });
        }

        public async Task<int> CountPostsWhere(FilterSpecification<Post>? filterSpecification = null)
        {
            return await _repository.CountWhereAsync(filterSpecification);
        }

        public async Task<IEnumerable<GetPostDto>> GetPostsFromUser(int id)
        {
            var posts = await _repository.GetPostsFromUser(id);
            return posts.Select(x =>
            {
                var postDto = _mapper.Map<GetPostDto>(x);
                return postDto;
            }).ToList();
        }

        public async Task<IEnumerable<GetPostDto>> GetPostsFromCategory(int id)
        {
            return (await _repository.GetPostsFromCategory(id)).Select(x =>
            {
                var postDto = _mapper.Map<GetPostDto>(x);
                return postDto;
            }).ToList();
        }

        public async Task<GetPostDto> GetPost(int id)
        {
            var post = await _repository.GetAsync(id);
            var postDto = _mapper.Map<GetPostDto>(post);
            return postDto;
        }

        private async Task<bool> PostAlreadyExistsWithSameProperties(UpdatePostDto post)
        {
            var postDb = await _repository.GetAsync(post.Id);
            return postDb.Name == post.Name &&
                   postDb.Author.Id == post.Author &&
                   postDb.Category.Id == post.Category &&
                   postDb.Content == post.Content &&
                   postDb.ThumbnailUrl == post.ThumbnailUrl;
        }

        public async Task CheckPostValidity(IPostDto post)
        {
            if (await _userRepository.GetAsync(post.Author) == null)
                throw new ResourceNotFoundException("Author doesn't exist.");
            if (await _categoryRepository.GetAsync(post.Category) == null)
                throw new ResourceNotFoundException("Category doesn't exist.");
        }

        public async Task CheckPostValidity(AddPostDto post)
        {
            await CheckPostValidity((IPostDto)post);
            if (await _repository.NameAlreadyExists(post.Name))
                throw new InvalidRequestException("Name already exists.");
        }

        public async Task CheckPostValidity(UpdatePostDto post)
        {
            await CheckPostValidity((IPostDto)post);
            if (await _repository.NameAlreadyExists(post.Name) &&
                (await _repository.GetAsync(post.Id)).Name != post.Name)
                throw new InvalidRequestException("Name already exists.");
        }

        public async Task<GetPostDto> AddPost(AddPostDto post)
        {
            await _dtoValidator.ValidateAndThrowAsync(post);
            await CheckPostValidity(post);
            var pocoPost = _mapper.Map<Post>(post);
            
            pocoPost.ThumbnailUrl = string.IsNullOrEmpty(pocoPost.ThumbnailUrl) ? null : pocoPost.ThumbnailUrl;

            var result = await _repository.AddAsync(pocoPost);
            _unitOfWork.Save();
            var getPost = _mapper.Map<GetPostDto>(result);
            return getPost;
        }

        public async Task UpdatePost(UpdatePostDto post)
        {
            await _dtoValidator.ValidateAndThrowAsync(post);
            if (await PostAlreadyExistsWithSameProperties(post))
                return;
            await CheckPostValidity(post);
            var postEntity = await _repository.GetAsync(post.Id);
            _mapper.Map(post, postEntity);
            _unitOfWork.Save();
        }

        public async Task DeletePost(int id)
        {
            await _repository.RemoveAsync(await _repository.GetAsync(id));
            _unitOfWork.Save();
        }
    }
}
