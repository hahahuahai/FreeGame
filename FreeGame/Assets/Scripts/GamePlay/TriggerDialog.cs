using Loxodon.Framework.Messaging;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FreeGame
{

    public class TriggerDialog : MonoBehaviour
    {
        public string PlayerName;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("private void OnTriggerEnter(Collider other)");
            if (other.gameObject.name == PlayerName)
            {
                NPCDialogWindow npcDialogWindow = GameSceneUILauncher.windowManager.Find<NPCDialogWindow>();
                npcDialogWindow.Create();

                Messenger messenger = Messenger.Default;
                messenger.Publish(EventsNames.UI_RentCar, 1);//1为Dialog.csv里面的id
                Debug.Log("事件发了");
                npcDialogWindow.Show();
            }
          
        }
    }
}

