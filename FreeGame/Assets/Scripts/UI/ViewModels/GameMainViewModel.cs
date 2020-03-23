using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace FreeGame
{
    public class GameMainViewModel : ViewModelBase
    {
        private PlayerModel scoreModel;
        private InteractionRequest<int> updateScore;
        private IDisposable subscription;
        public InteractionRequest<int> UpdateScore
        {
            get { return this.updateScore; }
        }

        public PlayerModel ScoreModel
        {
            get { return this.scoreModel; }
        }

        public GameMainViewModel(IMessenger messenger)
        {
            Messenger = messenger;
            scoreModel = new PlayerModel();
            this.subscription = Messenger.Subscribe<int>(EventsNames.UI_Score, changeScore);
            //this.updateScore = new InteractionRequest<int>(this);
            scoreModel.Score = 0;
        }

        private void changeScore(int score)
        {
            scoreModel.Score += score;
        }


    }

}
