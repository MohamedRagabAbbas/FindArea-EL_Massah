using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace App21
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
