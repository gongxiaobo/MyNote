using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LitJson;
using ConnectData.MyScript;


namespace ConnectData.MyScript
{
    class N_testJson
    {
        public void fn_testjson() {

            //test json

            MyJsonData t_jsondata = new MyJsonData("gong", 30);


            string t_myjson = JsonMapper.ToJson(t_jsondata);

            Console.WriteLine("json=" + t_myjson);

            MyJsonData t_fromJson = null;
            try
            {
                t_fromJson = JsonMapper.ToObject<MyJsonData>(t_myjson);
            }
            catch (Exception _e)
            {

                Console.WriteLine(_e.ToString());
            }


            if (t_fromJson != null)
            {

                Console.WriteLine("--->" + t_fromJson.m_name + ",age=" + t_fromJson.m_age);
            }

        
        }

    }
}
