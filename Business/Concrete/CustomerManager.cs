using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length<2)
            {
                return new ErrorResult(Messages.CompanyNameInvalid);
            }
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
