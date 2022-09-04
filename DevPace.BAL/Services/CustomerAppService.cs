using CORE.Common.Intefaces;
using CORE.DAL.Interfaces;
using CORE.Dto.Dto;
using CORE.Dto.Requests;
using Customer.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using customer = CORE.DAL.Models.Customer;

namespace Customer.BAL.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IModelMapper<customer, CustomerRequestDto> _customerReqMapper;
        private readonly IModelMapper<customer, CustomerDto> _customerDtoResMapper;
        private readonly ICustomersRepository _customerRepository;
        private readonly IVerifyEmailAppService _verifyAppSrv;

        public CustomerAppService(
            ICustomersRepository customerRepository,
            IModelMapper<customer, CustomerRequestDto> customerReqModelMapper,
            IModelMapper<customer, CustomerDto> customerDtoResMapper, 
            IVerifyEmailAppService verifyAppSrv)
        {
            this._customerRepository = customerRepository;
            this._customerReqMapper = customerReqModelMapper;
            this._customerDtoResMapper = customerDtoResMapper;
            this._verifyAppSrv = verifyAppSrv;
        }

        public async Task<int> AddAsync(CustomerRequestDto dto)
        {
            var obj = _customerReqMapper.ReverseMap(dto);
            obj.Customerid = 0;

            if (_verifyAppSrv.IsValidEmail(obj.Email))
            {
                var id = await _customerRepository.AddAsync(obj);
                return id;
            }

            throw new Exception("Email is not valid");
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var obj = await _customerRepository.GetAllAsync();
            var dto =_customerDtoResMapper.Map(obj);

            return dto;
        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var obj = await _customerRepository.GetAsync(id);
            var dto  =_customerDtoResMapper.Map(obj);

            return dto;
        }

        public async Task<int> UpdateAsync(CustomerRequestDto dto)
        {
            var obj = _customerReqMapper.ReverseMap(dto);
            if (_verifyAppSrv.IsValidEmail(obj.Email))
            {
                var id = await _customerRepository.UpdateAsync(obj);
                return id;
            }
            throw new Exception("Email is not valid");
        }
    }
}
