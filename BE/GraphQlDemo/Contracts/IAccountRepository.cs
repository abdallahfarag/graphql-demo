using GraphQlDemo.Entities;

namespace GraphQlDemo.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);
    }
}
