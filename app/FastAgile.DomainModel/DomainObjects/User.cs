using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastAgile.DomainModel.DomainObjects
{
    public class User
    {
        private string _userName;
        private string _userSecondName;
        private string _userEmail;
        private List<UserRoles> _userRoleses;
    }

    public enum UserRoles
    {
        TeamLead,
        TeamMember,
        DomainExpert,
        ProductOwner,
        Stakeholder
    }
}
