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
        private ApplicationContext applicationContext;
        private void Awake()
        {
            GlobalWindowManager windowManager = FindObjectOfType<GlobalWindowManager>();
            if (windowManager == null)
            {
                Debug.Log("没有找到GlobalWindowManager");
            }
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
            StartWindow startWindow = locator.LoadWindow<StartWindow>(windowContainer, "Prefabs/UI/StartWindow");
            startWindow.Create();
            startWindow.Show();

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
