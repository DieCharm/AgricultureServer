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
    public class WaybillController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public WaybillController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PlannedWaybillDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<PlannedWaybill>, IEnumerable<PlannedWaybillDTO>>
                (await Context.PlannedWaybills.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<PlannedWaybillDTO>> PostAsync(PlannedWaybillDTO waybill)
        {
            if (waybill == null)
            {
                return BadRequest();
            }

            if (Context.PlannedWaybills.Any(
                    findWaybill =>
                        findWaybill.Id == waybill.Id))
            {
                try
                {
                    Context.PlannedWaybills.Update
                        (Mapper.Map<PlannedWaybillDTO, PlannedWaybill>(waybill));
                    await Context.SaveChangesAsync();
                    return Ok(waybill);
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
                    Context.PlannedWaybills.Add
                        (Mapper.Map<PlannedWaybillDTO, PlannedWaybill>(waybill));
                    await Context.SaveChangesAsync();
                    return Ok(waybill);
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
                Context.PlannedWaybills.Remove(Context.PlannedWaybills.Find(id));
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