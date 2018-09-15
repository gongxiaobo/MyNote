
using System.Collections.Generic;
namespace GasPowerGeneration
{
     //namespace GCode{
     public class CSVFactory
     {

          private static readonly IDictionary<string, LanguageTable> LanguageOrmDic = new Dictionary<string, LanguageTable>();//测试的表格
          private static readonly IDictionary<string, NDCw> ndcwOrmDic = new Dictionary<string, NDCw>();//测试的表格

          private static readonly IDictionary<string, StudyChapterTable> m_studychaptertable = new Dictionary<string, StudyChapterTable>();
          private CSVFactory() { }
          /// <summary>
          /// //加载资源
          /// </summary>
          /// <param name="aUrl">A URL.</param>
          public static void LoadResources(string aUrl)
          {
               //		CSVManager.LoadResource(aUrl, testOrmDic);chapterset
               switch (aUrl)
               {
                    case "language":
                         CSVManager.LoadResource(aUrl, LanguageOrmDic);
                         break;
                    case "ndcw":
                         CSVManager.LoadResource(aUrl, ndcwOrmDic);
                         break;
                    case "chapterset01":
                         CSVManager.LoadResource(aUrl, m_studychaptertable);
                         break;

               }


          }

          /// <summary>
          /// 获取语言列表
          /// </summary>
          /// <returns>The language orm dic.</returns>
          /// <param name="_strName">String name.</param>
          public static LanguageTable getLanguageOrmDic(string _strName)
          {
               LanguageTable orm;
               LanguageOrmDic.TryGetValue(_strName, out orm);
               //			Debug.Log ("LanguageOrmDic.keys="+LanguageOrmDic.Count);
               return orm;
          }
          public static NDCw getNdcwOrmDic(string _ID)
          {
               NDCw orm;
               ndcwOrmDic.TryGetValue(_ID, out orm);
               //			Debug.Log ("LanguageOrmDic.keys="+LanguageOrmDic.Count);
               return orm;
          }


          public static StudyChapterTable getChapterDic(int _id)
          {
               StudyChapterTable t_table;
               //		m_studychaptertable.TryGetValue (_id.ToString(), out t_table);
               return m_studychaptertable.TryGetValue(_id.ToString(), out t_table) ? t_table : null;
          }


          public static void fns_LoadTable(string _name)
          {

          }
          //	public static T fns_ReadTable<T> (string _name, string _index){
          //		T t_table;
          //		return t_table;
          //	}
     }
     //}

}