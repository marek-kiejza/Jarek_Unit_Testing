namespace SolidSavings.Web.Logic
{
    using System.IO;
    using System.Xml.Serialization;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public class SolidExporterXml : ISolidFileExporter
    {
        private IBusiness business;

        public SolidExporterXml(IBusiness business)
        {
            this.business = business;
        }

        public Stream Export()
        {
            var s = new MemoryStream();
            var xml = new XmlSerializer(typeof(ExportData));
            var i = this.business.GetCurrentUserIncomes();
            var o = this.business.GetCurrentUserOutcomes();

            var m = new ExportData { Incomes = i, Outcomes = o };
            xml.Serialize(s, m);
            s.Position = 0;
            return s;
        }

        public SolidExportType SupportedType => SolidExportType.Xml;

        public bool CanExport(UserRegistrationType currentUserType)
        {
            return true;
        }

        public string GetApplicationType()
        {
            return "application/xml";
        }
    }
}