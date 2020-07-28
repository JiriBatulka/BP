using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IDriverRepository
    {
        public Task AddDriverAsync(Driver driver);
    }
}
