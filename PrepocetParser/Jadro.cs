using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepocetParser
{
    public class Jadro
    {
        List<KeyValuePair<string, string>> ListHodnot { get; set; }
        public Jadro()
        {
            ListHodnot = new List<KeyValuePair<string, string>>();
        }

        public string VyparsujHodnoty(string s, string druh)
        {
            var newString = s.Replace("\r\n\t\r\n\r\n", "\r\n\r\n");
            var ss = newString.Split(new string[1] { "\r\n\r\n" }, StringSplitOptions.None).ToList();
            var oddelovac = ss.IndexOf(" ") / 2 ;

            var output = "";

            while (true)
            {
                var item = ss.First();
                if (item == " ")
                {
                    ss.Remove(item);
                }
                else
                {

                    ListHodnot.Add(new KeyValuePair<string, string>(item, ss[ss.IndexOf(ss.First(x => x.Contains(",")))]));
                    ss.Remove(item);
                    ss.Remove(ss[ss.IndexOf(ss.First(x => x.Contains(",")))]);
                }

                if (ss.Count == 0 || ss.Count(x => x.Contains(",")) == 0)
                {
                    break;
                }
            }

            foreach (var item in ListHodnot)
            {
                output += "INSERT INTO 'prepoctove_tabulky' VALUES('" + druh + "'," + item.Key + "," + (int.Parse(item.Value,NumberStyles.Number)*10).ToString() + ");";
            }

            return output;
        }

        public string[] GetStringField(string sql)
        {
            var list = new List<string>();

            //const string sql = "SELECT druh_ryby FROM druh_ryby;";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection("Data Source=ulovky.db")))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var druhRyby = reader.GetString(0);

                                list.Add(druhRyby);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list.ToArray();
        }
    }
}
