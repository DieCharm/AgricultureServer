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
    public class OrderController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public OrderController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<WorkOrderDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<WorkOrder>, IEnumerable<WorkOrderDTO>>
                (await Context.WorkOrders.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<WorkOrderDTO>> PostAsync(WorkOrderDTO order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (Context.WorkOrders.Any(
                    findOrder =>
                        findOrder.Id == order.Id))
            {
                try
                {
                    Context.WorkOrders.Update
                        (Mapper.Map<WorkOrderDTO, WorkOrder>(order));
                    await Context.SaveChangesAsync();
                    return Ok(order);
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
                    Context.WorkOrders.Add
                        (Mapper.Map<WorkOrderDTO, WorkOrder>(order));
                    await Context.SaveChangesAsync();
                    return Ok(order);
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
                Context.WorkOrders.Remove(Context.WorkOrders.Find(id));
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