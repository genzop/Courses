using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.DataAccess.SQLite
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
