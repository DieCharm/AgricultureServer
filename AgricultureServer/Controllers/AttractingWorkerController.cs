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
    public class AttractingWorkerController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public AttractingWorkerController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<AttractingWorkerDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<AttractingWorker>, IEnumerable<AttractingWorkerDTO>>
                (await Context.AttractingWorkers.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<AttractingWorkerDTO>> PostAsync(AttractingWorkerDTO attractingWorker)
        {
            if (attractingWorker == null)
            {
                return BadRequest();
            }

            if (Context.AttractingWorkers.Any
                (attractingWorkers =>
                    attractingWorkers.Id == attractingWorker.Id))
            {
                try
                {
                    Context.AttractingWorkers.Update
                        (Mapper.Map<AttractingWorkerDTO, AttractingWorker>(attractingWorker));
                    await Context.SaveChangesAsync();
                    return Ok(attractingWorker);
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
                    Context.AttractingWorkers.Add
                        (Mapper.Map<AttractingWorkerDTO, AttractingWorker>(attractingWorker));
                    await Context.SaveChangesAsync();
                    return Ok(attractingWorker);
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
                Context.AttractingWorkers.Remove(Context.AttractingWorkers.Find(id));
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