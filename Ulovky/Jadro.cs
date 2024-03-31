using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Ulovky.ListViewTemp;
using Ulovky.Lokality;
using Ulovky.Statistiky;
using Ulovky.SumarnaTabulka;

namespace Ulovky
{
    public class Jadro
    {
        private readonly string _dbConnection;
        public List<KeyValuePair<string, string>> ListRokov { get; set; }
        public string User { get; set; }
        public string Rok { get; set; }
        public string[] SuggestDruhRyby { get; set; }
        public string[] SuggestSposobLovu { get; set; }
        public string[] SuggestNastraha { get; set; }
        public string[] SuggestCisloReviru { get; set; }
        public string[] SuggestNazovReviru { get; set; }
        public List<Ulovok> AktualnyRok { get; set; }
        public List<PrepoctoveTabulkyItem> ListPrepoctoveTabulky { get; set; }
        public List<Revir> ListRevirov { get; set; } 


        public Jadro()
        {
            AktualnyRok=new List<Ulovok>();
            _dbConnection = "Data Source=ulovky.db";
            ListRokov = NacitajRoky();
            ListPrepoctoveTabulky = NacitajPrepoctoveTabulky();
            ListRevirov = NacitajReviry();
            SuggestDruhRyby = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestDruhRyby);
            SuggestNastraha = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestNastraha);
            SuggestSposobLovu = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestSposobLovu);
            SuggestCisloReviru = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestCisloReviru);
            SuggestNazovReviru = GetStringField(SqlDotazy.SqlDotazy.QuerySuggestNazovReviru);

            SkontrolujPrepoctoveTabulky();
        }

        private List<Revir> NacitajReviry()
        {
            var list = new List<Revir>();

            const string sql = "SELECT cislo_reviru, nazov_revir FROM ulovky group by cislo_reviru;";

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
                                var cisloReviru = reader.GetString(0);
                                var nazovReviru = reader.GetString(1);

                                list.Add(new Revir(cisloReviru, nazovReviru));
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

            return list.Distinct().ToList();
        }

        public List<Ulovok> VratListUlovky(string rok, string user)
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
                var sqlPocet = "select count(*) from ulovky where rok='" + Rok + "' and user='" + User +
                                  "' and druh='" + druhyRyby[i - 1] + "'";
                var sqlVaha = "select sum(vaha) from ulovky where rok='" + Rok + "' and user='" + User +
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
                var sqlPocet = "select count(*) from ulovky where user='" + User + "' and druh='" + druhyRyby[i - 1] +
                                  "'";
                var sqlVaha = "select sum(vaha) from ulovky where user='" + User + "' and druh='" + druhyRyby[i - 1] +
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

        public string NazovReviru(string cisloReviru)
        {
            return ListRevirov.Where(x => x.CisloReviru == cisloReviru).Select(x => x.NazovReviru).FirstOrDefault();
        }

        public void ZmazZaznam(int index)
        {
            var ulovok = AktualnyRok[index];
            var sql = string.Format("DELETE from ulovky where ind = '{0}'", ulovok.Index);

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        var res = mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ListViewItem[] StatistickaTabluka(string type, string condition)
        {
            var list = new List<StatistikyItem>();
            var druhyRyby = GetStringField(SqlDotazy.SqlDotazy.GetKompletneQuery(User)).ToList();
            var pocetUlovkov = new List<int>();
            var vahaUlovkov = new List<int>();
            string sql = string.Empty;

            switch (type)
            {
                case null:
                    sql = $"SELECT druh, nastraha, count(nastraha) as pocet, sum(vaha) as vaha, sum(vaha) / count(nastraha) as priemer " +
                              $"FROM ulovky " +
                              "GROUP BY druh, nastraha;";
                    break;
                case "Nastraha":
                    if (string.IsNullOrEmpty(condition))
                    {
                        sql = $"SELECT druh, nastraha, count(nastraha) as pocet, sum(vaha) as vaha, sum(vaha) / count(nastraha) as priemer " +
                              $"FROM ulovky " +
                              "GROUP BY druh, nastraha;";
                    }
                    else
                    {
                        sql = $"SELECT druh, nastraha, count(nastraha) as pocet, sum(vaha) as vaha, sum(vaha) / count(nastraha) as priemer " +
                              $"FROM ulovky " +
                              $"WHERE druh ='{condition}' " +
                              "GROUP BY druh, nastraha;";
                    }
                    break;
                case "Sposob":
                    if (string.IsNullOrEmpty(condition))
                    {
                        sql = $"SELECT druh, sposob_lovu, count(sposob_lovu) as pocet, sum(vaha) as vaha, sum(vaha) / count(sposob_lovu) as priemer " +
                              $"FROM ulovky " +
                              "GROUP BY druh, sposob_lovu;";
                    }
                    else
                    {
                        sql = $"SELECT druh, sposob_lovu, count(sposob_lovu) as pocet, sum(vaha) as vaha, sum(vaha) / count(sposob_lovu) as priemer " +
                              $"FROM ulovky " +
                              $"WHERE sposob_lovu ='{condition}' " +
                              "GROUP BY druh, sposob_lovu;";
                    }
                    break;
                case "Revir":
                    if (string.IsNullOrEmpty(condition))
                    {
                        sql = $"SELECT druh, cislo_reviru, nazov_revir, count(cislo_reviru) as pocet, sum(vaha) as vaha, sum(vaha) / count(sposob_lovu) as priemer " +
                              $"FROM ulovky " +
                              "GROUP BY druh, cislo_reviru;";
                    }
                    else
                    {
                        sql = $"SELECT druh, cislo_reviru, nazov_revir, count(cislo_reviru) as pocet, sum(vaha) as vaha, sum(vaha) / count(sposob_lovu) as priemer " +
                              $"FROM ulovky " +
                              $"WHERE sposob_lovu ='{condition}' " +
                              "GROUP BY druh, cislo_reviru;";
                    }
                    break;
            }

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();

                    using (SQLiteCommand mycommandPocet = new SQLiteCommand(sql, cnn))
                    {
                        using (SQLiteDataReader reader = mycommandPocet.ExecuteReader())
                        {
                            string druhRyby = string.Empty;

                            while (reader.Read())
                            {
                                if (type == "Revir")
                                {
                                    list.Add(new StatistikyItem("", reader.GetString(0), $"{reader.GetString(1)} - {reader.GetString(2)}", "",
                                        reader.GetInt32(4), reader.GetInt32(3), reader.GetInt32(5)));
                                }
                                else
                                {
                                    list.Add(new StatistikyItem("", reader.GetString(0), reader.GetString(1), "",
                                        reader.GetInt32(3), reader.GetInt32(2), reader.GetInt32(4)));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            

            return list.OrderBy(x => x.DruhRyby).ThenByDescending(y => y.Pocet).Select((t, l) => new StatistikyListViewItem(t)).ToArray();
        }

        internal ListViewItem[] LoadLokality(string cisloReviru)
        {
            var list = new List<LokalityListViewItem>();

            string sql = $"SELECT distinct u.lokalita, u.cislo_reviru, l.popis, l.gps " +
                $"FROM ulovky u " +
                $"left join lokality l on u.cislo_reviru=l.cislo_reviru and u.lokalita = l.lokalita " +
                $"where u.cislo_reviru = '{cisloReviru}';";

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
                                //var cislo = reader.GetString(0);
                                var lokalita = reader.GetString(0);
                                var popis = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                var gps = reader.IsDBNull(3) ? "" : reader.GetString(3);

                                list.Add(new LokalityListViewItem(new LokalityItem(cisloReviru, lokalita, popis, gps)));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("no such table: lokality"))
                {
                    CreateNewTable(SqlDotazy.SqlDotazy.VytvorTabulkuLokality);               
                }
                else
                {
                    throw new Exception(e.Message);
                }                
            }

            return list.ToArray();
        }

        private void CreateNewTable(string sqlCreationScript)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sqlCreationScript, cnn))
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

        internal void LokalitaUpdate(string cisloReviru, string lokalita, string popis, string gps)
        {
            string sql = $"SELECT count(*) " +
                $"FROM lokality l " +
                $"where l.cislo_reviru = '{cisloReviru}' AND l.lokalita = '{lokalita}';";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        var count = mycommand.ExecuteScalar();

                        if (count.ToString() == "0")
                        {
                            InsertLokalitu(cisloReviru, lokalita, popis, gps);
                        }
                        else
                        {
                            UpdateLokalita(cisloReviru, lokalita, popis, gps);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void UpdateLokalita(string cisloReviru, string lokalita, string popis, string gps)
        {
            string sql = $"UPDATE lokality " +
                $"SET popis = '{popis}', " +
                $"gps = '{gps}' " +
                $"WHERE cislo_reviru = '{cisloReviru}' AND lokalita = '{lokalita}';";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        var res = mycommand.ExecuteNonQuery();                        
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void InsertLokalitu(string cisloReviru, string lokalita, string popis, string gps)
        {
            string sql = $"INSERT into lokality(cislo_reviru, lokalita, popis, gps)" +
                $"VALUES('{cisloReviru}', '{lokalita}', '{popis}', '{gps}');";

            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(new SQLiteConnection(_dbConnection)))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(sql, cnn))
                    {
                        var res = mycommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
