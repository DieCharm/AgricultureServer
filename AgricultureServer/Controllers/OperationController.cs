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
    public class OperationController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public OperationController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TechnologicalOperationDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<TechnologicalOperation>, IEnumerable<TechnologicalOperationDTO>>
                (await Context.TechnologicalOperations.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<TechnologicalOperationDTO>> PostAsync(TechnologicalOperationDTO operation)
        {
            if (operation == null)
            {
                return BadRequest();
            }

            if (Context.TechnologicalOperations.Any(
                    findOperation =>
                        findOperation.Id == operation.Id))
            {
                try
                {
                    Context.TechnologicalOperations.Update
                        (Mapper.Map<TechnologicalOperationDTO, TechnologicalOperation>(operation));
                    await Context.SaveChangesAsync();
                    return Ok(operation);
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
                    Context.TechnologicalOperations.Add
                        (Mapper.Map<TechnologicalOperationDTO, TechnologicalOperation>(operation));
                    await Context.SaveChangesAsync();
                    return Ok(operation);
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
                Context.TechnologicalOperations.Remove(Context.TechnologicalOperations.Find(id));
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