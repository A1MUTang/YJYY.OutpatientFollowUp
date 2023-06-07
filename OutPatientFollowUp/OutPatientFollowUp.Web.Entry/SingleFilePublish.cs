using Furion;
using System.Reflection;

namespace OutPatientFollowUp.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "OutPatientFollowUp.Application",
            "OutPatientFollowUp.Core",
            "OutPatientFollowUp.Web.Core"
        };
    }
}