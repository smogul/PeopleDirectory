/// <summary>
/// The PeopleDirRepository class.
/// </summary>
namespace PeopleDir.BusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using PeopleDir.DataLayer.Context;
    using PeopleDir.Models;
    public class PeopleDirRepository : IPeopleDirRepository<PeopleModel> 
    {
        /// <summary>
        /// The database people context
        /// </summary>
        private PeopleContext dbPeopleContext;

        /// <summary>
        /// The database set
        /// </summary>
        private DbSet<PeopleModel> dbSet;

        public PeopleDirRepository()
        {
            dbPeopleContext = new PeopleContext();
            dbSet = dbPeopleContext.Set<PeopleModel>();
        }
      
        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PeopleModel> GetAllPeople()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public PeopleModel GetPersonById(Guid Id)
        {
            return dbSet.Find(Id);
        }

        /// <summary>
        /// Inserts the specified people.
        /// </summary>
        /// <param name="people">The people.</param>
        public void Insert(PeopleModel people)
        {
            dbSet.Add(people);
        }

        /// <summary>
        /// Saves the specified people.
        /// </summary>
        /// <param name="people">The people.</param>
        public void Save()
        {
            dbPeopleContext.SaveChanges(); 
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdatePeople(PeopleModel people)
        {
            dbPeopleContext.Entry(people).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void DeletePerson(Guid Id)
        {
            try
            {
                var getPersonById = dbSet.Find(Id);
                if (getPersonById != null)
                {
                    dbSet.Remove(getPersonById);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new KeyNotFoundException();

            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ( this.dbPeopleContext != null)
                {
                    this.dbPeopleContext.Dispose();
                    this.dbPeopleContext = null;
                                       
                }
            }
        }

    }
}
