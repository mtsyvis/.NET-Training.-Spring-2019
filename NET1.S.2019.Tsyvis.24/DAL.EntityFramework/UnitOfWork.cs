using System.Data.Entity;
using DAL.Interface.Interfaces;

namespace DAL.EntityFramework
{
    /// <summary>
    /// Realize saving data.
    /// </summary>
    /// <seealso cref="DAL.Interface.Interfaces.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            this.context?.SaveChanges();
        }

        public void Dispose()
        {
            this.context?.Dispose();
        }
    }
}
