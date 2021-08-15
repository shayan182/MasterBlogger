using System;
using _01_Framework.Infrastructure;

namespace MB.Infrastructure.EfCore
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;

        public UnitOfWorkEf(MasterBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.Database.CommitTransaction();
            _context.SaveChanges();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}