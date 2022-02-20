namespace SolidSavings.Web.Logic
{
    using System.IO;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public interface ISolidExporter
    {
        Stream Export(SolidExportType exportType);

        bool CanExport(SolidExportType exportType, UserRegistrationType currentUserType);

        string GetApplicationType(SolidExportType exportType);
    }
}