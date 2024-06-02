using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Abstract
{
    public interface ApplicationDbHelper
    {
        DbSet<User> User { get; }
        public int SaveChangesAsync();
    }
}
