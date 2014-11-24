using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Ulovky.ListViewTemp;
using Ulovky.SumarnaTabulka;

namespace Ulovky
{
    public class Jadro
    {
        private readonly string _dbConnection;
        public List<KeyValuePair<string, string>> ListRokov { get; set; }
        public string User { get; set; }
        public int Rok { get; set; }
        public string[] SuggestDruhRyby { get; set; }
        public string[] SuggestSposobLovu { get; set; }
        public string[] SuggestNastraha { get; set; }
        public string[] SuggestCisloReviru { get; set; }
        public string[] SuggestNazovReviru { get; set; }
        public List<Ulovok> AktualnyRok { get; set; }
        public List<PrepoctoveTabulkyItem> ListPrepoctoveTabulky { get; set; } 


        public Jadro()
        {
            AktualnyRok=new List<Ulovok>();
            _dbConnection = "Data Source=ulovky.db";
            ListRokov = NacitajRoky();
            ListPrepoctoveTabulky = NacitajPrepoctoveTabulky();
            SuggestDruhRyby = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestDruhRyby);
            SuggestNastraha = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestNastraha);
            SuggestSposobLovu = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestSposobLovu);
            SuggestCisloReviru = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestCisloReviru);
            SuggestNazovReviru = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestNazovReviru);

            SkontrolujPrepoctoveTabulky();
        }

        private List<PrepoctoveTabulkyItem> NacitajPrepoctoveTabulky()
        {
            var list = new List<PrepoctoveTabulkyItem>();

            const string sql = "SELECT * FROM prepoctove_tabulky;";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var druh = reader.GetString(0);
                                var dlzka = reader.GetInt32(1).ToString(CultureInfo.InvariantCulture);
                                var vaha = reader.GetInt32(2).ToString(CultureInfo.InvariantCulture);

                                list.Add(new PrepoctoveTabulkyItem(druh, dlzka, vaha));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list;
        }

        private List<KeyValuePair<string, string>> NacitajRoky()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("", "")
            };

            const string sql = "SELECT * FROM roky;";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = reader.GetString(0);
                                var rok = reader.GetInt32(1).ToString(CultureInfo.InvariantCulture);

                                list.Add(new KeyValuePair<string, string>(user, rok));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list;
        }

        public List<Ulovok> VratListUlovky(int rok, string user)
        {
            var list = new List<Ulovok>();

            var sql = "SELECT * FROM ulovky WHERE rok='" + rok + "' AND user ='" + user + "';";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var index = reader.GetInt64(0);
                                var datum = new DateTime(reader.GetInt32(3), reader.GetInt32(2), reader.GetInt32(1));
                                var cisloReviru = reader.GetString(4);
                                var nazovReviru = reader.GetString(5);
                                var lokalita = reader.GetString(6);
                                var druh = reader.GetString(7);
                                var dlzka = reader.GetInt32(8);
                                var vaha = reader.GetInt32(9);
                                var sposobLovu = reader.GetString(10);
                                var nastraha = reader.GetString(11);
                                var pustena = reader.GetString(12) == "Ano" || reader.GetString(12) == "True";
                                var poznamky = reader.GetString(13);
                                var flagPoznamky = !string.IsNullOrEmpty(poznamky);

                                list.Add(new Ulovok(index, datum, cisloReviru, nazovReviru, lokalita, druh, dlzka, vaha,
                                    sposobLovu, nastraha, pustena, poznamky, flagPoznamky));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list.OrderBy(x =>x.Datum).ToList();
        }

        public HlavnaTabulkaLiestViewItem[] NacitajUlovky()
        {
            var list = VratListUlovky(Rok, User);

            AktualnyRok = list;

            return AktualnyRok.Select((t, l) => new HlavnaTabulkaLiestViewItem(t, l + 1)).ToArray();
        }

        public void NastavNasledujuceRoky(Button buttonNasled, Button buttonPredch)
        {
            var listRokov =
                new List<string>(ListRokov.Where(x => x.Key == User).Select(x => x.Value).OrderBy(x => x).ToList());

            var predchadzajuci = listRokov.First() != Rok.ToString(CultureInfo.InvariantCulture)
                ? listRokov[listRokov.IndexOf(Rok.ToString(CultureInfo.InvariantCulture)) - 1]
                : listRokov.Last();
            var nasledujuci = listRokov.Last() != Rok.ToString(CultureInfo.InvariantCulture)
                ? listRokov[listRokov.IndexOf(Rok.ToString(CultureInfo.InvariantCulture)) + 1]
                : listRokov.First();

            buttonNasled.Text = nasledujuci;
            buttonPredch.Text = predchadzajuci;
        }

        public string[] GetStringField(string sql)
        {
            var list = new List<string>();

            //const string sql = "SELECT druh_ryby FROM druh_ryby;";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
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

        public SumarnaTabulkaLiestViewItem[] KoncorocnaTabulka()
        {
            var list = new List<SumarnaTabulka.SumarnaTabulka>();
            var druhyRyby =
                GetStringField(SqlDotazy.SqlDotazy.GetSumarneQuery(Rok.ToString(CultureInfo.InvariantCulture), User))
                    .ToList();
            var pocetUlovkov = new List<int>();
            var vahaUlovkov = new List<int>();

            for (int i = 1; i <= druhyRyby.Count; i++)
            {
                String sqlPocet = "select count(*) from ulovky where rok='" + Rok + "' and user='" + User +
                                  "' and druh='" + druhyRyby[i - 1] + "'";
                String sqlVaha = "select sum(vaha) from ulovky where rok='" + Rok + "' and user='" + User +
                                 "' and druh='" + druhyRyby[i - 1] + "'";

                try
                {
                    using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                    {
                        cnn.Open();

                        using (SQLiteCommand mycommandPocet = new SQLiteCommand(sqlPocet, cnn))
                        {
                            using (SQLiteDataReader reader = mycommandPocet.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var pocet = reader.GetInt32(0);

                                    pocetUlovkov.Add(pocet);
                                }
                            }
                        }

                        using (SQLiteCommand mycommandVaha = new SQLiteCommand(sqlVaha, cnn))
                        {
                            using (SQLiteDataReader reader = mycommandVaha.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var vaha = reader.GetInt32(0);

                                    vahaUlovkov.Add(vaha);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                list.Add(new SumarnaTabulka.SumarnaTabulka(Rok, i.ToString(CultureInfo.InvariantCulture), druhyRyby[i - 1], vahaUlovkov[i - 1],
                    pocetUlovkov[i - 1]));
            }

            list = list.OrderByDescending(x => x.Pocet).ToList();
            list.Add(new SumarnaTabulka.SumarnaTabulka(Rok, "", "Spolu : ", vahaUlovkov.Sum(), pocetUlovkov.Sum()));

            return list.Select((t, l) => new SumarnaTabulkaLiestViewItem(t, l + 1)).ToArray();
        }

        public ListViewItem[] CelkovaTabulka()
        {
            var list = new List<SumarnaTabulka.SumarnaTabulka>();
            var druhyRyby = GetStringField(SqlDotazy.SqlDotazy.GetKompletneQuery(User)).ToList();
            var pocetUlovkov = new List<int>();
            var vahaUlovkov = new List<int>();

            for (int i = 1; i <= druhyRyby.Count; i++)
            {
                String sqlPocet = "select count(*) from ulovky where user='" + User + "' and druh='" + druhyRyby[i - 1] +
                                  "'";
                String sqlVaha = "select sum(vaha) from ulovky where user='" + User + "' and druh='" + druhyRyby[i - 1] +
                                 "'";

                try
                {
                    using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                    {
                        cnn.Open();

                        using (SQLiteCommand mycommandPocet = new SQLiteCommand(sqlPocet, cnn))
                        {
                            using (SQLiteDataReader reader = mycommandPocet.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var pocet = reader.GetInt32(0);

                                    pocetUlovkov.Add(pocet);
                                }
                            }
                        }

                        using (SQLiteCommand mycommandVaha = new SQLiteCommand(sqlVaha, cnn))
                        {
                            using (SQLiteDataReader reader = mycommandVaha.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var vaha = reader.GetInt32(0);

                                    vahaUlovkov.Add(vaha);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                list.Add(new SumarnaTabulka.SumarnaTabulka(Rok, i.ToString(), druhyRyby[i - 1], vahaUlovkov[i - 1],
                    pocetUlovkov[i - 1]));
            }

            list = list.OrderByDescending(x => x.Pocet).ToList();
            list.Add(new SumarnaTabulka.SumarnaTabulka(Rok, "", "Spolu : ", vahaUlovkov.Sum(), pocetUlovkov.Sum()));

            var de = list.Select((t, l) => new SumarnaTabulkaLiestViewItem(t, l + 1)).ToArray();

            return list.Select((t, l) => new SumarnaTabulkaLiestViewItem(t, l + 1)).ToArray();
        }

        public ListViewItem[] NajvacsieUlovky()
        {
            var list = new List<Ulovok>();
            var druhyRyby = GetStringField(SqlDotazy.SqlDotazy.GetKompletneQuery(User)).ToList();
            var pocetUlovkov = new List<int>();
            var vahaUlovkov = new List<int>();

            for (int i = 1; i <= druhyRyby.Count; i++)
            {
                String sql = "select * from ulovky where user='" + User + "' and druh='" + druhyRyby[i-1] +
                             "' order by vaha desc";

                try
                {
                    using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                    {
                        cnn.Open();

                        using (SQLiteCommand mycommandPocet = new SQLiteCommand(sql, cnn))
                        {
                            using (SQLiteDataReader reader = mycommandPocet.ExecuteReader())
                            {
                                reader.Read();
                                var index = reader.GetInt64(0);
                                var datum = new DateTime(reader.GetInt32(3), reader.GetInt32(2), reader.GetInt32(1));
                                var cisloReviru = reader.GetString(4);
                                var nazovReviru = reader.GetString(5);
                                var lokalita = reader.GetString(6);
                                var druh = reader.GetString(7);
                                var dlzka = reader.GetInt32(8);
                                var vaha = reader.GetInt32(9);
                                var sposobLovu = reader.GetString(10);
                                var nastraha = reader.GetString(11);
                                var pustena = reader.GetString(12) == "Ano";
                                var poznamky = reader.GetString(13);
                                var flagPoznamky = !string.IsNullOrEmpty(poznamky);

                                list.Add(new Ulovok(index, datum, cisloReviru, nazovReviru, lokalita, druh, dlzka, vaha,
                                    sposobLovu, nastraha, pustena, poznamky, flagPoznamky));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message); 
                }
            }
            list = list.OrderBy(x => x.DruhRyby).ToList();
            return list.Select((t) => new HlavnaTabulkaLiestViewItem(t)).ToArray();
        }

        public void PridajUlovok(Ulovok ulovok)
        {
            var sql =
                "INSERT into ulovky ('ind','den','mesiac','rok','cislo_reviru','nazov_revir','lokalita','druh','dlzka','vaha','sposob_lovu','nastraha','pustena','poznamky','user') " +
                "VALUES((select max(ind) from ulovky)+1, '" + ulovok.Datum.Day + "' ,'" +
                ulovok.Datum.Month + "' ,'" + ulovok.Datum.Year + "' ," +
                "'" + ulovok.CisloReviru + "' ,'" + ulovok.NazovReviru + "' ,'" +
                ulovok.Lokalita + "' , '" + ulovok.DruhRyby + "' ," +
                "" + ulovok.Dlzka + " ," + ulovok.Vaha + " ,'" + ulovok.SposobLovu +
                "' ,'" + ulovok.Nastraha + "' ,'" + ulovok.Pustena + "' ," +
                "'" + ulovok.Poznamky + "' ,'" + User + "' );";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void EditUlovok(Ulovok ulovok)
        {
            var sql = "UPDATE 'ulovky' SET " +
                      "'den' = " + ulovok.Datum.Day + ", " +
                      "'mesiac' = '" + ulovok.Datum.Month + "', " +
                      "'rok' = '" + ulovok.Datum.Year + "', " +
                      "'cislo_reviru' = '" + ulovok.CisloReviru + "', " +
                      "'nazov_revir' = '" + ulovok.NazovReviru + "', " +
                      "'lokalita' = '" + ulovok.Lokalita + "', " +
                      "'druh' = '" + ulovok.DruhRyby + "', " +
                      "'dlzka' = '" + ulovok.Dlzka + "', " +
                      "'vaha' = '" + ulovok.Vaha + "', " +
                      "'sposob_lovu' = '" + ulovok.SposobLovu + "', " +
                      "'nastraha' = '" + ulovok.Nastraha + "', " +
                      "'pustena' = '" + ulovok.Pustena + "', " +
                      "'poznamky' = '" + ulovok.Poznamky + "' " +
                      "WHERE ind = " + ulovok.Index + "";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public string PrepocitanaVaha(string druh, string dlzka)
        {
            return ListPrepoctoveTabulky.Where(x => x.Druh == druh && x.Dlzka == dlzka).Select(x => x.Vaha).FirstOrDefault();
        }

        private void SkontrolujPrepoctoveTabulky()
        {
            var druhyRyby = GetStringField("Select druh from prepoctove_tabulky;").ToList();

            if (!druhyRyby.Contains("Šťuka severná"))
            {
                InsertQuery(SqlDotazy.SqlDotazy.PrepoctoveTabulkyStuka);
                Console.WriteLine(@"Vlozene prepoctove tabulky - Stuka");
            }
            if (!druhyRyby.Contains("Zubáč veľkoústy"))
            {
                InsertQuery(SqlDotazy.SqlDotazy.PrepoctoveTabulkyZubac);
                Console.WriteLine(@"Vlozene prepoctove tabulky - Zubac");
            }
            if (!druhyRyby.Contains("Sumec západný"))
            {
                InsertQuery(SqlDotazy.SqlDotazy.PrepoctoveTabulkySumec);
                Console.WriteLine(@"Vlozene prepoctove tabulky - Sumec");
            }
            if (!druhyRyby.Contains("Jalec tmavý"))
            {
                InsertQuery(SqlDotazy.SqlDotazy.PrepoctoveTabulkyJalecTm);
                Console.WriteLine(@"Vlozene prepoctove tabulky - Jalec tmavy");
            }
            if (!druhyRyby.Contains("Boleň dravý"))
            {
                InsertQuery(SqlDotazy.SqlDotazy.PrepoctoveTabulkyBolen);
                Console.WriteLine(@"Vlozene prepoctove tabulky - Bolan");
            }
            if (!druhyRyby.Contains("Karas striebristý"))
            {
                InsertQuery(SqlDotazy.SqlDotazy.PrepoctoveTabulkyKaras);
                Console.WriteLine(@"Vlozene prepoctove tabulky - Karas");
            }
        }

        private void InsertQuery(string sql)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void PridajPouzivatela(string value)
        {
            var sql = "INSERT INTO user ('pouzivatel') VALUES('" + value + "')";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> NacitajUserov()
        {
            var list = new List<string>();

            var sql = "Select distinct * from user";
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = reader.GetString(0);

                                list.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return list;
        }

        public void PridajNovyRok(string rok, string user)
        {
            var sql = "INSERT INTO roky ('pouzivatel','rok') VALUES('" + user + "','"+rok+"')";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void RefreshRoky()
        {
            ListRokov = NacitajRoky();
        }
    }
}
