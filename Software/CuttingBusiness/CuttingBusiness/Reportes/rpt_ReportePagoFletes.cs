using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CuttingBusiness
{
    public partial class rpt_ReportePagoFletes : DevExpress.XtraReports.UI.XtraReport
    {
        
        public rpt_ReportePagoFletes(string FechaInicio,string FechaFin,string Id_Categoria,string Nombre_Categoria)
        {
            InitializeComponent();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            queryParameter1.Name = "@FechaInicio";
            queryParameter1.Type = typeof(string);
            queryParameter1.ValueInfo = Convert.ToString(FechaInicio);
            queryParameter2.Name = "@FechaFin";
            queryParameter2.Type = typeof(string);
            queryParameter2.ValueInfo = Convert.ToString(FechaFin);
            queryParameter3.Name = "@Nombre_Categoria";
            queryParameter3.Type = typeof(string);
            queryParameter3.ValueInfo = Convert.ToString(Nombre_Categoria);
            sqlDataSource1.Queries[0].Parameters.Clear();
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter1);
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter2);
            sqlDataSource1.Queries[0].Parameters.Add(queryParameter3);
        }
    }
}
