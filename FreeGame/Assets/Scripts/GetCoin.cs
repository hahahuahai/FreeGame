using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FreeGame
{
    public class GetCoin : MonoBehaviour
    {
        public int RebirthTime;//金币重生时间，秒。
        public string PlayerName;
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
            if (other.gameObject.name == PlayerName)
            {
                this.messenger.Publish(EventsNames.UI_Score, 1);
                CoroutineTask coinStatusTask = new CoroutineTask(CoinStatusController());
            }
        }
        IEnumerator CoinStatusController()
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(RebirthTime);
            gameObject.SetActive(true);
        }

    }

}
