using System;
using System.Text;
using FluentTc.Locators;

namespace FluentTc.Engine
{
    internal class NewProjectDetailsBuilder : INewProjectDetailsBuilder
    {
        private string m_ProjectName;
        private string m_ProjectId;
        private string m_ParentLocator;

        public INewProjectDetailsBuilder Name(string newProjectName)
        {
            m_ProjectName = newProjectName;
            return this;
        }

        public INewProjectDetailsBuilder Id(string newProjectId)
        {
            m_ProjectId = newProjectId;
            return this;
        }

        public INewProjectDetailsBuilder ParentProject(Action<IBuildProjectHavingBuilder> parentProject)
        {
            var buildProjectHavingBuilder = new BuildProjectHavingBuilder();
            parentProject(buildProjectHavingBuilder);
            m_ParentLocator = buildProjectHavingBuilder.GetLocator();
            return this;
        }

        public string GetDataXml()
        {
            var dataXmlBuilder = new StringBuilder();
            dataXmlBuilder.AppendFormat(@"<newProjectDescription name='{0}'", m_ProjectName);
            if (!string.IsNullOrEmpty(m_ProjectId))
            {
                dataXmlBuilder.AppendFormat(" id='{0}'", m_ProjectId);
            }
            dataXmlBuilder.Append(@">");

            if (!string.IsNullOrEmpty(m_ParentLocator))
            {
                dataXmlBuilder.AppendFormat("<parentProject locator='{0}'/>", m_ParentLocator);
            }

            dataXmlBuilder.Append("</newProjectDescription>");

            return dataXmlBuilder.ToString();  
        }
    }
}