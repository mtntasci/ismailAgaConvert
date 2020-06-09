using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;


namespace ismailAgaConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOzluSozler_Click(object sender, EventArgs e)
        {
            txtjson.Text = "";
            List<ozluSoz> _ozluSozler = OzluSozler.GetJson();
            string json = JsonConvert.SerializeObject(_ozluSozler, Formatting.Indented);
            txtjson.Text = json;
        }
        sealed class OzluSozler
        {

            private static List<ozluSoz> _instance =
              new List<ozluSoz>();

            private List<ozluSoz> _ozluSoz;
            private OzluSozler()
            {               
            }

            public static List<ozluSoz> GetJson()
            {
                string path = "C:\\Docs\\2020-ozlu-sozler.docx";
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                object file = path;
                object nullobj = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj);
                doc.ActiveWindow.Selection.WholeStory();
                doc.ActiveWindow.Selection.Copy();
                doc.Close();
                IDataObject data = Clipboard.GetDataObject();
                string txt = data.GetData(DataFormats.Text).ToString();
                string[] _lines = Regex.Split(txt, Environment.NewLine);

                int j = 0;

                _instance = new List<ozluSoz>();
                ozluSoz oz = new ozluSoz();

                DateTime startDate = Convert.ToDateTime("31.12.2019");

                for (int i = 0; i < _lines.Length; i++)
                {

                    if (_lines[i] != "Ocak" && _lines[i] != "Şubat" && _lines[i] != "Mart" && _lines[i] != "Nisan"
                        && _lines[i] != "Mayıs" && _lines[i] != "Haziran" && _lines[i] != "1 Temmuz" && _lines[i] != "Ağustos"
                        && _lines[i] != "Eylül" && _lines[i] != "Ekim" && _lines[i] != "Kasım" && _lines[i] != "Aralık")
                    {

                        j = j + 1;
                        oz = new ozluSoz();
                        oz.word_id = j.ToString();
                        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.AddDays(j).Month);
                        oz.TarihSayi = (startDate.AddDays(j).Day.ToString() + "." + startDate.AddDays(j).Month.ToString() + "." + startDate.AddDays(j).Year.ToString());
                        oz.TarihYazi = (startDate.AddDays(j).Day.ToString() + " " + monthName + " " + startDate.AddDays(j).Year.ToString());
                        oz.Onsoz = _lines[i].ToString();
                        _instance.Add(oz);

                    }

                }
                return _instance;
            }

          
        }

        class ozluSoz
        {
            public string word_id { get; set; }
            public string TarihYazi { get; set; }
            public string TarihSayi { get; set; }
            public string Onsoz { get; set; }

        }

        private void btnTarihteBugün_Click(object sender, EventArgs e)
        {
            txtjson.Text = "";
            txtjson.Text = "";
            List<tarihteBugun> _tarihteBugun = TarihteBugun.GetJson();
            string json = JsonConvert.SerializeObject(_tarihteBugun, Formatting.Indented);
            txtjson.Text = json;
        }

        sealed class TarihteBugun
        {

            private static List<tarihteBugun> _tarihteBugunInstance =
              new List<tarihteBugun>();

            private List<tarihteBugun> _tarihteBugun;
            private TarihteBugun()
            {
            }

            public static List<tarihteBugun> GetJson()
            {
                string path = "C:\\Docs\\2020-tarihte-bugun.docx";
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                object file = path;
                object nullobj = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj);
                doc.ActiveWindow.Selection.WholeStory();
                doc.ActiveWindow.Selection.Copy();
                doc.Close();
                IDataObject data = Clipboard.GetDataObject();
                string txt = data.GetData(DataFormats.Text).ToString();
                string[] _lines = Regex.Split(txt, Environment.NewLine);

                int j = 0;

                _tarihteBugunInstance = new List<tarihteBugun>();
                tarihteBugun oz = new tarihteBugun();

                DateTime startDate = Convert.ToDateTime("01.01.2020");
                string notes = string.Empty;

                for (int i = 0; i < _lines.Length; i++)
                {
                    bool result = true;
                    DateTime dt = Convert.ToDateTime("31.12.2019"); 

                    try
                    {
                       dt = Convert.ToDateTime(_lines[i] + " 2020");
                    }
                    catch (Exception)
                    {
                        result = false;

                    }
                    if (result == true)
                    {
                        
                        if (notes != string.Empty)
                        {
                            startDate = dt.AddDays(-1);
                            j = j + 1;
                            oz = new tarihteBugun();
                            oz.history_id = j.ToString();
                            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.Month);
                            oz.TarihSayi = (startDate.Day.ToString() + "." + startDate.Month.ToString() + "." + startDate.AddDays(j).Year.ToString());
                            oz.TarihYazi = (startDate.Day.ToString() + " " + monthName + " " + startDate.Year.ToString());
                            oz.GununOnemi = notes;
                            _tarihteBugunInstance.Add(oz);
                            notes = string.Empty;
                        }
                    }
                    if (result== false)
                    {
                        notes = notes + "- " + _lines[i].ToString() + " ";
                        

                    }

                }
                return _tarihteBugunInstance;
            }
            public bool isDate(string lineText)
            {
                bool result = false;

                try
                {
                    DateTime dt = Convert.ToDateTime(lineText + " 2020");
                }
                catch (Exception)
                {


                }
                finally
                {
                    result = true;
                }

                return result;
            }

        }

        class tarihteBugun
        {
            public string history_id { get; set; }
            public string TarihYazi { get; set; }
            public string TarihSayi { get; set; }
            public string GununOnemi { get; set; }

        }

      

        private void btnArkaSayfa_Click(object sender, EventArgs e)
        {
            //txtjson.Text = "";
            //List<arkaSayfa> _arkaSayfa = ArkaSayfa.GetJson();
            //string json = JsonConvert.SerializeObject(_arkaSayfa, Formatting.Indented);
            //txtjson.Text = json;
        }

        sealed class ArkaSayfa
        {

            private static List<arkaSayfa> _arkaSayfaInstance =
              new List<arkaSayfa>();

            private List<arkaSayfa> _arkaSayfa;
            private ArkaSayfa()
            {
            }

            public static List<arkaSayfa> GetJson()
            {
                string path = "C:\\Docs\\2020-tarihte-bugun.docx";
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                object file = path;
                object nullobj = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj,
                ref nullobj, ref nullobj, ref nullobj);
                doc.ActiveWindow.Selection.WholeStory();
                doc.ActiveWindow.Selection.Copy();
                doc.Close();
                IDataObject data = Clipboard.GetDataObject();
                string txt = data.GetData(DataFormats.Text).ToString();
                string[] _lines = Regex.Split(txt, Environment.NewLine);

                int j = 0;

                _arkaSayfaInstance = new List<arkaSayfa>();
                arkaSayfa oz = new arkaSayfa();

                DateTime startDate = Convert.ToDateTime("31.12.2019");

                for (int i = 0; i < _lines.Length; i++)
                {

                    if (_lines[i] != "Ocak" && _lines[i] != "Şubat" && _lines[i] != "Mart" && _lines[i] != "Nisan"
                        && _lines[i] != "Mayıs" && _lines[i] != "Haziran" && _lines[i] != "Temmuz" && _lines[i] != "Ağustos"
                        && _lines[i] != "Eylül" && _lines[i] != "Ekim" && _lines[i] != "Kasım" && _lines[i] != "Aralık")
                    {

                        j = j + 1;
                        oz = new arkaSayfa();
                        oz.takvim_id = j.ToString();
                        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.AddDays(j).Month);
                        oz.takvim_tarih = (startDate.AddDays(j).Day.ToString() + "." + startDate.AddDays(j).Month.ToString() + "." + startDate.AddDays(j).Year.ToString());
                        oz.takvim_baslik = (startDate.AddDays(j).Day.ToString() + " " + monthName + " " + startDate.AddDays(j).Year.ToString());
                        oz.takvim_aciklama = _lines[i].ToString();
                        _arkaSayfaInstance.Add(oz);

                    }

                }
                return _arkaSayfaInstance;
            }


        }

        class arkaSayfa
        {
            public string takvim_id { get; set; }
            public string takvim_baslik { get; set; }
            public string takvim_tarih { get; set; }
            public string takvim_aciklama { get; set; }

        }
    }
}

