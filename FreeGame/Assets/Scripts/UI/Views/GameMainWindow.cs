using Loxodon.Framework.Messaging;
using Loxodon.Framework.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeGame
{
    public class GameMainWindow : Window
    {
        public Text scoreText;

        private int score = 0;
        private IMessenger messenger;
        private IDisposable subscription;
        protected override void OnCreate(IBundle bundle)
        {
            this.messenger = Messenger.Default;
            this.subscription = this.messenger.Subscribe<int>("scored", changeScore);
        }

        private void changeScore(int addscore)
        {
            score += addscore;
            scoreText.text = "得分:" + score;
        }
    }

}
