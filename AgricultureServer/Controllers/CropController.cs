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
    public class CropController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public CropController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CropDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Crop>, IEnumerable<CropDTO>>
                (await Context.Crops.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<CropDTO>> PostAsync(CropDTO crop)
        {
            if (crop == null)
            {
                return BadRequest();
            }

            if (Context.Crops.Any(
                    findCrop =>
                        findCrop.Id == crop.Id))
            {
                try
                {
                    Context.Crops.Update
                        (Mapper.Map<CropDTO, Crop>(crop));
                    await Context.SaveChangesAsync();
                    return Ok(crop);
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
                    Context.Crops.Add
                        (Mapper.Map<CropDTO, Crop>(crop));
                    await Context.SaveChangesAsync();
                    return Ok(crop);
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
                Context.Crops.Remove(Context.Crops.Find(id));
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