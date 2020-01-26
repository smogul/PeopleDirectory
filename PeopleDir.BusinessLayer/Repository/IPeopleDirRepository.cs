/// <summary>
/// 
/// </summary>
namespace PeopleDir.BusinessLayer.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The IPeopleDirRepository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPeopleDirRepository<T> where T: class
    {
        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllPeople();

        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        T GetPersonById(Guid Id);

        /// <summary>
        /// Inserts the specified people.
        /// </summary>
        /// <param name="people">The people.</param>
        void Insert(T people);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        /// <summary>
        /// Updates the people.
        /// </summary>
        /// <param name="people">The people.</param>
        void UpdatePeople(T people);

        /// <summary>
        /// Deletes the person.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePerson(Guid id);
    }
}
