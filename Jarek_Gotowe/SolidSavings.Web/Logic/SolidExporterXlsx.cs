namespace SolidSavings.Web.Logic
{
    using System.Data;
    using System.IO;

    using ClosedXML.Excel;

    using Newtonsoft.Json;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public class SolidExporterXlsx : ISolidFileExporter
    {
        private IBusiness business;

        public SolidExporterXlsx(IBusiness business)
        {
            this.business = business;
        }

        public Stream Export()
        {
            var i = this.business.GetCurrentUserIncomes();
            var o = this.business.GetCurrentUserOutcomes();

            var istr = JsonConvert.SerializeObject(i);
            var ostr = JsonConvert.SerializeObject(o);

            var idt = (DataTable)JsonConvert.DeserializeObject(istr, typeof(DataTable));
            var odt = (DataTable)JsonConvert.DeserializeObject(ostr, typeof(DataTable));

            var xlsx = new XLWorkbook();
            xlsx.Worksheets.Add(idt, "przychody");
            xlsx.Worksheets.Add(odt, "wydatki");

            var ms = new MemoryStream();
            xlsx.SaveAs(ms);
            ms.Position = 0;

            return ms;
        }

        public SolidExportType SupportedType => SolidExportType.Xlsx;

        public bool CanExport(UserRegistrationType currentUserType)
        {
            return currentUserType == UserRegistrationType.Paid;
        }

        public string GetApplicationType()
        {
            return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }
    }
}