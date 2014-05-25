using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Security;


namespace VSJamSession.VSThrowawayPackage
{
    [ServiceContract]
    interface IConnectionStringService
    {
        private Dictionary<String, SqlConnectionStringBuilder> ConnectionStrings;
        
        [OperationContract]
        SqlConnectionStringBuilder GetConnectionString(string username, string password, string name);
    }
}
