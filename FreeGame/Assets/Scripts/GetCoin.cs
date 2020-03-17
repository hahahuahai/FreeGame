using Loxodon.Framework.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FreeGame
{
    public class GetCoin : MonoBehaviour
    {
        private IMessenger messenger;

        private void Start()
        {
            this.messenger = Messenger.Default;
        }
        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "RollerBall")
            {
                this.messenger.Publish(EventsNames.UI_Score, 1);
                GameObject.Destroy(gameObject);
            }
        }

    }

}
