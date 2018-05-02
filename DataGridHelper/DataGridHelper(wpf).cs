using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Asayuki.Common
{
    class DataGridHelper
    {
        public void addAttrColumns(Type someType, DataGrid dataGridView)
        {
            addAttrColumns(someType, dataGridView, 1);

        }
        public void addAttrColumns(Type someType, DataGrid dataGridView,int priority)
        {
            IList<string> AttrProp = new List<string>();

            MemberInfo[] info = someType.GetMembers();
            for (int i = 0; i < info.Length; i++)
            {
                object[] attributes = info[i].GetCustomAttributes(true);
                for (int j = 0; j < attributes.Length; j++)
                {

                    if (attributes[j].ToString() == "Asayuki.Common.DataArr")
                    {
                        AttrProp.Add(info[i].ToString() + '_' + ((DataArr)attributes[j]).name + '_' + ((DataArr)attributes[j]).width+'_'+((DataArr)attributes[j]).priority);
                        break;
                    }
                }
            }
            foreach (string a in AttrProp)
            {
                int cp = int.Parse(a.ToString().Split('_')[3]);
                if (cp <= priority)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.IsReadOnly = true;
                    column.Binding = new Binding(a.ToString().Split('_')[0].Split(' ')[1]);
                    column.Header = a.ToString().Split('_')[1];
                    column.Width = int.Parse(a.ToString().Split('_')[2]);
                    dataGridView.Columns.Add(column);
                }
            }

        }
    }
}
