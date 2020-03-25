using Loxodon.Framework.Observables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    public class PlayerModel : ObservableObject
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

        private Vector3 position;
        public Vector3 Position
        {
            get { return this.position; }
            set
            {
                Set<Vector3>(ref this.position, value, "Position");
            }
        }

        private Vector3 rotation;
        public Vector3 Rotation
        {
            get { return this.rotation; }
            set
            {
                Set<Vector3>(ref this.rotation, value, "Rotation");
            }
        }

        public PlayerModel() { }

        public PlayerModel(Transform transform,int score)
        {
            this.position = transform.position;
            this.rotation = transform.rotation.eulerAngles;
            this.score = score;
        }
    }

}
