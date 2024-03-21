using AutoMapper;
using Bravel.Web.Api.Model.Models;
using Bravel.Web.Api.Repository;
using Bravel.Web.Api.Service.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Service
{
    public class UserService : BaseService<User, UserDto>
    {
        private readonly IValidator<UserDto> _validator;
        private readonly IMapper _mapper;
        public UserService(IBaseRepository<User> _repository, IMapper mapper, IValidator<UserDto> validator) : base(_repository, mapper, validator)
        {
            //_validator = validator;
            //_mapper = mapper;
        }
        public new void Add(UserDto dto)
        {
            var result = _validator.Validate(dto);

            if (!result.IsValid)
            {
                throw new InvalidOperationException("");
            }

            if (_repository.GetAll().Where(x => x.Id == dto.Id).Any())
            {
                throw new InvalidOperationException("This entity already exists.");
            }
            var entity = _mapper.Map<User>(dto);
            _repository.Add(entity);
        }
        public new IEnumerable<UserDto> GetAll()
        {
            var entitydtos = _mapper.Map<IEnumerable<UserDto>>(_repository.GetAll());
            return entitydtos;
        }

        public new UserDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            var dto = _mapper.Map<UserDto>(entity);
            return dto;
        }

        public new bool Remove(int id)
        {
            if (_repository.GetAll().Where(x => x.Id == id).Any())
            {
                return _repository.Remove(id);
            }
            throw new InvalidOperationException("This entity doesn't exists.");
        }

        public new void Update(UserDto dto)
        {
            var result = _validator.Validate(dto);

            if (result.IsValid)
            {
                throw new InvalidOperationException("Entity validation has failed.");
            }

            var entity = _repository.GetById(dto.Id) ?? throw new InvalidOperationException("Entity is null.");
            _mapper.Map(dto, entity);
            _repository.Update(entity);
        }
    }
}
