using Ex.DAL.DO.Interfaces;
using Ex.DAL.EF;
using Ex.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Ex.DAL.DO.Objetos;

namespace Ex.DAL
{
    public class Libros : ICRUD<data.Libros>
    {

        private Repository<data.Libros> repo;

        public Libros(NDbContext dbContext)
        {
            repo = new Repository<data.Libros>(dbContext);
        }
        public void Delete(data.Libros t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Libros> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Libros>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Libros GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Libros> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Libros t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Libros t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
