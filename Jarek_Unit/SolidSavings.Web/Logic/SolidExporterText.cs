namespace SolidSavings.Web.Logic
{
    using System.IO;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public class SolidExporterText : ISolidFileExporter
    {
        public Stream Export()
        {
            var ms = new MemoryStream();
            return ms;
        }

        public SolidExportType SupportedType => SolidExportType.Text;

        public bool CanExport(UserRegistrationType currentUserType)
        {
            return true;
        }

        public string GetApplicationType()
        {
            return "text";
        }
    }
}