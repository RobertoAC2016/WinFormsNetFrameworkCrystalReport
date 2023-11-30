using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsNetFrameworkCrystalRep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Aqui solo traigo los datos para mostrarlos
        public DataTable Data()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            foreach (var item in Products.GetItems())
            {
                dt.Rows.Add(item.Id, item.Name, item.Description);
            }
            return dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Aqui es donde se usaran los datos previamente traidos desde data para mostrarlos en el CRV
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"D:\RAC\NET\WinFormsNetFrameworkCrystalRep\crv1.rpt");
            rpt.SetDataSource(Data());
            crystalReportViewer1.ReportSource = rpt;
        }
    }
    //estos son datos de tus fuente de datos, ya sea el resultado de un querie o de tu datagridview, asi que aqui no importan
    //Solo los utilizo para mostrar datos en el Cristal Report
    public static class Products
    {
        public static List<Item> GetItems()
        {
            return new List<Item> {
                new Item
                {
                    Id = 1,
                    Name = "Pera",
                    Description = "Fruta dulce"
                },
                new Item
                {
                    Id = 2,
                    Name = "Cebolla",
                    Description = "Verdura"
                },
                new Item
                {
                    Id = 3,
                    Name = "Bistek",
                    Description = "Carne"
                },
            };
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
