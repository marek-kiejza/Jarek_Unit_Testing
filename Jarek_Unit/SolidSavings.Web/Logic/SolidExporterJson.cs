namespace SolidSavings.Web.Logic
{
    using System.IO;

    using Newtonsoft.Json;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public class SolidExporterJson : ISolidFileExporter
    {
        private IBusiness business;

        public SolidExporterJson(IBusiness business)
        {
            this.business = business;
        }

        public Stream Export()
        {
            var i = this.business.GetCurrentUserIncomes();
            var o = this.business.GetCurrentUserOutcomes();

            var m = new { Incomes = i, Outcomes = o };


            var ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms);
            JsonTextWriter jsonWriter = new JsonTextWriter(writer);
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(jsonWriter, m);
            jsonWriter.Flush();

            ms.Position = 0;
            return ms;
        }

        public SolidExportType SupportedType => SolidExportType.Json;

        public bool CanExport(UserRegistrationType currentUserType)
        {
            return true;
        }

        public string GetApplicationType()
        {
            return "application/json";
        }
    }
}