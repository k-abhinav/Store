using System.Data.Entity;

namespace Store.Infrastructure
{
    public class EntityContext : DbContext
    {
        public EntityContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
