using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Messaging;
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

        private int score = 0;

        IMessenger messenger;

        private GameMainViewModel gameMainViewModel;
        protected override void OnCreate(IBundle bundle)
        {
            messenger = Messenger.Default;
            this.gameMainViewModel = new GameMainViewModel(messenger);
            this.gameMainViewModel.ScoreModel.PropertyChanged += ScoreModel_PropertyChanged;

            BindingSet<GameMainWindow, GameMainViewModel> bindingSet = this.CreateBindingSet(gameMainViewModel);
        }

        private void ScoreModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {            
            scoreText.text = "金钱:" + this.gameMainViewModel.ScoreModel.Score;
        }
    }

}
