using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Budget.Models;
using Budget.Objects;
using System.Diagnostics;


namespace Budget.Controllers
{
    public class BudgetDaysController : ApiController
    {
        private BudgetContext db = new BudgetContext();

        // GET: api/BudgetDays
        //public IQueryable<BudgetDay> GetBudgetDays()
        public BudgetDaysList GetBudgetDays()
        {
            var budgetDaysList = new BudgetDaysList();
            budgetDaysList.BudgetDays = db.BudgetDays.ToList();
            /*
            if (budgetDaysList.BudgetDays.Count > 0)
            {
                Debug.WriteLine(budgetDaysList.BudgetDays.FirstOrDefault().Earned);
                Debug.WriteLine(budgetDaysList.AverageDailySpending);
                Debug.WriteLine(budgetDaysList.TotalSaved);
            }
            */
            //return db.BudgetDays.OrderBy(b => b.Date);
            return budgetDaysList;
        }

        // GET: api/BudgetDays/5
        [ResponseType(typeof(BudgetDay))]
        public IHttpActionResult GetBudgetDay(int id)
        {
            BudgetDay budgetDay = db.BudgetDays.Find(id);
            if (budgetDay == null)
            {
                return NotFound();
            }

            return Ok(budgetDay);
        }

        // PUT: api/BudgetDays/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBudgetDay(BudgetDay budgetDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
            if (id != budgetDay.Id)
            {
                return BadRequest();
            }
            */

            db.Entry(budgetDay).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetDayExists(budgetDay.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BudgetDays
        [ResponseType(typeof(BudgetDay))]
        public IHttpActionResult PostBudgetDay(BudgetDay budgetDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BudgetDays.Add(budgetDay);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = budgetDay.Id }, budgetDay);
        }

        // DELETE: api/BudgetDays/5
        [ResponseType(typeof(BudgetDay))]
        public IHttpActionResult DeleteBudgetDay(int id)
        {
            BudgetDay budgetDay = db.BudgetDays.Find(id);
            if (budgetDay == null)
            {
                return NotFound();
            }

            db.BudgetDays.Remove(budgetDay);
            db.SaveChanges();

            return Ok(budgetDay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BudgetDayExists(int id)
        {
            return db.BudgetDays.Count(e => e.Id == id) > 0;
        }
    }
}