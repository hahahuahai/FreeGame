using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Services;
using Loxodon.Framework.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace FreeGame
{
    public class GameMainWindow : Window
    {
        public Text scoreText;
        public Text DescriptionText;

        private int score = 0;

        IMessenger messenger;

        private IPlayerService playerService;

        private GameMainViewModel gameMainViewModel;
        protected override void OnCreate(IBundle bundle)
        {
            ApplicationContext applicationContext = Context.GetApplicationContext();
            IServiceContainer container = applicationContext.GetContainer();
            playerService = container.Resolve<IPlayerService>();

            messenger = Messenger.Default;
            this.gameMainViewModel = new GameMainViewModel(messenger);
            this.gameMainViewModel.ScoreModel.PropertyChanged += ScoreModel_PropertyChanged;

            scoreText.text = "金钱:" + this.gameMainViewModel.ScoreModel.Score;

            BindingSet<GameMainWindow, GameMainViewModel> bindingSet = this.CreateBindingSet(gameMainViewModel);

            bindingSet.Build();
        }

        private void ScoreModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            scoreText.text = "金钱:" + this.gameMainViewModel.ScoreModel.Score;
            playerService.SetPlayerScore(this.gameMainViewModel.ScoreModel.Score);
        }
    }

}
