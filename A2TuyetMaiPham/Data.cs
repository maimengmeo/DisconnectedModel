﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace A2TuyetMaiPham
{
    public class Data
    {
        private static string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                         Initial Catalog=WorldDB;
                                         Integrated Security=True";
        public static string ConnectionString { get => connStr; }

    }

    
}
