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
    public class IncomeAndExpensesController : ControllerBase
    {
        private AgricultureContext Context;
        private IMapper Mapper;

        public IncomeAndExpensesController(AgricultureContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CropIncomeAndExpensesDTO>> GetAsync()
        {
            return Mapper.Map<IEnumerable<CropIncomeAndExpense>, IEnumerable<CropIncomeAndExpensesDTO>>
                (await Context.CropIncomeAndExpenses.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<CropIncomeAndExpensesDTO>> PostAsync(CropIncomeAndExpensesDTO incomeAndExpenses)
        {
            if (incomeAndExpenses == null)
            {
                return BadRequest();
            }

            if (Context.CropIncomeAndExpenses.Any(
                    findIncomeAndExpenses =>
                        findIncomeAndExpenses.Id == incomeAndExpenses.Id))
            {
                try
                {
                    Context.CropIncomeAndExpenses.Update
                        (Mapper.Map<CropIncomeAndExpensesDTO, CropIncomeAndExpense>(incomeAndExpenses));
                    await Context.SaveChangesAsync();
                    return Ok(incomeAndExpenses);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            else
            {
                try
                {
                    Context.CropIncomeAndExpenses.Add
                        (Mapper.Map<CropIncomeAndExpensesDTO, CropIncomeAndExpense>(incomeAndExpenses));
                    await Context.SaveChangesAsync();
                    return Ok(incomeAndExpenses);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                Context.CropIncomeAndExpenses.Remove(Context.CropIncomeAndExpenses.Find(id));
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}