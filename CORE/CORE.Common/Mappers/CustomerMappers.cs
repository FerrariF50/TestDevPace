using CORE.Common.Intefaces;
using CORE.Dto.Dto;
using DevPace.CORE.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CORE.Common.Mappers
{
    public class CustomerMappers : IModelMapper<Customer, CustomerDto>
    {
        public CustomerDto Map(Customer source)
        {
            if(source == null)
            {
                return null;
            }

            return new CustomerDto
            {
                CustomerId = source.CustomersId,
                CompanyName = source.CompanyName,
                Name = source.Name,
                Email = source.Email,
                Phone = source.Phone
            };
        }

        public IEnumerable<CustomerDto> Map(IEnumerable<Customer> source)
        {
            return source == null ? new List<CustomerDto>() : source.Select(Map);
        }

        public Customer ReverseMap(CustomerDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            return new Customer
            {
                CustomersId = dto.CustomerId,
                Name = dto.Name,
                CompanyName = dto.CompanyName,
                Email = dto.Email,
                Phone = dto.Phone
            };
        }

        public IEnumerable<Customer> ReverseMap(IEnumerable<CustomerDto> dto)
        {
            return dto == null ? new List<Customer>() : dto.Select(ReverseMap);
        }
    }
}
