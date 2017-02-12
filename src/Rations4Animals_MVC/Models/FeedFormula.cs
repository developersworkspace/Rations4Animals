using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;


namespace Rations4Animals_MVC.Models
{
    public class FeedFormula
    {
        public string FormulaName { get; set; }
        public double DM_Min { get; set; }
        public double DM_Max { get; set; }
        public double CP_Min { get; set; }
        public double CP_Max { get; set; }
        public double RUP_Min { get; set; }
        public double RUP_Max { get; set; }
        public double CF_Min { get; set; }
        public double CF_Max { get; set; }
        public double EE_Min { get; set; }
        public double EE_Max { get; set; }
        public double ADF_Min { get; set; }
        public double ADF_Max { get; set; }
        public double NDF_Min { get; set; }
        public double NDF_Max { get; set; }
        public double eNDF_Min { get; set; }
        public double eNDF_Max { get; set; }
        public double TDNCattle_Min { get; set; }
        public double TDNCattle_Max { get; set; }
        public double TDNSheep_Min { get; set; }
        public double TDNSheep_Max { get; set; }
        public double DESheep_Min { get; set; }
        public double DESheep_Max { get; set; }
        public double MECattle_Min { get; set; }
        public double MECattle_Max { get; set; }
        public double MESheep_Min { get; set; }
        public double MESheep_Max { get; set; }
        public double NEmCattle_Min { get; set; }
        public double NEmCattle_Max { get; set; }
        public double NEgCattle_Min { get; set; }
        public double NEgCattle_Max { get; set; }
        public double NElCattle_Min { get; set; }
        public double NElCattle_Max { get; set; }
        public double MEPoultry_Min { get; set; }
        public double MEPoultry_Max { get; set; }
        public double DEHorse_Min { get; set; }
        public double DEHorse_Max { get; set; }
        public double DEPig_Min { get; set; }
        public double DEPig_Max { get; set; }
        public double MEPig_Min { get; set; }
        public double MEPig_Max { get; set; }
        public double Arg_Min { get; set; }
        public double Arg_Max { get; set; }
        public double His_Min { get; set; }
        public double His_Max { get; set; }
        public double Iso_L_Min { get; set; }
        public double Iso_L_Max { get; set; }
        public double Leu_Min { get; set; }
        public double Leu_Max { get; set; }
        public double Lys_Min { get; set; }
        public double Lys_Max { get; set; }
        public double Met_Min { get; set; }
        public double Met_Max { get; set; }
        public double Cys_Min { get; set; }
        public double Cys_Max { get; set; }
        public double Phe_Min { get; set; }
        public double Phe_Max { get; set; }
        public double Tyr_Min { get; set; }
        public double Tyr_Max { get; set; }
        public double Thr_Min { get; set; }
        public double Thr_Max { get; set; }
        public double Trp_Min { get; set; }
        public double Trp_Max { get; set; }
        public double Val_Min { get; set; }
        public double Val_Max { get; set; }
        public double Gly_Min { get; set; }
        public double Gly_Max { get; set; }
        public double Ser_Min { get; set; }
        public double Ser_Max { get; set; }
        public double Ca_Min { get; set; }
        public double Ca_Max { get; set; }
        public double Cl_Min { get; set; }
        public double Cl_Max { get; set; }
        public double Mg_Min { get; set; }
        public double Mg_Max { get; set; }
        public double P_Min { get; set; }
        public double P_Max { get; set; }
        public double K_Min { get; set; }
        public double K_Max { get; set; }
        public double Na_Min { get; set; }
        public double Na_Max { get; set; }
        public double S_Min { get; set; }
        public double S_Max { get; set; }
        public double Co_Min { get; set; }
        public double Co_Max { get; set; }
        public double Cu_Min { get; set; }
        public double Cu_Max { get; set; }
        public double I_Min { get; set; }
        public double I_Max { get; set; }
        public double Fe_Min { get; set; }
        public double Fe_Max { get; set; }
        public double Mn_Min { get; set; }
        public double Mn_Max { get; set; }
        public double Se_Min { get; set; }
        public double Se_Max { get; set; }
        public double Zn_Min { get; set; }
        public double Zn_Max { get; set; }
        public double VitA_Min { get; set; }
        public double VitA_Max { get; set; }
        public double VitD_Min { get; set; }
        public double VitD_Max { get; set; }
        public double VitE_Min { get; set; }
        public double VitE_Max { get; set; }
        public double VitK_Min { get; set; }
        public double VitK_Max { get; set; }
        public double Biotin_Min { get; set; }
        public double Biotin_Max { get; set; }
        public double Choline_Min { get; set; }
        public double Choline_Max { get; set; }
        public double Folic_Min { get; set; }
        public double Folic_Max { get; set; }
        public double Niacin_Min { get; set; }
        public double Niacin_Max { get; set; }
        public double Pantot_Min { get; set; }
        public double Pantot_Max { get; set; }
        public double VitB2_Min { get; set; }
        public double VitB2_Max { get; set; }
        public double VitB1_Min { get; set; }
        public double VitB1_Max { get; set; }
        public double VitB6_Min { get; set; }
        public double VitB6_Max { get; set; }
        public double VitB12_Min { get; set; }
        public double VitB12_Max { get; set; }
        public string Category { get; set; }
        public int ID { get; set; }

        public object getValue(String name)
        {
            try
            {
                PropertyInfo pi = typeof(FeedFormula).GetProperty(name);
                object o = (object)pi.GetValue(this, null);
                return o;
            }
            catch (Exception e)
            {
                throw new Exception("Property could not be found.", e);
            }
        }

        public static List<FeedFormula> Create(DataRowCollection dataRowCollection)
        {
            List<FeedFormula> list = new List<FeedFormula>();
            foreach (DataRow dataRow in dataRowCollection)
            {
                FeedFormula ff = new FeedFormula();
                ff.FormulaName = dataRow.Field<string>("FormulaName");
                ff.DM_Min = dataRow.Field<double>("DM_Min");
                ff.DM_Max = dataRow.Field<double>("DM_Max");
                ff.CP_Min = dataRow.Field<double>("CP_Min");
                ff.CP_Max = dataRow.Field<double>("CP_Max");
                ff.RUP_Min = dataRow.Field<double>("RUP_Min");
                ff.RUP_Max = dataRow.Field<double>("RUP_Max");
                ff.CF_Min = dataRow.Field<double>("CF_Min");
                ff.CF_Max = dataRow.Field<double>("CF_Max");
                ff.EE_Min = dataRow.Field<double>("EE_Min");
                ff.EE_Max = dataRow.Field<double>("EE_Max");
                ff.ADF_Min = dataRow.Field<double>("ADF_Min");
                ff.ADF_Max = dataRow.Field<double>("ADF_Max");
                ff.NDF_Min = dataRow.Field<double>("NDF_Min");
                ff.NDF_Max = dataRow.Field<double>("NDF_Max");
                ff.eNDF_Min = dataRow.Field<double>("eNDF_Min");
                ff.eNDF_Max = dataRow.Field<double>("eNDF_Max");
                ff.TDNCattle_Min = dataRow.Field<double>("TDNCattle_Min");
                ff.TDNCattle_Max = dataRow.Field<double>("TDNCattle_Max");
                ff.TDNSheep_Min = dataRow.Field<double>("TDNSheep_Min");
                ff.TDNSheep_Max = dataRow.Field<double>("TDNSheep_Max");
                ff.DESheep_Min = dataRow.Field<double>("DESheep_Min");
                ff.DESheep_Max = dataRow.Field<double>("DESheep_Max");
                ff.MECattle_Min = dataRow.Field<double>("MECattle_Min");
                ff.MECattle_Max = dataRow.Field<double>("MECattle_Max");
                ff.MESheep_Min = dataRow.Field<double>("MESheep_Min");
                ff.MESheep_Max = dataRow.Field<double>("MESheep_Max");
                ff.NEmCattle_Min = dataRow.Field<double>("NEmCattle_Min");
                ff.NEmCattle_Max = dataRow.Field<double>("NEmCattle_Max");
                ff.NEgCattle_Min = dataRow.Field<double>("NEgCattle_Min");
                ff.NEgCattle_Max = dataRow.Field<double>("NEgCattle_Max");
                ff.NElCattle_Min = dataRow.Field<double>("NElCattle_Min");
                ff.NElCattle_Max = dataRow.Field<double>("NElCattle_Max");
                ff.MEPoultry_Min = dataRow.Field<double>("MEPoultry_Min");
                ff.MEPoultry_Max = dataRow.Field<double>("MEPoultry_Max");
                ff.DEHorse_Min = dataRow.Field<double>("DEHorse_Min");
                ff.DEHorse_Max = dataRow.Field<double>("DEHorse_Max");
                ff.DEPig_Min = dataRow.Field<double>("DEPig_Min");
                ff.DEPig_Max = dataRow.Field<double>("DEPig_Max");
                ff.MEPig_Min = dataRow.Field<double>("MEPig_Min");
                ff.MEPig_Max = dataRow.Field<double>("MEPig_Max");
                ff.Arg_Min = dataRow.Field<double>("Arg_Min");
                ff.Arg_Max = dataRow.Field<double>("Arg_Max");
                ff.His_Min = dataRow.Field<double>("His_Min");
                ff.His_Max = dataRow.Field<double>("His_Max");
                ff.Iso_L_Min = dataRow.Field<double>("Iso_L_Min");
                ff.Iso_L_Max = dataRow.Field<double>("Iso_L_Max");
                ff.Leu_Min = dataRow.Field<double>("Leu_Min");
                ff.Leu_Max = dataRow.Field<double>("Leu_Max");
                ff.Lys_Min = dataRow.Field<double>("Lys_Min");
                ff.Lys_Max = dataRow.Field<double>("Lys_Max");
                ff.Met_Min = dataRow.Field<double>("Met_Min");
                ff.Met_Max = dataRow.Field<double>("Met_Max");
                ff.Cys_Min = dataRow.Field<double>("Cys_Min");
                ff.Cys_Max = dataRow.Field<double>("Cys_Max");
                ff.Phe_Min = dataRow.Field<double>("Phe_Min");
                ff.Phe_Max = dataRow.Field<double>("Phe_Max");
                ff.Tyr_Min = dataRow.Field<double>("Tyr_Min");
                ff.Tyr_Max = dataRow.Field<double>("Tyr_Max");
                ff.Thr_Min = dataRow.Field<double>("Thr_Min");
                ff.Thr_Max = dataRow.Field<double>("Thr_Max");
                ff.Trp_Min = dataRow.Field<double>("Trp_Min");
                ff.Trp_Max = dataRow.Field<double>("Trp_Max");
                ff.Val_Min = dataRow.Field<double>("Val_Min");
                ff.Val_Max = dataRow.Field<double>("Val_Max");
                ff.Gly_Min = dataRow.Field<double>("Gly_Min");
                ff.Gly_Max = dataRow.Field<double>("Gly_Max");
                ff.Ser_Min = dataRow.Field<double>("Ser_Min");
                ff.Ser_Max = dataRow.Field<double>("Ser_Max");
                ff.Ca_Min = dataRow.Field<double>("Ca_Min");
                ff.Ca_Max = dataRow.Field<double>("Ca_Max");
                ff.Cl_Min = dataRow.Field<double>("Cl_Min");
                ff.Cl_Max = dataRow.Field<double>("Cl_Max");
                ff.Mg_Min = dataRow.Field<double>("Mg_Min");
                ff.Mg_Max = dataRow.Field<double>("Mg_Max");
                ff.P_Min = dataRow.Field<double>("P_Min");
                ff.P_Max = dataRow.Field<double>("P_Max");
                ff.K_Min = dataRow.Field<double>("K_Min");
                ff.K_Max = dataRow.Field<double>("K_Max");
                ff.Na_Min = dataRow.Field<double>("Na_Min");
                ff.Na_Max = dataRow.Field<double>("Na_Max");
                ff.S_Min = dataRow.Field<double>("S_Min");
                ff.S_Max = dataRow.Field<double>("S_Max");
                ff.Co_Min = dataRow.Field<double>("Co_Min");
                ff.Co_Max = dataRow.Field<double>("Co_Max");
                ff.Cu_Min = dataRow.Field<double>("Cu_Min");
                ff.Cu_Max = dataRow.Field<double>("Cu_Max");
                ff.I_Min = dataRow.Field<double>("I_Min");
                ff.I_Max = dataRow.Field<double>("I_Max");
                ff.Fe_Min = dataRow.Field<double>("Fe_Min");
                ff.Fe_Max = dataRow.Field<double>("Fe_Max");
                ff.Mn_Min = dataRow.Field<double>("Mn_Min");
                ff.Mn_Max = dataRow.Field<double>("Mn_Max");
                ff.Se_Min = dataRow.Field<double>("Se_Min");
                ff.Se_Max = dataRow.Field<double>("Se_Max");
                ff.Zn_Min = dataRow.Field<double>("Zn_Min");
                ff.Zn_Max = dataRow.Field<double>("Zn_Max");
                ff.VitA_Min = dataRow.Field<double>("VitA_Min");
                ff.VitA_Max = dataRow.Field<double>("VitA_Max");
                ff.VitD_Min = dataRow.Field<double>("VitD_Min");
                ff.VitD_Max = dataRow.Field<double>("VitD_Max");
                ff.VitE_Min = dataRow.Field<double>("VitE_Min");
                ff.VitE_Max = dataRow.Field<double>("VitE_Max");
                ff.VitK_Min = dataRow.Field<double>("VitK_Min");
                ff.VitK_Max = dataRow.Field<double>("VitK_Max");
                ff.Biotin_Min = dataRow.Field<double>("Biotin_Min");
                ff.Biotin_Max = dataRow.Field<double>("Biotin_Max");
                ff.Choline_Min = dataRow.Field<double>("Choline_Min");
                ff.Choline_Max = dataRow.Field<double>("Choline_Max");
                ff.Folic_Min = dataRow.Field<double>("Folic_Min");
                ff.Folic_Max = dataRow.Field<double>("Folic_Max");
                ff.Niacin_Min = dataRow.Field<double>("Niacin_Min");
                ff.Niacin_Max = dataRow.Field<double>("Niacin_Max");
                ff.Pantot_Min = dataRow.Field<double>("Pantot_Min");
                ff.Pantot_Max = dataRow.Field<double>("Pantot_Max");
                ff.VitB2_Min = dataRow.Field<double>("VitB2_Min");
                ff.VitB2_Max = dataRow.Field<double>("VitB2_Max");
                ff.VitB1_Min = dataRow.Field<double>("VitB1_Min");
                ff.VitB1_Max = dataRow.Field<double>("VitB1_Max");
                ff.VitB6_Min = dataRow.Field<double>("VitB6_Min");
                ff.VitB6_Max = dataRow.Field<double>("VitB6_Max");
                ff.VitB12_Min = dataRow.Field<double>("VitB12_Min");
                ff.VitB12_Max = dataRow.Field<double>("VitB12_Max");
                ff.Category = dataRow.Field<string>("Category");
                ff.ID = dataRow.Field<int>("ID");
                list.Add(ff);
            }


                return list;
            
        }

        public static FeedFormula Create(DataRow dataRow)
        {
        
                FeedFormula ff = new FeedFormula();
                ff.FormulaName = dataRow.Field<string>("FormulaName");
                ff.DM_Min = dataRow.Field<double>("DM_Min");
                ff.DM_Max = dataRow.Field<double>("DM_Max");
                ff.CP_Min = dataRow.Field<double>("CP_Min");
                ff.CP_Max = dataRow.Field<double>("CP_Max");
                ff.RUP_Min = dataRow.Field<double>("RUP_Min");
                ff.RUP_Max = dataRow.Field<double>("RUP_Max");
                ff.CF_Min = dataRow.Field<double>("CF_Min");
                ff.CF_Max = dataRow.Field<double>("CF_Max");
                ff.EE_Min = dataRow.Field<double>("EE_Min");
                ff.EE_Max = dataRow.Field<double>("EE_Max");
                ff.ADF_Min = dataRow.Field<double>("ADF_Min");
                ff.ADF_Max = dataRow.Field<double>("ADF_Max");
                ff.NDF_Min = dataRow.Field<double>("NDF_Min");
                ff.NDF_Max = dataRow.Field<double>("NDF_Max");
                ff.eNDF_Min = dataRow.Field<double>("eNDF_Min");
                ff.eNDF_Max = dataRow.Field<double>("eNDF_Max");
                ff.TDNCattle_Min = dataRow.Field<double>("TDNCattle_Min");
                ff.TDNCattle_Max = dataRow.Field<double>("TDNCattle_Max");
                ff.TDNSheep_Min = dataRow.Field<double>("TDNSheep_Min");
                ff.TDNSheep_Max = dataRow.Field<double>("TDNSheep_Max");
                ff.DESheep_Min = dataRow.Field<double>("DESheep_Min");
                ff.DESheep_Max = dataRow.Field<double>("DESheep_Max");
                ff.MECattle_Min = dataRow.Field<double>("MECattle_Min");
                ff.MECattle_Max = dataRow.Field<double>("MECattle_Max");
                ff.MESheep_Min = dataRow.Field<double>("MESheep_Min");
                ff.MESheep_Max = dataRow.Field<double>("MESheep_Max");
                ff.NEmCattle_Min = dataRow.Field<double>("NEmCattle_Min");
                ff.NEmCattle_Max = dataRow.Field<double>("NEmCattle_Max");
                ff.NEgCattle_Min = dataRow.Field<double>("NEgCattle_Min");
                ff.NEgCattle_Max = dataRow.Field<double>("NEgCattle_Max");
                ff.NElCattle_Min = dataRow.Field<double>("NElCattle_Min");
                ff.NElCattle_Max = dataRow.Field<double>("NElCattle_Max");
                ff.MEPoultry_Min = dataRow.Field<double>("MEPoultry_Min");
                ff.MEPoultry_Max = dataRow.Field<double>("MEPoultry_Max");
                ff.DEHorse_Min = dataRow.Field<double>("DEHorse_Min");
                ff.DEHorse_Max = dataRow.Field<double>("DEHorse_Max");
                ff.DEPig_Min = dataRow.Field<double>("DEPig_Min");
                ff.DEPig_Max = dataRow.Field<double>("DEPig_Max");
                ff.MEPig_Min = dataRow.Field<double>("MEPig_Min");
                ff.MEPig_Max = dataRow.Field<double>("MEPig_Max");
                ff.Arg_Min = dataRow.Field<double>("Arg_Min");
                ff.Arg_Max = dataRow.Field<double>("Arg_Max");
                ff.His_Min = dataRow.Field<double>("His_Min");
                ff.His_Max = dataRow.Field<double>("His_Max");
                ff.Iso_L_Min = dataRow.Field<double>("Iso_L_Min");
                ff.Iso_L_Max = dataRow.Field<double>("Iso_L_Max");
                ff.Leu_Min = dataRow.Field<double>("Leu_Min");
                ff.Leu_Max = dataRow.Field<double>("Leu_Max");
                ff.Lys_Min = dataRow.Field<double>("Lys_Min");
                ff.Lys_Max = dataRow.Field<double>("Lys_Max");
                ff.Met_Min = dataRow.Field<double>("Met_Min");
                ff.Met_Max = dataRow.Field<double>("Met_Max");
                ff.Cys_Min = dataRow.Field<double>("Cys_Min");
                ff.Cys_Max = dataRow.Field<double>("Cys_Max");
                ff.Phe_Min = dataRow.Field<double>("Phe_Min");
                ff.Phe_Max = dataRow.Field<double>("Phe_Max");
                ff.Tyr_Min = dataRow.Field<double>("Tyr_Min");
                ff.Tyr_Max = dataRow.Field<double>("Tyr_Max");
                ff.Thr_Min = dataRow.Field<double>("Thr_Min");
                ff.Thr_Max = dataRow.Field<double>("Thr_Max");
                ff.Trp_Min = dataRow.Field<double>("Trp_Min");
                ff.Trp_Max = dataRow.Field<double>("Trp_Max");
                ff.Val_Min = dataRow.Field<double>("Val_Min");
                ff.Val_Max = dataRow.Field<double>("Val_Max");
                ff.Gly_Min = dataRow.Field<double>("Gly_Min");
                ff.Gly_Max = dataRow.Field<double>("Gly_Max");
                ff.Ser_Min = dataRow.Field<double>("Ser_Min");
                ff.Ser_Max = dataRow.Field<double>("Ser_Max");
                ff.Ca_Min = dataRow.Field<double>("Ca_Min");
                ff.Ca_Max = dataRow.Field<double>("Ca_Max");
                ff.Cl_Min = dataRow.Field<double>("Cl_Min");
                ff.Cl_Max = dataRow.Field<double>("Cl_Max");
                ff.Mg_Min = dataRow.Field<double>("Mg_Min");
                ff.Mg_Max = dataRow.Field<double>("Mg_Max");
                ff.P_Min = dataRow.Field<double>("P_Min");
                ff.P_Max = dataRow.Field<double>("P_Max");
                ff.K_Min = dataRow.Field<double>("K_Min");
                ff.K_Max = dataRow.Field<double>("K_Max");
                ff.Na_Min = dataRow.Field<double>("Na_Min");
                ff.Na_Max = dataRow.Field<double>("Na_Max");
                ff.S_Min = dataRow.Field<double>("S_Min");
                ff.S_Max = dataRow.Field<double>("S_Max");
                ff.Co_Min = dataRow.Field<double>("Co_Min");
                ff.Co_Max = dataRow.Field<double>("Co_Max");
                ff.Cu_Min = dataRow.Field<double>("Cu_Min");
                ff.Cu_Max = dataRow.Field<double>("Cu_Max");
                ff.I_Min = dataRow.Field<double>("I_Min");
                ff.I_Max = dataRow.Field<double>("I_Max");
                ff.Fe_Min = dataRow.Field<double>("Fe_Min");
                ff.Fe_Max = dataRow.Field<double>("Fe_Max");
                ff.Mn_Min = dataRow.Field<double>("Mn_Min");
                ff.Mn_Max = dataRow.Field<double>("Mn_Max");
                ff.Se_Min = dataRow.Field<double>("Se_Min");
                ff.Se_Max = dataRow.Field<double>("Se_Max");
                ff.Zn_Min = dataRow.Field<double>("Zn_Min");
                ff.Zn_Max = dataRow.Field<double>("Zn_Max");
                ff.VitA_Min = dataRow.Field<double>("VitA_Min");
                ff.VitA_Max = dataRow.Field<double>("VitA_Max");
                ff.VitD_Min = dataRow.Field<double>("VitD_Min");
                ff.VitD_Max = dataRow.Field<double>("VitD_Max");
                ff.VitE_Min = dataRow.Field<double>("VitE_Min");
                ff.VitE_Max = dataRow.Field<double>("VitE_Max");
                ff.VitK_Min = dataRow.Field<double>("VitK_Min");
                ff.VitK_Max = dataRow.Field<double>("VitK_Max");
                ff.Biotin_Min = dataRow.Field<double>("Biotin_Min");
                ff.Biotin_Max = dataRow.Field<double>("Biotin_Max");
                ff.Choline_Min = dataRow.Field<double>("Choline_Min");
                ff.Choline_Max = dataRow.Field<double>("Choline_Max");
                ff.Folic_Min = dataRow.Field<double>("Folic_Min");
                ff.Folic_Max = dataRow.Field<double>("Folic_Max");
                ff.Niacin_Min = dataRow.Field<double>("Niacin_Min");
                ff.Niacin_Max = dataRow.Field<double>("Niacin_Max");
                ff.Pantot_Min = dataRow.Field<double>("Pantot_Min");
                ff.Pantot_Max = dataRow.Field<double>("Pantot_Max");
                ff.VitB2_Min = dataRow.Field<double>("VitB2_Min");
                ff.VitB2_Max = dataRow.Field<double>("VitB2_Max");
                ff.VitB1_Min = dataRow.Field<double>("VitB1_Min");
                ff.VitB1_Max = dataRow.Field<double>("VitB1_Max");
                ff.VitB6_Min = dataRow.Field<double>("VitB6_Min");
                ff.VitB6_Max = dataRow.Field<double>("VitB6_Max");
                ff.VitB12_Min = dataRow.Field<double>("VitB12_Min");
                ff.VitB12_Max = dataRow.Field<double>("VitB12_Max");
                ff.Category = dataRow.Field<string>("Category");
                ff.ID = dataRow.Field<int>("ID");
                return ff;

           
        }

        public static FeedFormula getFeedFormula(int index)
        {

            return FeedFormula.Create(Database.getRows(string.Format("Select * From tableFeedFormula WHERE ID={0}",index))[0]);
            

        }

        public static FeedFormula[] getFeedFormula()
        {

            DataRowCollection dataRowCollection = Database.getRows("Select * From tableFeedFormula ORDER BY ID ASC");
                FeedFormula[] fList = new FeedFormula[dataRowCollection.Count];
                for (int i = 0; i < fList.Length; i++)
                {
                    FeedFormula f = FeedFormula.Create(dataRowCollection[i]);
                    fList[i] = f;
                }

                return fList;
           
        }

        public static FeedFormula getFeedFormula(String name)
        {
          
                return FeedFormula.Create(Database.getRows("Select * From tableFeedFormula WHERE FormulaName='" + name + "'")[0]);
          
        }

        public static string Serialize(FeedFormula feedFormula)
        {
          
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FeedFormula));
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, feedFormula);
                return textWriter.ToString();
          
        }

        public static FeedFormula DeSerialize(string str)
        {
           
                StringReader reader = new StringReader(str);
                XmlSerializer serializer = new XmlSerializer(typeof(FeedFormula));
                FeedFormula obj = (FeedFormula)serializer.Deserialize(reader);
                return obj;
         
        }



    }
}
