using Student.Business.Abstract;
using Student.DataAccess.Abstract;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
           
        }

        public async Task<Address> Create(Address entity)
        {

            try
            {
                await _addressRepository.Create(entity);
                await _addressRepository.Commit();
            }
            catch 
            {
                entity = null;
            }

            return entity;
        }

        public async Task<Address> Delete(Address entity)
        {
            try
            {
                await _addressRepository.Delete(entity);
                await _addressRepository.Commit();
            }
            catch
            {
                entity = null;
            }

            return entity;
        }

        public async Task<Address> Get(int id)
        {
            Address address = null;
            try
            {
                address = await _addressRepository.Get(id);
            }
            catch 
            {
                address=null;
            }
            return address;
        }

        public async Task<List<Address>> GetAll()
        {
            var adresses = await _addressRepository.GetAll();
            return adresses;
        }

        public async Task<Address> Update(Address entity)
        {
            try
            {
                await _addressRepository.Update(entity);
                await _addressRepository.Commit();
            }
            catch
            {
                entity =null;
            }
            return entity;
        }
    }
}
