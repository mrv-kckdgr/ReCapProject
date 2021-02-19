using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _cutomerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _cutomerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            //ValidationTool.Validate(new CustomerValidator(), customer);
            _cutomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cutomerDal.GetAll(), Messages.CustomerListed);
        }
        
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_cutomerDal.Get(c => c.Id == customerId));
        }
    }
}
