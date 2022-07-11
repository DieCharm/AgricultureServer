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
    public class QualificationController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public QualificationController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<WorkerQualificationDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<WorkerQualification>, IEnumerable<WorkerQualificationDTO>>
                (await Context.WorkerQualifications.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<WorkerQualificationDTO>> PostAsync(WorkerQualificationDTO qualification)
        {
            if (qualification == null)
            {
                return BadRequest();
            }

            if (Context.WorkerQualifications.Any(
                    findQualification =>
                        findQualification.Id == qualification.Id))
            {
                try
                {
                    Context.WorkerQualifications.Update
                        (Mapper.Map<WorkerQualificationDTO, WorkerQualification>(qualification));
                    await Context.SaveChangesAsync();
                    return Ok(qualification);
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
                    Context.WorkerQualifications.Add
                        (Mapper.Map<WorkerQualificationDTO, WorkerQualification>(qualification));
                    await Context.SaveChangesAsync();
                    return Ok(qualification);
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
                Context.WorkerQualifications.Remove(Context.WorkerQualifications.Find(id));
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