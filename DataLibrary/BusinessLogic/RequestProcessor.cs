using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class RequestProcessor
    {
        public static int CreateRequest(string firstName, string lastName, 
            string emailAddress, string requestMessage)
        {
            RequestModel data = new RequestModel
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                RequestMessage = requestMessage
            };

            string sql = @"insert into dbo.RequestTable (FirstName, LastName, EmailAddress, ProposalMessage)
                           values (@FirstName, @LastName, @EmailAddress, @RequestMessage);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<RequestModel> LoadRequests()
        {
            string sql = @"select Id, FirstName, LastName, EmailAddress, ProposalMessage
                            from dbo.Requests;";

            return SqlDataAccess.LoadData<RequestModel>(sql);
        }
    }
}
