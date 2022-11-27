using ChurchPresenter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchPresenter.Infrastructure.DAL
{
    internal static class SqlQueries
    {




        internal static List<HymnLyric> QueryHymns() 
        {
            return new List<HymnLyric>(); 
        }

            

        //internal static void GetCustomer(long id)
        //{
        //    if (!File.Exists(DbFile)) return null;

        //    using (var cnn = SimpleDbConnection())
        //    {
        //        cnn.Open();
        //        Customer result = cnn.Query<Customer>(
        //            @"SELECT Id, FirstName, LastName, DateOfBirth
        //    FROM Customer
        //    WHERE Id = @id", new { id }).FirstOrDefault();
        //        return result;
        //    }
        //}


    }
}
