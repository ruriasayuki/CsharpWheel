using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asayuki.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    class DataArr : System.Attribute
    {
        private bool _flag;
        public DataArr()
        {
            _flag = true;
        }
        public bool flag
        {
            get{return _flag;}
            set{_flag = value;}
        }
    }
}
