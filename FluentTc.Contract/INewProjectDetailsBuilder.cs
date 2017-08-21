using FluentTc.Locators;
using System;

namespace FluentTc.Engine
{
    public interface INewProjectDetailsBuilder
    {
        INewProjectDetailsBuilder Name(string newProjectName);
        INewProjectDetailsBuilder Id(string newProjectId);
        INewProjectDetailsBuilder ParentProject(Action<IBuildProjectHavingBuilder> parentProject);
    }
}
