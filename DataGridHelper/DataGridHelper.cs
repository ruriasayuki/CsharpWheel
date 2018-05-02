using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Asayuki.Common
{
    class DataGridHelper
    {
        public void addAttrColumns(Type someType, DataGridView dataGridView)
        {
            addAttrColumns(someType, dataGridView, 1);

        }
        public void addAttrColumns(Type someType, DataGridView dataGridView,int priority)
        {
            IList<string> AttrProp = new List<string>();

            MemberInfo[] info = someType.GetMembers();
            for (int i = 0; i < info.Length; i++)
            {
                object[] attributes = info[i].GetCustomAttributes(true);
                for (int j = 0; j < attributes.Length; j++)
                {

                    if (attributes[j].ToString() == "ControlWin.Common.DataArr")
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
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.DataPropertyName = a.ToString().Split('_')[0].Split(' ')[1];
                    column.Name = a.ToString().Split('_')[1];
                    column.Width = int.Parse(a.ToString().Split('_')[2]);
                    dataGridView.Columns.Add(column);
                }
            }

        }
    }
}
