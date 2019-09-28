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
using Personal.Models;

namespace Personal.Controllers
{
    public class PersonalDatasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PersonalDatas
        public IQueryable<PersonalData> GetPersonalDatas()
        {
            return db.PersonalDatas;
        }

        // GET: api/PersonalDatas/5
        [ResponseType(typeof(PersonalData))]
        public IHttpActionResult GetPersonalData(int id)
        {
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return NotFound(); 
            }

            return Ok(personalData);
        }

        // PUT: api/PersonalDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonalData(int id, PersonalData personalData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalData.FriendId)
            {
                return BadRequest();
            }

            db.Entry(personalData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDataExists(id))
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

        // POST: api/PersonalDatas
        [ResponseType(typeof(PersonalData))]
        public IHttpActionResult PostPersonalData(PersonalData personalData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalDatas.Add(personalData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personalData.FriendId }, personalData);
        }

        // DELETE: api/PersonalDatas/5
        [ResponseType(typeof(PersonalData))]
        public IHttpActionResult DeletePersonalData(int id)
        {
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return NotFound();
            }

            db.PersonalDatas.Remove(personalData);
            db.SaveChanges();

            return Ok(personalData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalDataExists(int id)
        {
            return db.PersonalDatas.Count(e => e.FriendId == id) > 0;
        }
    }
}