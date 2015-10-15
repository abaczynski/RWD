using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Domain.DataInterfaces
{
    public interface IDbContextProvider
    {
        IDbContext CurrentContext { get; }
    }
}
