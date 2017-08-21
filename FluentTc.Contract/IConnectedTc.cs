using FluentTc.Domain;
using FluentTc.Engine;
using FluentTc.Locators;
using System;
using System.Collections.Generic;

namespace FluentTc
{
    public interface IConnectedTc
    {
        /// <summary>
        /// Retrieves builds matching the criteria
        /// </summary>
        /// <param name="having">Criteria to retrieve builds</param>
        /// <returns>Builds matching the criteria</returns>
        IList<IBuild> GetBuilds(Action<IBuildHavingBuilder> having);

        /// <summary>
        /// Retrieves builds matching the criteria
        /// </summary>
        /// <param name="having">Criteria to retrieve builds</param>
        /// <param name="include">Specifies which additional properties to retrieve</param>
        /// <returns>Builds matching the criteria</returns>
        IList<IBuild> GetBuilds(Action<IBuildHavingBuilder> having, Action<IBuildIncludeBuilder> include);

        /// <summary>
        /// Retrieves builds matching the criteria
        /// </summary>
        /// <param name="having">Criteria to retrieve builds</param>
        /// <param name="include">Specifies which additional properties to retrieve</param>
        /// <param name="count">Allow retrieving specific amount of results with paging</param>
        /// <returns>Builds matching the criteria</returns>
        IList<IBuild> GetBuilds(Action<IBuildHavingBuilder> having, Action<IBuildIncludeBuilder> include, Action<ICountBuilder> count);

        /// <summary>
        ///     Retrieves a build according to specified having parameter with specified columns
        /// </summary>
        /// <exception cref="FluentTc.Exceptions.BuildNotFoundException">Thrown when build not found by the specified criteria</exception>
        /// <exception cref="FluentTc.Exceptions.MoreThanOneBuildFoundException">
        ///     Thrown when more than one build found by the
        ///     specified criteria
        /// </exception>
        /// <param name="having">Retrieve build that matches the criteria</param>
        /// <param name="include">Include these columns in retrieved build</param>
        /// <returns>IBuild</returns>
        IBuild GetBuild(Action<IBuildHavingBuilder> having, Action<IBuildIncludeBuilder> include);

        /// <summary>
        ///     Retrieves a build according to specified having parameter with specified columns
        /// </summary>
        /// <exception cref="FluentTc.Exceptions.BuildNotFoundException">Thrown when build not found by the specified criteria</exception>
        /// <exception cref="FluentTc.Exceptions.MoreThanOneBuildFoundException">
        ///     Thrown when more than one build found by the
        ///     specified criteria
        /// </exception>
        /// <param name="having">Retrieve build that matches the criteria</param>
        /// <returns>IBuild</returns>
        IBuild GetBuild(Action<IBuildHavingBuilder> having);

        /// <summary>
        ///     Retrieves the last build that matches having parameter with all the data.
        /// </summary>
        /// <exception cref="FluentTc.Exceptions.BuildNotFoundException">Thrown when build not found by the specified criteria</exception>
        /// <exception cref="FluentTc.Exceptions.MoreThanOneBuildFoundException">
        ///     Thrown when more than one build found by the
        ///     specified criteria
        /// </exception>
        /// <param name="having">Retrieve build that matches the criteria</param>
        /// <returns>IBuild</returns>
        IBuild GetLastBuild(Action<IBuildHavingBuilder> having);

        List<Agent> GetAgents(Action<IAgentHavingBuilder> having);

        /// <summary>
        ///     Retrieves the last build that matches having parameter with all the data.
        /// </summary>
        /// <exception cref="FluentTc.Exceptions.BuildNotFoundException">Thrown when build not found by the specified criteria</exception>
        /// <exception cref="FluentTc.Exceptions.MoreThanOneBuildFoundException">
        ///     Thrown when more than one build found by the
        ///     specified criteria
        /// </exception>
        /// <param name="having">Retrieve build that matches the criteria</param>
        /// <param name="include">Include additional data, such as Changes</param>
        /// <returns>IBuild</returns>
        IBuild GetLastBuild(Action<IBuildHavingBuilder> having, Action<IBuildAdditionalIncludeBuilder> include);

        IBuild GetBuild(long buildId);

        BuildConfiguration GetBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having);
        IList<BuildConfiguration> GetBuildConfigurations(Action<IBuildConfigurationHavingBuilder> having);

        void SetBuildConfigurationParameters(Action<IBuildConfigurationHavingBuilder> having,
            Action<IBuildParameterValueBuilder> parameters);
        void SetBuildConfigurationField(Action<IBuildConfigurationHavingBuilder> having,
            Action<IBuildFieldValueBuilder> parameters);

        void SetProjectConfigurationField(Action<IBuildProjectHavingBuilder> having,
            Action<IBuildProjectFieldValueBuilder> fields);

        void SetProjectParameters(Action<IBuildProjectHavingBuilder> having, Action<IBuildParameterValueBuilder> parameters);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having,
            Action<IBuildParameterValueBuilder> parameters);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having, Action<IAgentHavingBuilder> onAgent);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having, Action<IAgentHavingBuilder> onAgent,
            Action<IBuildParameterValueBuilder> parameters);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having, Action<IMoreOptionsHavingBuilder> moreOptions);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having,
            Action<IBuildParameterValueBuilder> parameters, Action<IMoreOptionsHavingBuilder> moreOptions);

        IBuild RunBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having, Action<IAgentHavingBuilder> onAgent,
            Action<IBuildParameterValueBuilder> parameters, Action<IMoreOptionsHavingBuilder> moreOptions);

        BuildConfiguration CreateBuildConfiguration(Action<IBuildProjectHavingBuilder> having,
            string buildConfigurationName);

        IList<IBuild> GetBuildsQueue(Action<IQueueHavingBuilder> having = null);
        void RemoveBuildFromQueue(Action<IQueueHavingBuilder> having);
        void RemoveBuildFromQueue(Action<IBuildQueueIdHavingBuilder> having);
        IList<Project> GetProjects(Action<IBuildProjectHavingBuilder> having);
        void DisableAgent(Action<IAgentHavingBuilder> having);
        void EnableAgent(Action<IAgentHavingBuilder> having);
        void AttachBuildConfigurationToTemplate(Action<IBuildConfigurationHavingBuilder> having, string buildTemplateId);
        Project GetProjectById(string projectId);
        IList<BuildConfiguration> GetBuildConfigurationsRecursively(string projectId);
        IList<Project> GetAllProjects();
        IList<string> DownloadArtifacts(int buildId, string destinationPath);
        string DownloadArtifact(int buildId, string destinationPath, string fileToDownload);
        Investigation GetInvestigation(Action<IBuildConfigurationHavingBuilder> havingBuildConfig);
        Investigation GetTestinvestigationByTestNameId(string testNameId);
        List<User> GetAllUsers();
        User GetUser(Action<IUserHavingBuilder> having);
        Project CreateProject(Action<INewProjectDetailsBuilder> newProjectDetailsBuilderAction);
        List<BuildConfiguration> GetAllBuildConfigurationTemplates();
        BuildConfiguration GetBuildConfigurationTemplate(Action<IBuildConfigurationTemplateHavingBuilder> having);

        /// <summary>
        /// Deletes build parameter from build configuration or build configuration template
        /// </summary>
        /// <param name="project">Project to delete parameter from</param>
        /// <param name="parameterName">Parameter name to be deleted</param>
        void DeleteProjectParameter(Action<IBuildProjectHavingBuilder> project, Action<IBuildParameterHavingBuilder> parameterName);

        /// <summary>
        /// Deletes build parameter from build configuration or build configuration template
        /// </summary>
        /// <param name="buildConfigurationOrTemplate">IBuild configuration or template to delete parameter from</param>
        /// <param name="parameterName">Parameter name to be deleted</param>
        void DeleteBuildConfigurationParameter(Action<IBuildConfigurationHavingBuilder> buildConfigurationOrTemplate, Action<IBuildParameterHavingBuilder> parameterName);

        /// <summary>
        /// Retrieves build statistics according to the provided build criteria
        /// </summary>
        /// <param name="having">Build criteria</param>
        /// <returns>List of build statistics</returns>
        IList<IBuildStatistic> GetBuildStatistics(Action<IBuildHavingBuilder> having);

        /// <summary>
        /// Creates a VCS root.
        /// </summary>
        /// <param name="vcsRoot">The VCS root data.</param>
        /// <returns></returns>
        VcsRoot CreateVcsRoot(Action<IGitVCSRootBuilder> vcsRoot);

        /// <summary>
        /// Attaches the VCS root to a build configuration.
        /// </summary>
        /// <param name="having">The having.</param>
        /// <param name="vcsRootEntryHaving">The VCS root entry.</param>
        void AttachVcsRootToBuildConfiguration(Action<IBuildConfigurationHavingBuilder> having, Action<IVCSRootEntryBuilder> vcsRootEntryHaving);
    }

}
