namespace SolidSavings.Web.Logic
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public class SolidExporter : ISolidExporter
    {
        private readonly IEnumerable<ISolidFileExporter> exporters;

        public SolidExporter(IEnumerable<ISolidFileExporter> exporters)
        {
            this.exporters = exporters;
        }

        public Stream Export(SolidExportType exportType)
        {
            var exporter = this.exporters.Single(e => e.SupportedType == exportType);
            return exporter.Export();
        }

        public bool CanExport(SolidExportType exportType, UserRegistrationType currentUserType)
        {
            return this.exporters.Single(e => e.SupportedType == exportType).CanExport(currentUserType);
        }

        public string GetApplicationType(SolidExportType exportType)
        {
            return this.exporters.Single(e => e.SupportedType == exportType).GetApplicationType();
        }
    }
}