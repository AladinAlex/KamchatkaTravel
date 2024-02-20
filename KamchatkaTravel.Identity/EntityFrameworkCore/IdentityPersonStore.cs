using KamchatkaTravel.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.EntityFrameworkCore
{
    public class IdentityPersonStore : UserManager<IdentityPerson>
    {
        readonly KamchatkaTravelIdentityDbContext _context;

        public IdentityPersonStore(IUserStore<IdentityPerson> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<IdentityPerson> passwordHasher, IEnumerable<IUserValidator<IdentityPerson>> userValidators,
        IEnumerable<IPasswordValidator<IdentityPerson>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider serviceProvider, ILogger<UserManager<IdentityPerson>> logger,
        KamchatkaTravelIdentityDbContext context)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, serviceProvider, logger)
        {
            _context = context;
        }

        public override async Task<IdentityPerson?> FindByNameAsync(string userName)
        {
            var result = await _context.Users.Include(x => x.PersonTelegram).FirstOrDefaultAsync(x => x.NormalizedUserName == userName.ToUpper());
            return result;
        }
    }
}