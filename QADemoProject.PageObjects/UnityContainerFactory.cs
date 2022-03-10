using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QADemoProject.PageObjects
{
    //Container class
    public class UnityContainerFactory
    {
        private static IUnityContainer _unityContainer;

        static UnityContainerFactory()
        {
            _unityContainer = new UnityContainer();
        }

        public static IUnityContainer GetContainer()
        {
            return _unityContainer;
        }

    }
}
