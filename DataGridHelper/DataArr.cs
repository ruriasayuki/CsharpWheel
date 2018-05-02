using System;
using System.Collections.Generic;
using System.Text;
namespace Asayuki.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    class DataArr : System.Attribute
    {
        private string _name;
        private int _width=100;
        private int _priority = 1;
        public DataArr(string name)
        {
            _name = name;
        }
        public DataArr(string name,int width)
        {
            _name = name;
            _width = width;
        }
        public DataArr(string name,int width,int priority)
        {
            _name = name;
            _width = width;
            _priority = priority;
        }
        public string name
        {
            get{ return _name;}
            set{ _name = value;}
        }
        public int width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
    }
}
