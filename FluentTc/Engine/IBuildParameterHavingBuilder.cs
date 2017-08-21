namespace FluentTc.Engine
{
    public class BuildParameterHavingBuilder : IBuildParameterHavingBuilder
    {
        private string m_ParameterName;

        public string GetLocator()
        {
            return m_ParameterName;
        }

        public void ParameterName(string parameterName)
        {
            m_ParameterName = parameterName;
        }
    }
}