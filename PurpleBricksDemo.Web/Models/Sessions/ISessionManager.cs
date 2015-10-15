using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurpleBricksDemo.Web.Models.Sessions
{
    public interface ISessionManager
    {
        ISessionStorage CurrentSession { get; }
    }
}
