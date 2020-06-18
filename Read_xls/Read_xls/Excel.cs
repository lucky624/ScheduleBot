using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Read_xls
{
    class Excel
    {
        
        static _Excel.Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public int count = 0;
        public string name = "";
        public Excel(string path, int Sheet)
        {
            wb = excel.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            ws = wb.Worksheets[Sheet];
            count = wb.Worksheets.Count;
            name = ws.Name;
        }

        public string ReadCell(int y, int x)
        {
            //y++;
            try
            {
                if (ws.Cells[y, x].Value2 != null)
                {
                    try
                    {
                        return ws.Cells[y, x].Value2.ToString();
                    }
                    catch (Exception ex) { return ex.Message; }
                }
                else return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public void Quit()
        {
            excel.Quit();
        }


    }
}
