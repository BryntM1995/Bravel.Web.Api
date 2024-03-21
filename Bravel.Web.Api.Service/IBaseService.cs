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
    public interface IBaseService<Entity>
    {
        void Add(Entity entity);
        void Update(Entity entity);
        bool Remove(int key);
        Entity GetById(int key);
        IEnumerable<Entity> GetAll();
    }
    public class BaseService<Entity, EntityDto> : IBaseService<EntityDto> where EntityDto : class, IBaseDto
        where Entity : class, IBaseEntity
    {
        private readonly IValidator<EntityDto> _validator;
        private readonly IMapper _mapper;
        protected readonly IBaseRepository<Entity> _repository;
        public BaseService(
            IBaseRepository<Entity> repository,
            IMapper mapper,
            IValidator<EntityDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public void Add(EntityDto dto)
        {
            var result = _validator.Validate(dto);


            if (_repository.GetAll().Where(x => x.Id == dto.Id).Any())
            {
                throw new InvalidOperationException("This entity already exists.");
            }
            var entity = _mapper.Map<Entity>(dto);
            _repository.Add(entity);
        }

        public IEnumerable<EntityDto> GetAll()
        {
            var entitydtos = _mapper.Map<IEnumerable<EntityDto>>(_repository.GetAll());
            return entitydtos;
        }

        public EntityDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            var dto = _mapper.Map<EntityDto>(entity);
            return dto;
        }

        public bool Remove(int key)
        {
            if (_repository.GetAll().Where(x => x.Id == key).Any())
            {
                return _repository.Remove(key);
            }
            throw new InvalidOperationException("This entity doesn't exists.");
        }

        public void Update(EntityDto dto)
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
