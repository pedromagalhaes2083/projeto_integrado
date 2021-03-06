using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TST
{
    public class TST_DataGrid
    {
        public static bool Validar_DataGrid_Columns(DataGridView dgv_dataGrid) => dgv_dataGrid.Columns.Count > 0 ? true : false;
        public static bool Validar_DataGrid_Rows(DataGridView dgv_dataGrid) => dgv_dataGrid.Rows.Count > 0 ? true : false;
    }
}
