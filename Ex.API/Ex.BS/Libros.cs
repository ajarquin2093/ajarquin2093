using System;
using System.Collections.Generic;
using System.Text;
using data = Ex.DAL.DO.Objetos;
using dal = Ex.DAL;
using Ex.DAL.DO.Interfaces;
using System.Threading.Tasks;
using Ex.DAL.EF;

namespace Ex.BS
{
    public class Libros : ICRUD<data.Libros>
    {
        private dal.Libros _dal;

        public Libros(NDbContext dbContext)
        {
            _dal = new dal.Libros(dbContext);
        }
        public void Delete(data.Libros t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Libros> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Libros>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Libros GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Libros> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Libros t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Libros t)
        {
            _dal.Update(t);
        }
    }
}
