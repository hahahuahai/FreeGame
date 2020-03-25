using Loxodon.Framework.Commands;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using Loxodon.Framework.ViewModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FreeGame
{
    public class StartViewModel : ViewModelBase
    {
        private SimpleCommand startCommand;
        private SimpleCommand loadCommand;


        public ICommand StartCommand
        {
            get { return this.startCommand; }
        }

        public ICommand LoadCommand
        {
            get { return this.loadCommand; }
        }

        public StartViewModel()
        {
            ApplicationContext applicationContext = Context.GetApplicationContext();
            IServiceContainer container = applicationContext.GetContainer();
            IPlayerService playerService = container.Resolve<IPlayerService>();
            this.startCommand = new SimpleCommand(() =>
            {
                this.startCommand.Enabled = false;

                playerService.ClearPlayerData();//清空玩家数据
                playerService.SetPlayerPosition(new Vector3(-30, 0, 16.6f));//设置玩家默认出生地

                SceneManager.LoadSceneAsync("GameScene");
            });

            this.loadCommand = new SimpleCommand(() =>
            {
                this.loadCommand.Enabled = false;
                SceneManager.LoadSceneAsync("GameScene");
            });
        }
    }

}