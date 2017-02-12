using System;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace Rations4Animals_MVC.Models
{
    public class FeedStuff
    {
        public string Feedstuff { get; set; }
        public double DM { get; set; }
        public double CP { get; set; }
        public double RUP { get; set; }
        public double CF { get; set; }
        public double EE { get; set; }
        public double ADF { get; set; }
        public double NDF { get; set; }
        public double eNDF { get; set; }
        public double TDNCattle { get; set; }
        public double TDNSheep { get; set; }
        public double DESheep { get; set; }
        public double MECattle { get; set; }
        public double MESheep { get; set; }
        public double NEmCattle { get; set; }
        public double NEgCattle { get; set; }
        public double NElCattle { get; set; }
        public double MEPoultry { get; set; }
        public double DEHorse { get; set; }
        public double DEPig { get; set; }
        public double MEPig { get; set; }
        public double Arg { get; set; }
        public double His { get; set; }
        public double Iso_L { get; set; }
        public double Leu { get; set; }
        public double Lys { get; set; }
        public double Met { get; set; }
        public double Cys { get; set; }
        public double Phe { get; set; }
        public double Tyr { get; set; }
        public double Thr { get; set; }
        public double Trp { get; set; }
        public double Val { get; set; }
        public double Gly { get; set; }
        public double Ser { get; set; }
        public double Ca { get; set; }
        public double Cl { get; set; }
        public double Mg { get; set; }
        public double P { get; set; }
        public double K { get; set; }
        public double Na { get; set; }
        public double S { get; set; }
        public double Co { get; set; }
        public double Cu { get; set; }
        public double I { get; set; }
        public double Fe { get; set; }
        public double Mn { get; set; }
        public double Se { get; set; }
        public double Zn { get; set; }
        public double VitA { get; set; }
        public double VitD { get; set; }
        public double VitE { get; set; }
        public double VitK { get; set; }
        public double Biotin { get; set; }
        public double Choline { get; set; }
        public double Folic { get; set; }
        public double Niacin { get; set; }
        public double Pantot { get; set; }
        public double VitB2 { get; set; }
        public double VitB1 { get; set; }
        public double VitB6 { get; set; }
        public double VitB12 { get; set; }
        public double CostPerKilogram { get; set; }
        public double Weight { get; set; }
        public string persentageLimitMin { get; set; }
        public string persentageLimitMax { get; set; }
        public int ID { get; set; }


        public string Display
        {
            get { return string.Format("{0} @ R {1} / Ton", Feedstuff, CostPerKilogram * 1000); }
        }

        public FeedStuff()
        {
        }

        public object getValue(String name)
        {

                PropertyInfo pi = typeof(FeedStuff).GetProperty(name);
                object o = (object)pi.GetValue(this, null);
                return o;

        }

        public static FeedStuff Create(DataRow dataRow)
        {
            FeedStuff fs = new FeedStuff();
            fs.Feedstuff = dataRow.Field<string>("FeedStuff");
            fs.DM = dataRow.Field<double>("DM");
            fs.CP = dataRow.Field<double>("CP");
            fs.RUP = dataRow.Field<double>("RUP");
            fs.CF = dataRow.Field<double>("CF");
            fs.EE = dataRow.Field<double>("EE");
            fs.ADF = dataRow.Field<double>("ADF");
            fs.eNDF = dataRow.Field<double>("eNDF");
            fs.NDF = dataRow.Field<double>("NDF");
            fs.TDNCattle = dataRow.Field<double>("TDNCattle");
            fs.TDNSheep = dataRow.Field<double>("TDNSheep");
            fs.DESheep = dataRow.Field<double>("DESheep");
            fs.MECattle = dataRow.Field<double>("MECattle");
            fs.MESheep = dataRow.Field<double>("MESheep");
            fs.NEmCattle = dataRow.Field<double>("NEmCattle");
            fs.NEgCattle = dataRow.Field<double>("NEgCattle");
            fs.NElCattle = dataRow.Field<double>("NElCattle");
            fs.MEPoultry = dataRow.Field<double>("MEPoultry");
            fs.DEHorse = dataRow.Field<double>("DEHorse");
            fs.DEPig = dataRow.Field<double>("DEPig");
            fs.MEPig = dataRow.Field<double>("MEPig");
            fs.Arg = dataRow.Field<double>("Arg");
            fs.His = dataRow.Field<double>("His");
            fs.Iso_L = dataRow.Field<double>("Iso_L");
            fs.Leu = dataRow.Field<double>("Leu");
            fs.Lys = dataRow.Field<double>("Lys");
            fs.Met = dataRow.Field<double>("Met");
            fs.Cys = dataRow.Field<double>("Cys");
            fs.Phe = dataRow.Field<double>("Phe");
            fs.Tyr = dataRow.Field<double>("Tyr");
            fs.Thr = dataRow.Field<double>("Thr");
            fs.Trp = dataRow.Field<double>("Trp");
            fs.Val = dataRow.Field<double>("Val");
            fs.Gly = dataRow.Field<double>("Gly");
            fs.Ser = dataRow.Field<double>("Ser");
            fs.Ca = dataRow.Field<double>("Ca");
            fs.Cl = dataRow.Field<double>("Cl");
            fs.Mg = dataRow.Field<double>("Mg");
            fs.P = dataRow.Field<double>("P");
            fs.K = dataRow.Field<double>("K");
            fs.Na = dataRow.Field<double>("Na");
            fs.S = dataRow.Field<double>("S");
            fs.Co = dataRow.Field<double>("Co");
            fs.Cu = dataRow.Field<double>("Cu");
            fs.I = dataRow.Field<double>("I");
            fs.Fe = dataRow.Field<double>("Fe");
            fs.Mn = dataRow.Field<double>("Mn");
            fs.Se = dataRow.Field<double>("Se");
            fs.Zn = dataRow.Field<double>("Zn");
            fs.VitA = dataRow.Field<double>("VitA");
            fs.VitD = dataRow.Field<double>("VitD");
            fs.VitE = dataRow.Field<double>("VitE");
            fs.VitK = dataRow.Field<double>("VitK");
            fs.Biotin = dataRow.Field<double>("Biotin");
            fs.Choline = dataRow.Field<double>("Choline");
            fs.Folic = dataRow.Field<double>("Folic");
            fs.Niacin = dataRow.Field<double>("Niacin");
            fs.Pantot = dataRow.Field<double>("Pantot");
            fs.VitB2 = dataRow.Field<double>("VitB2");
            fs.VitB1 = dataRow.Field<double>("VitB1");
            fs.VitB6 = dataRow.Field<double>("VitB6");
            fs.VitB12 = dataRow.Field<double>("VitB12");
            fs.ID = dataRow.Field<int>("ID");
            return fs;
   
        }

        public static FeedStuff getFeedStuff(int index)
        {

            return FeedStuff.Create(Database.getRows(string.Format("Select * From tableFeedStuff WHERE ID={0}",index))[0]);
  
        }

        public static FeedStuff[] getFeedStuff()
        {
       
                DataRowCollection dataRowCollection = Database.getRows("Select * From tableFeedStuff ORDER BY ID ASC");
                FeedStuff[] fsList = new FeedStuff[dataRowCollection.Count];
                for (int i = 0; i < fsList.Length; i++)
                {
                    FeedStuff f = FeedStuff.Create(dataRowCollection[i]);
                    fsList[i] = f;
                }
                return fsList;

        }

        public static FeedStuff[] getFeedStuffFromQuery(string sql)
        {
 
            DataRowCollection dataRowCollection = Database.getRows(sql);
            FeedStuff[] fsList = new FeedStuff[dataRowCollection.Count];
            for (int i = 0; i < fsList.Length; i++)
            {
                FeedStuff f = FeedStuff.Create(dataRowCollection[i]);
                fsList[i] = f;
            }
            return fsList;


        }

        public static string Serialize(FeedStuff feedStuff)
        {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FeedStuff));
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, feedStuff);
                return textWriter.ToString();
  
        }

        public static FeedStuff DeSerialize(string str)
        {

                StringReader reader = new StringReader(str);
                XmlSerializer serializer = new XmlSerializer(typeof(FeedStuff));
                FeedStuff obj = (FeedStuff)serializer.Deserialize(reader);
                return obj;
        }

        public static FeedStuff getFeedStuff(String name)
        {
                return FeedStuff.Create(Database.getRows("Select * From tableFeedStuff WHERE FeedStuff='" + name + "'")[0]);
        }

    }
}
