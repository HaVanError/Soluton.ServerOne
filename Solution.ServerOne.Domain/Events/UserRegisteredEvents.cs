using Solution.ServerOne.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Domain.Events
{
    public class UserRegisteredEvents
    {
        User User { get; }
        public UserRegisteredEvents(User user) {

            User = user;
        }
    }
}
