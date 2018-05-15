using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConnectData.MyScript
{
    [Serializable]
    class MyJsonData
    {
        public string m_name;
        public int m_age;
        public MyJsonData(string _name, int _age) {
            m_name = _name;
            m_age = _age;

        }
        public MyJsonData() { }


    }
}
