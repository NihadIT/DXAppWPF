using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXAppWPF.Interfaces
{
    public interface IConvert
    {
        void SaveFile(string text, string type);
        string CheckRow(object sender);
    }
}
