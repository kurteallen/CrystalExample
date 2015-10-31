using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;

namespace CrystalReportExample
{
    public partial class Form1 : Form
    {
        private const string PARAMETER_FIELD_NAME = "Country";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureCrystalReports();
            
            
            
            ConnectionInfo connectionInfo = new ConnectionInfo();
            SetDBLogonForReport(connectionInfo);
            connectionInfo.DatabaseName = "connex";
            connectionInfo.UserID = "subroot";
            connectionInfo.Password = "12CCts#$";
        }

        private void ConfigureCrystalReports()
        {
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("Canada");
            //arrayList.Add("United States");

            string reportPath = Application.StartupPath + "\\" + "CrystalExample.rpt";
            //string reportPath = "C:\\Users\\sunpack\\Documents\\Visual Studio 2013\\Projects\\CrystalReportExample\\CrystalReportExample\\CrystalExample.rpt";
            crystalReportViewer.ReportSource = reportPath;
            //ParameterFields parameterFields = crystalReportViewer.ParameterFieldInfo;
           // defaultParameterValuesList.DataSource = GetDefaultValuesFromParameterField(parameterFields);
            //SetCurrentValuesForParameterField(parameterFields, arrayList);
           

        }

        private void SetDBLogonForReport(ConnectionInfo connectionInfo)
        {
            TableLogOnInfos tableLogOnInfos = crystalReportViewer.LogOnInfo;
            foreach (TableLogOnInfo tableLogOnInfo in tableLogOnInfos)
            {
                tableLogOnInfo.ConnectionInfo = connectionInfo;
            }
        }

        private ArrayList GetDefaultValuesFromParameterField(ParameterFields parameterFields)
        {
            ParameterField parameterField = parameterFields[PARAMETER_FIELD_NAME];
            ParameterValues defaultParameterValues = parameterField.DefaultValues;
            ArrayList arrayList = new ArrayList();
            foreach (ParameterValue parameterValue in defaultParameterValues)
            {
                if (!parameterValue.IsRange)
                {
                    ParameterDiscreteValue parameterDiscreteValue = (ParameterDiscreteValue)parameterValue;
                    arrayList.Add(parameterDiscreteValue.Value.ToString());
                }
            }

            return arrayList;
        }

        private void SetCurrentValuesForParameterField(ParameterFields parameterFields, ArrayList arrayList)
        {
            ParameterValues currentParameterValues = new ParameterValues();
            foreach (object submittedValue in arrayList)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = submittedValue.ToString();
                currentParameterValues.Add(parameterDiscreteValue);
            }
            ParameterField parameterField = parameterFields[PARAMETER_FIELD_NAME];
            parameterField.CurrentValues = currentParameterValues;
        }

    }
}
