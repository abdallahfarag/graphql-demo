﻿using GraphQlDemo.Contracts;
using GraphQlDemo.DBContext;
using GraphQlDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlDemo.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts
        .Where(a => a.OwnerId.Equals(ownerId))
        .ToList();

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }
    }
}
