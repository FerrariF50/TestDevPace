using CORE.Common.Intefaces;
using CORE.DAL.Models;
using CORE.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Common.Mappers
{
    public class CustomerRequestMapper : IModelMapper<Customer, CustomerRequestDto>
    {
        public CustomerRequestDto Map(Customer source)
        {
            if (source == null)
            {
                return null;
            }

            return new CustomerRequestDto
            {
                CustomerId = source.Customerid,
                CompanyName = source.Companyname,
                Name = source.Name,
                Email = source.Email,
                Phone = source.Phone
            };
        }

        public IEnumerable<CustomerRequestDto> Map(IEnumerable<Customer> source)
        {
            return source == null ? new List<CustomerRequestDto>() : source.Select(Map);
        }

        public Customer ReverseMap(CustomerRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Customer
            {
                Customerid = dto.CustomerId,
                Companyname = dto.CompanyName,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone
            };
        }

        public IEnumerable<Customer> ReverseMap(IEnumerable<CustomerRequestDto> dto)
        {
            return dto == null ? new List<Customer>() : dto.Select(ReverseMap);
        }
    }
}
