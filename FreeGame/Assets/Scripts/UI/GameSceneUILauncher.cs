using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FreeGame
{
    public class GameSceneUILauncher : MonoBehaviour
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
        }
        // Start is called before the first frame update
        void Start()
        {
            WindowContainer windowContainer = WindowContainer.Create("MAIN");

            IUIViewLocator locator = applicationContext.GetService<IUIViewLocator>();
            GameMainWindow startWindow = locator.LoadWindow<GameMainWindow>(windowContainer, "Prefabs/UI/GameMainWindow");
            startWindow.Create();
            startWindow.Show();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
