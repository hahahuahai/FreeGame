using Loxodon.Framework.Messaging;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{

    public class NPCDialogViewModel : ViewModelBase
    {
        private IDisposable subscription;
        public Dialogs_CSV Dialog_RentCar { get; }
        public NPCDialogViewModel(IMessenger messenger)
        {
            Dialog_RentCar = new Dialogs_CSV();
            Messenger = messenger;
            this.subscription = Messenger.Subscribe<int>(EventsNames.UI_RentCar, GetDialogData);
            Debug.Log("事件能接受了");
        }

        private void GetDialogData(int id)
        {
            List<Dialogs_CSV> dialogs_CSVs = CsvReadingHelper.Instance.Dialogs_CSV;
            foreach (var item in dialogs_CSVs)
            {
                if (item.ID == id)
                {
                    Dialog_RentCar.ID = item.ID;
                    Dialog_RentCar.TalkerName = item.TalkerName;
                    Dialog_RentCar.TalkContent = item.TalkContent;
                }
            }
        }
    }

}
