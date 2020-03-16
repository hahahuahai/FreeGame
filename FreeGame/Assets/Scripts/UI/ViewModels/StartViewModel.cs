using Loxodon.Framework.Commands;
using Loxodon.Framework.Contexts;
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


        public ICommand StartCommand
        {
            get { return this.startCommand; }
        }

        public StartViewModel()
        {
            ApplicationContext applicationContext = Context.GetApplicationContext();

            this.startCommand = new SimpleCommand(() =>
            {
                this.startCommand.Enabled = false;
                SceneManager.LoadSceneAsync("GameScene");
            });
        }
    }

}