/// <summary>
/// 
/// </summary>
namespace PeopleDir.DataLayer.Context
{
    using PeopleDir.Models;
    using System.Data.Entity;
    /// <summary>
    /// The People Context class
    /// </summary>
    public class PeopleContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleContext"/> class.
        /// </summary>
        public PeopleContext() : base("connstring")
        {

        }

        /// <summary>
        /// Gets or sets the get people models.
        /// </summary>
        /// <value>
        /// The get people models.
        /// </value>
        public DbSet<PeopleModel> GetPeopleModels { get; set; }
    }
}
