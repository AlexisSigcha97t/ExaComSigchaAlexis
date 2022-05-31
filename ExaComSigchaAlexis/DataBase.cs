using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExaComSigchaAlexis
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
