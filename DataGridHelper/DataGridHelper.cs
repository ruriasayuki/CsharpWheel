using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asayuki.Common
{
    class DataGridHelper
    {
        public void addAttrColumns(Type someType, DataGridView dataGridView)
        {
            IList<string> AttrProp = new List<string>();

            MemberInfo[] info = someType.GetMembers();
            for (int i = 0; i < info.Length; i++)
            {
                object[] attributes = info[i].GetCustomAttributes(true);
                for (int j = 0; j < attributes.Length; j++)
                {

                    if (attributes[j].ToString() == "JXGY.Common.DataArr")
                    {
                        AttrProp.Add(info[i].ToString());
                        break;
                    }
                }
            }
            foreach (string a in AttrProp)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = a.ToString().Split(' ')[1];
                column.Name = a.ToString().Split(' ')[1];
                dataGridView.Columns.Add(column);
            }

        }
    }
}
