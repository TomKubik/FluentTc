﻿using System.Collections.Generic;
using FluentTc.Domain;
using FluentTc.Engine;
using FluentTc.Locators;
using JetBrains.TeamCity.ServiceMessages.Write;
using JetBrains.TeamCity.ServiceMessages.Write.Special;

namespace FluentTc
{
    public class LocalTc : ILocalTc
    {
        private readonly IBuildParameters m_BuildParameters;
        private readonly ITeamCityWriter m_TeamCityWriter;
        private readonly IList<IChangedFile> m_ChangedFiles;

        public LocalTc() : this(null)
        {
        }

        internal LocalTc(IBuildParameters buildParameters = null, ITeamCityWriterFactory teamCityWriterFactory = null, params object[] overrides)
        {
            var bootstrapper = new Bootstrapper(overrides);
            m_BuildParameters = buildParameters ?? bootstrapper.Get<IBuildParameters>();
            teamCityWriterFactory = teamCityWriterFactory ?? bootstrapper.Get<ITeamCityWriterFactory>();
            m_TeamCityWriter = teamCityWriterFactory.CreateTeamCityWriter();

            string changedFilesPath;
            if (m_BuildParameters.TryGetBuildParameter("build.changedFiles.file", out changedFilesPath))
            {
                m_ChangedFiles = bootstrapper.Get<IChangedFilesParser>().ParseChangedFiles(changedFilesPath);
            }
            else
            {
                m_ChangedFiles = new List<IChangedFile>();
            }
        }

        public void ChangeBuildStatus(BuildStatus buildStatus)
        {
            m_TeamCityWriter.WriteRawMessage(new ServiceMessage("buildStatus")
            {
                {"status", buildStatus.ToString().ToUpper()}
            });
        }

        public T GetBuildParameter<T>(string buildParameterName)
        {
            return m_BuildParameters.GetBuildParameter<T>(buildParameterName);
        }

        public bool TryGetBuildParameter(string parameterName, out string parameterValue)
        {
            return m_BuildParameters.TryGetBuildParameter(parameterName, out parameterValue);
        }

        public void SetBuildParameter(string buildParameterName, string buildParameterValue)
        {
            m_BuildParameters.SetBuildParameter(buildParameterName, buildParameterValue);
        }

        public string AgentHomeDir
        {
            get { return m_BuildParameters.AgentHomeDir; }
        }

        public string AgentName
        {
            get { return m_BuildParameters.AgentName; }
        }

        public string AgentOwnPort
        {
            get { return m_BuildParameters.AgentOwnPort; }
        }

        public string AgentWorkDir
        {
            get { return m_BuildParameters.AgentWorkDir; }
        }

        public long BuildNumber
        {
            get { return m_BuildParameters.BuildNumber; }
        }

        public int TeamcityAgentCpuBenchmark
        {
            get { return m_BuildParameters.TeamcityAgentCpuBenchmark; }
        }

        public string TeamcityBuildChangedFilesFile
        {
            get { return m_BuildParameters.TeamcityBuildChangedFilesFile; }
        }

        public string TeamcityBuildCheckoutDir
        {
            get { return m_BuildParameters.TeamcityBuildCheckoutDir; }
        }

        public long TeamcityBuildId
        {
            get { return m_BuildParameters.TeamcityBuildId; }
        }

        public string TeamcityBuildTempDir
        {
            get { return m_BuildParameters.TeamcityBuildTempDir; }
        }

        public string TeamcityBuildWorkingDir
        {
            get { return m_BuildParameters.TeamcityBuildWorkingDir; }
        }

        public string TeamcityBuildConfName
        {
            get { return m_BuildParameters.TeamcityBuildConfName; }
        }

        public string TeamcityBuildTypeId
        {
            get { return m_BuildParameters.TeamcityBuildTypeId; }
        }

        public string TeamcityProjectName
        {
            get { return m_BuildParameters.TeamcityProjectName; }
        }

        public string TeamCityVersion
        {
            get { return m_BuildParameters.TeamCityVersion; }
        }

        public IList<IChangedFile> ChangedFiles
        {
            get { return m_ChangedFiles; }
        }

        public bool IsTeamCityMode
        {
            get { return m_BuildParameters.IsTeamCityMode; }
        }

        public bool IsPersonal
        {
            get { return m_BuildParameters.IsPersonal; }
        }
    }
}