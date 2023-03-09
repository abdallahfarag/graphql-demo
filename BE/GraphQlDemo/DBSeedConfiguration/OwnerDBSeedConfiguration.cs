using GraphQlDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQlDemo.DBSeedConfiguration
{
    public class OwnerDBSeedConfiguration : IEntityTypeConfiguration<Owner>
    {
        private Guid[] _ids;

        public OwnerDBSeedConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
             .HasData(
               new Owner
               {
                   Id = _ids[0],
                   Name = "John Doe",
                   Address = "John Doe's address"
               },
               new Owner
               {
                   Id = _ids[1],
                   Name = "Jane Doe",
                   Address = "Jane Doe's address"
               }
           );
        }
    }
}
