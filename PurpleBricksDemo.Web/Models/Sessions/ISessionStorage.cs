using Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurpleBricksDemo.Web.Models.Sessions
{
    public interface ISessionStorage
    {
        User CurrentSystemUser { get; set; }
    }
}
