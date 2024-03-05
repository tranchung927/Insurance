using System;
using AutoMapper;
using InsuranceCore.Repositories.Product;
using InsuranceCore.Repositories.User;

namespace InsuranceCore.Models.DTOs.Ticket.Converters
{
	public class UpdateTicketConverter : ITypeConverter<UpdateTicketDto, Data.Ticket>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTicketConverter"/> class.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="productRepository"></param>
       
        public UpdateTicketConverter(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        
        }

        /// <inheritdoc />
        public Data.Ticket Convert(UpdateTicketDto source, Data.Ticket destination,
            ResolutionContext context)
        {
            
            destination.Name = source.Name;
            destination.Phone = source.Phone;
            destination.Email = source.Email;
            destination.Comment = source.Comment;
            destination.Status = source.Status;
            if (source.Assign != null)
            {
                destination.User = _userRepository.Get((int)source.Assign);
            }
            destination.Product = _productRepository.Get(source.Product);
            return destination;
        }
    }
}

