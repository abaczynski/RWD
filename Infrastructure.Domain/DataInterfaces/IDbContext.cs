﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Domain.DataInterfaces
{
    public interface IDbContext
    {
        IDisposable BeginTransaction();
        void CommitChanges();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
