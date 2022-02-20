namespace SolidSavings.Web.Logic
{
    using System.IO;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.Models.Enums;

    public interface ISolidFileExporter
    {
        Stream Export();

        SolidExportType SupportedType { get; }

        bool CanExport(UserRegistrationType currentUserType);

        string GetApplicationType();
    }
}