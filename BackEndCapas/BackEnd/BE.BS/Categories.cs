using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objetos;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class Categories : ICRUD<data.Categories>
    {
        private dal.Categories _dal;
        public Categories(NDbContext dbContext)
        {
            _dal = new dal.Categories(dbContext);
        }
        void ICRUD<data.Categories>.Delete(data.Categories t)
        {
            _dal.Delete(t);
        }

        IEnumerable<data.Categories> ICRUD<data.Categories>.GetAll()
        {
            return _dal.GetAll();
        }

        Task<IEnumerable<data.Categories>> ICRUD<data.Categories>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        data.Categories ICRUD<data.Categories>.GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        Task<data.Categories> ICRUD<data.Categories>.GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUD<data.Categories>.Insert(data.Categories t)
        {
            _dal.Insert(t);
        }

        void ICRUD<data.Categories>.Update(data.Categories t)
        {
            _dal.Update(t);
        }
    }
}
