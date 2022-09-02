﻿using CORE.Common.Intefaces;
using CORE.DAL.Models;
using CORE.Dto.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CORE.Common.Mappers
{
    public class CustomerMappers : IModelMapper<Customer, CustomerDto>
    {
        public CustomerDto Map(Customer source)
        {
            if (source == null)
            {
                return null;
            }

            return new CustomerDto
            {
                CustomerId = source.Customerid,
                CompanyName = source.Companyname,
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
            if (dto == null)
            {
                return null;
            }

            return new Customer
            {
                Customerid = dto.CustomerId,
                Name = dto.Name,
                Companyname = dto.CompanyName,
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
