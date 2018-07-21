using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public static class Templates
    {
        public static string INSERT = @"INSERT INTO [{0}] ({1}) VALUES ({2});";
        public static string UPDATE = @"UPDATE [{0}] SET {1} WHERE {2};";
        public static string DELETE = @"DELETE FROM [{0}] WHERE {1};";
        public static string INSERT_BULK = @"INSERT INTO [{1}] SELECT {0} FROM [{2}] WHERE {3};";
        public static string UPDATE_BULK = @"UPDATE [{0}] SET {1} FROM ([{0}] A INNER JOIN [{2}] B ON A.[{3}] = B.[{3}]) WHERE {4};";
        public static string DELETE_BULK = @"DELETE FROM [{0}] WHERE {1} IN (SELECT {1} FROM [{2}] WHERE {3});";
        public static string UPDATE_CONDITIONAL = @"
		IF((SELECT SYS_STATUS FROM [{0}] WHERE {1}) = 2) -- IF REJECTED
		    {2} -- WITHOUT ACTION
		ELSE 
		    {3} -- WITH ACTION
        ";

    }
}
