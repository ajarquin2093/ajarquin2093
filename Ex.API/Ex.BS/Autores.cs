﻿using System;
using System.Collections.Generic;
using System.Text;
using data = Ex.DAL.DO.Objetos;
using dal = Ex.DAL;
using Ex.DAL.DO.Interfaces;
using System.Threading.Tasks;
using Ex.DAL.EF;

namespace Ex.BS
{
    public class Autores : ICRUD<data.Autores>
    {
        private dal.Autores _dal;

        public Autores(NDbContext dbContext)
        {
            _dal = new dal.Autores(dbContext);
        }

        public void Delete(data.Autores t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Autores> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Autores>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Autores GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Autores> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Autores t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Autores t)
        {
            _dal.Update(t);
        }
    }
}
