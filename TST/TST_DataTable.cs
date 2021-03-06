using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TST
{
    public class TST_DataTable
    {
        public static bool Validar_DataTable(DataTable dt_table)
        {
            if (!(dt_table is null))
                return dt_table.Rows.Count > 0 ? true : false;
            else
                return false;
        }
    }
}
