using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Linq;
using DXAppWPF.Interfaces;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Xpf.Grid;

namespace DXAppWPF.Data
{
    public class FileConvert : IConvert
    {
        // Путь к файлу по умолчанию
        public static string Path { get; set; } = 
            Directory.GetCurrentDirectory() + @"\" + "file";

        public string CheckRow(object sender)
        {
            GridControl gridControl = sender as GridControl;

            gridControl.BeginSelection();
            string text = "";
            foreach (int rowHandle in gridControl.GetSelectedRowHandles())
            {
                int row = gridControl.GetRowHandleByVisibleIndex(rowHandle);
                var cellValue = gridControl.GetRow(rowHandle);
                text += cellValue.ToString() + " \n";
            }
            gridControl.EndSelection();
            return text;
        }

        public void SaveFile(string text, string type)
        {
            if (type == "csv")
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook workbook = xlApp.Workbooks.Add();
                Excel.Worksheet oSheet = workbook.ActiveSheet;
              
                string[] cell = text.Split(new char[] {',', ':', '\n' });
                char[] letters = Enumerable.Range('A', 'F' - 'A' + 1).Select(c => (char)c).ToArray();
            
                // Заполнение таблицы 
                int s = 1;
                for (int i = 1; i < cell.Length; i++)
                {
                    for(int j = 1; j < letters.Length + 1; j++)
                    {
                        if (s < cell.Length)
                        {
                            oSheet.get_Range($"{letters[j - 1]}{i}", Type.Missing).Value2 = cell[s - 1];
                        }
                        s++;
                    }
                }
                oSheet.Name = "Movie";
                xlApp.AlertBeforeOverwriting = false;
                xlApp.DisplayAlerts = false;
                workbook.SaveAs(Path + ".csv", XlFileFormat.xlWorkbookNormal);
                xlApp.Quit();
            }
            else
            {
                using (FileStream fstream = new FileStream($"file.{type}", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fstream.Write(array, 0, array.Length);
                }
            }
            // добавить уведомление о пути сохранения файла
            MessageBox.Show($"Файл сохранен по этому пути: {Path}.{type}");
        }
    }
}
