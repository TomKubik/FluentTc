using FluentTc.Locators;
using System;

namespace FluentTc
{
    public interface IRemoteTc
    {
        IConnectedTc Connect(Action<TeamCityConfigurationBuilder> connect);
    }
}
