using AutoMapper;
using Ex.DAL.DO.Objetos;
using Ex.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = Ex.DAL.DO.Objetos;
using models = Ex.API.DataModels;

namespace Ex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public LibrosController(NDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Libros>>> GetLibros()
        {
          
            var res = new Ex.BS.Libros(_context).GetAll();
            List<models.Libros> mapaAux = _mapper.Map<IEnumerable<data.Libros>, IEnumerable<models.Libros>>(res).ToList();
            return mapaAux;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<models.Libros>> GetLibros(int id)
        {
            var categories = new Ex.BS.Libros(_context).GetOneById(id);

            if (categories == null)
            {
                return NotFound();
            }
            models.Libros mapaAux = _mapper.Map<data.Libros, models.Libros>(categories);

            return mapaAux;
        }


        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, models.Libros libros)
        {
            if (id != libros.id)
            {
                return BadRequest();
            }



            try
            {
                data.Libros mapaAux = _mapper.Map<models.Libros, data.Libros>(libros);
                new Ex.BS.Libros(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!LibrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Libros>> PostLibros(models.Libros libros)
        {
            try
            {
                data.Libros mapaAux = _mapper.Map<models.Libros, data.Libros>(libros);
                new Ex.BS.Libros(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }

            return CreatedAtAction("GetCategories", new { id = libros.id }, libros);
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Libros>> DeleteLibros(int id)
        {
            var libros = new Ex.BS.Libros(_context).GetOneById(id);
            if (libros == null)
            {
                return NotFound();
            }

            try
            {
                new Ex.BS.Libros(_context).Delete(libros);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.Libros mapaAux = _mapper.Map<data.Libros, models.Libros>(libros);

            return mapaAux;
        }

        private bool LibrosExists(int id)
        {
            return (new Ex.BS.Libros(_context).GetOneById(id) != null);
        }

    }
}
