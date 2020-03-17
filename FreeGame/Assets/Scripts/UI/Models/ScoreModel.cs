using Loxodon.Framework.Observables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    public class ScoreModel : ObservableObject
    {
        private int score;

        public int Score
        {
            get { return this.score; }
            set
            {
                Set<int>(ref this.score, value, "Score");
            }
        }
    }

}
