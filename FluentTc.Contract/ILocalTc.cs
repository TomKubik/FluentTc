using FluentTc.Domain;
using FluentTc.Locators;
using System.Collections.Generic;

namespace FluentTc
{
    public interface ILocalTc
    {
        void ChangeBuildStatus(BuildStatus buildStatus);
        T GetBuildParameter<T>(string parameterName);
        bool TryGetBuildParameter(string parameterName, out string parameterValue);
        string AgentHomeDir { get; }
        string AgentName { get; }
        string AgentOwnPort { get; }
        string AgentWorkDir { get; }
        long BuildNumber { get; }
        int TeamcityAgentCpuBenchmark { get; }
        string TeamcityBuildChangedFilesFile { get; }
        string TeamcityBuildCheckoutDir { get; }
        long TeamcityBuildId { get; }
        string TeamcityBuildTempDir { get; }
        string TeamcityBuildWorkingDir { get; }
        string TeamcityBuildConfName { get; }
        string TeamcityBuildTypeId { get; }
        string TeamcityProjectName { get; }
        string TeamCityVersion { get; }
        IList<IChangedFile> ChangedFiles { get; }
        bool IsTeamCityMode { get; }
        bool IsPersonal { get; }
        void SetBuildParameter(string parameterName, string parameterValue);
    }
}
