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
    public class AddressesService : IAddressesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Address> Add(Address entity)
        {
            await _unitOfWork.AddressRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<Address> Delete(int id)
        {
            if (id > 0)
            {
                var family = await _unitOfWork.AddressRepository.GetFrist(x => x.Id == id);
                if (family == null) return null;
                await _unitOfWork.AddressRepository.Delete(family);
                await _unitOfWork.Commit();
            }
            return null;
        }

        public async Task<List<Address>> GetAll()
        {
            return await _unitOfWork.AddressRepository.GetAllList();
        }

        public async Task<Address> GetFrist(int id)
        {
            return await _unitOfWork.AddressRepository.GetFrist(x => x.Id == id);
        }

        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element =await _unitOfWork.AddressRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }

        public async Task<Address> Update(Address entity)
        {
            var upEntity = await _unitOfWork.AddressRepository.Update(entity);
            await _unitOfWork.Commit();
            return upEntity;
        }


    }
}
