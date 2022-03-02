using BE.DAL.DO.Interfaces;
using BE.DAL.EF;
using BE.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL
{
    public class Categories : ICRUD<data.Categories>
    {
        private Repository<data.Categories> repo;
        public Categories(NDbContext dbContext)
        {
            repo = new Repository<data.Categories>(dbContext);
        }
        void ICRUD<data.Categories>.Delete(data.Categories t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        IEnumerable<data.Categories> ICRUD<data.Categories>.GetAll()
        {
            return repo.GetAll();
        }

        Task<IEnumerable<data.Categories>> ICRUD<data.Categories>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        data.Categories ICRUD<data.Categories>.GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        Task<data.Categories> ICRUD<data.Categories>.GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUD<data.Categories>.Insert(data.Categories t)
        {
            repo.Insert(t);
        }

        void ICRUD<data.Categories>.Update(data.Categories t)
        {
            repo.Update(t);
        }
    }
}
