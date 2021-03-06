﻿using Loxodon.Framework.Commands;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Services;
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
        private IPlayerService playerService;
        private SimpleCommand antiDieCommand;
        public ICommand AntiDieCommand
        {
            get { return this.antiDieCommand; }
        }
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
            ApplicationContext applicationContext = Context.GetApplicationContext();
            IServiceContainer container = applicationContext.GetContainer();
            playerService = container.Resolve<IPlayerService>();
            PlayerModel playerModel = playerService.GetPlayerData();
            Messenger = messenger;
            scoreModel = new PlayerModel();
            this.subscription = Messenger.Subscribe<int>(EventsNames.UI_Score, changeScore);

            this.antiDieCommand = new SimpleCommand(() =>
            {
                Debug.Log("防卡死事件发送。");
                //发送防卡死事件，将player坐标改为初始地点。
                Messenger.Publish(EventsNames.UI_AntiDie, 1);
            });

            //this.updateScore = new InteractionRequest<int>(this);
            scoreModel.Score = playerModel.Score;
        }

        private void changeScore(int score)
        {
            scoreModel.Score += score;
        }


    }

}
