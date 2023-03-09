using GraphQlDemo.Contracts;
using GraphQlDemo.DBContext;
using GraphQlDemo.Entities;

namespace GraphQlDemo.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDBContext _context;
        public OwnerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll() 
            => _context.Owners.ToList();

        public Owner GetById(Guid id) 
            => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }
        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            _context.SaveChanges();
            return dbOwner;
        }
        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }
    }
}
