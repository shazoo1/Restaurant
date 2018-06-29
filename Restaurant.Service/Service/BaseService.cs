using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Service
{
    public class BaseService<T> : IBaseService<T> where T : IModel
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
