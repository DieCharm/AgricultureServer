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
    public class RequirementController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public RequirementController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PlannedRequirementDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<PlannedRequirement>, IEnumerable<PlannedRequirementDTO>>
                (await Context.PlannedRequirements.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<PlannedRequirementDTO>> PostAsync(PlannedRequirementDTO requirement)
        {
            if (requirement == null)
            {
                return BadRequest();
            }

            if (Context.PlannedRequirements.Any(
                    findRequirement =>
                        findRequirement.Id == requirement.Id))
            {
                try
                {
                    Context.PlannedRequirements.Update
                        (Mapper.Map<PlannedRequirementDTO, PlannedRequirement>(requirement));
                    await Context.SaveChangesAsync();
                    return Ok(requirement);
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
                    Context.PlannedRequirements.Add
                        (Mapper.Map<PlannedRequirementDTO, PlannedRequirement>(requirement));
                    await Context.SaveChangesAsync();
                    return Ok(requirement);
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
                Context.PlannedRequirements.Remove(Context.PlannedRequirements.Find(id));
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