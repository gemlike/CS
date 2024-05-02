using System;
using System.Data.Common;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NgocThe

{
    
    public class Test
    {

        static void Main()
        {
            string sqlConnection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=The1;Integrated Security=True";
            DbConnection dbConnection = new SqlConnection(sqlConnection);
            dbConnection.Open();

            dbConnection.Close();

            Console.ReadKey();

        }
    }

}