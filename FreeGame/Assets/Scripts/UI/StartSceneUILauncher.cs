using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    public class StartSceneUILauncher : MonoBehaviour
    {
        public GlobalWindowManager windowManager;
        private ApplicationContext applicationContext;
        private void Awake()
        {


            applicationContext = Context.GetApplicationContext();
            IServiceContainer container = applicationContext.GetContainer();
            BindingServiceBundle bundle = new BindingServiceBundle(applicationContext.GetContainer());
            bundle.Start();

            container.Register<IUIViewLocator>(new DefaultUIViewLocator());           

        }
        // Start is called before the first frame update
        void Start()
        {
            WindowContainer windowContainer = WindowContainer.Create("MAIN");

            IUIViewLocator locator = applicationContext.GetService<IUIViewLocator>();

            AddAllWindows(windowContainer, locator);

            StartWindow startWindow = windowManager.Find<StartWindow>();
            startWindow.Create();
            startWindow.Show();

        }

        private void AddAllWindows(WindowContainer windowContainer, IUIViewLocator locator)
        {
            windowManager = FindObjectOfType<GlobalWindowManager>();
            if (windowManager == null)
            {
                Debug.Log("没有找到GlobalWindowManager");
            }

            //添加场景中所需要的window
            windowManager.Add(locator.LoadWindow<StartWindow>(windowContainer, "Prefabs/UI/StartWindow"));
        }
    }

}
