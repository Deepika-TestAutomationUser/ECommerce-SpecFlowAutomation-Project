using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QADemoProject.SupportClasses;
using System;
using System.IO;

namespace PathFinders.SupportClasses
{
    //This class reads data from the Appsettings
    public class AppSettingsJsonReader
    {

        static class ConfigurationManager
        {
            public static IConfiguration AppSetting { get; }
            public static IConfiguration LaunchSetting { get; }
            public static IHostingEnvironment env { get; }
            public static string environmentName = "ASPNETCORE_ENVIRONMENT";
            static ConfigurationManager()
            {
                var path = Directory.GetCurrentDirectory().Replace("\\TestResults", "");
                path = Path.Combine(path, "QADemoProject.UI.Tests.SpecFlow");
                IServiceCollection services = new ServiceCollection();
                IServiceProvider serviceProvider = services.BuildServiceProvider();
                env = serviceProvider.GetService<IHostingEnvironment>();
                //path = path.Replace("\\TestResults", "");
                string launchSettingPath = string.Concat(path, "\\Properties");
                var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
                environmentVariable = "Stage";
                AppSetting = new ConfigurationBuilder()
               .SetBasePath(path)
               .AddJsonFile("appSettings.json", true, true).AddJsonFile("appSettings.json", true).Build();

            }
        }

        public static string ExecutingEnvironment
        {
            get
            {
                return (string)ConfigurationManager.LaunchSetting["profiles:QADemoProject.UI.Tests.SpecFlow:environmentVariables:ASPNETCORE_ENVIRONMENT"];
            }
        }
       
        public static string Env_EdgeUrl
        {
            get
            {
                return (string)ConfigurationManager.AppSetting["profiles:QADemoProject.UI.Tests.SpecFlow:TestSettings:Env_EdgeUrl"];
            }

        }
        public static string Env_EdgeUserName
        {
            get
            {
                return (string)ConfigurationManager.AppSetting["profiles:QADemoProject.UI.Tests.SpecFlow:TestSettings:Env_EdgeUserName"];
            }

        }
        public static string Env_EdgePwd
        {
            get
            {
                return (string)ConfigurationManager.AppSetting["profiles:QADemoProject.UI.Tests.SpecFlow:TestSettings:Env_EdgePwd"];
            }

        }

        public static string Env_ScreenShots
        {
            get
            {
                return (string)ConfigurationManager.AppSetting["profiles: QADemoProject.UI.Tests.SpecFlow:TestSettings:Env_ScreenShots"];
            }

        }

        
    }
}