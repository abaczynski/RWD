using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Security
{
    public interface ISecurityService
    {
        HashObject Compute(string plainText);

        bool ValidateHash(string plainText, HashObject hashObject);
    }
}
