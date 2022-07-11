using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgricultureServer.Database;
using AgricultureServer.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgricultureServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesInvoiceController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public SalesInvoiceController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<SalesInvoiceDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<SalesInvoice>, IEnumerable<SalesInvoiceDTO>>
                (await Context.SalesInvoices.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<SalesInvoiceDTO>> PostAsync(SalesInvoiceDTO salesInvoice)
        {
            if (salesInvoice == null)
            {
                return BadRequest();
            }

            if (Context.SalesInvoices.Any(
                    findSalesInvoice =>
                        findSalesInvoice.Id == salesInvoice.Id))
            {
                try
                {
                    Context.SalesInvoices.Update
                        (Mapper.Map<SalesInvoiceDTO, SalesInvoice>(salesInvoice));
                    await Context.SaveChangesAsync();
                    return Ok(salesInvoice);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }

            else
            {
                try
                {
                    Context.SalesInvoices.Add
                        (Mapper.Map<SalesInvoiceDTO, SalesInvoice>(salesInvoice));
                    await Context.SaveChangesAsync();
                    return Ok(salesInvoice);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                Context.SalesInvoices.Remove(Context.SalesInvoices.Find(id));
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}