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
    public class FieldController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public FieldController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<FieldDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Field>, IEnumerable<FieldDTO>>
                (await Context.Fields.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<FieldDTO>> PostAsync(FieldDTO field)
        {
            if (field == null)
            {
                return BadRequest();
            }

            if (Context.Fields.Any(
                    findField =>
                        findField.Id == field.Id))
            {
                try
                {
                    Context.Fields.Update
                        (Mapper.Map<FieldDTO, Field>(field));
                    await Context.SaveChangesAsync();
                    return Ok(field);
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
                    Context.Fields.Add
                        (Mapper.Map<FieldDTO, Field>(field));
                    await Context.SaveChangesAsync();
                    return Ok(field);
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
                Context.Fields.Remove(Context.Fields.Find(id));
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