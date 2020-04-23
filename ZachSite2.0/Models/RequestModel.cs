using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZachSite2._0.Models
{
    public class RequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ConfirmEmail { get; set; }
        public string ProposalMessage { get; set; }
    }
}