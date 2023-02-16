using Microsoft.EntityFrameworkCore;
using WebApiSqlAzure.Model;

namespace WebApiSqlAzure.Data
{
    public class WebApiBlobAzureContext : DbContext
    {
        public WebApiBlobAzureContext(DbContextOptions<WebApiBlobAzureContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
