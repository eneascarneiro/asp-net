﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crm_nvc.Data;
using crm_nvc.Models;

namespace crm_nvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosApiController : ControllerBase
    {
        private readonly crm_nvc_Context _context;

        public ProductosApiController(crm_nvc_Context context)
        {
            _context = context;
        }

        // GET: api/ProductosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/ProductosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/ProductosApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.ID)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/ProductosApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductos", new { id = productos.ID }, productos);
        }

        // DELETE: api/ProductosApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.ID == id);
        }
    }
}
