using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeGame
{
    public class NPCDialogWindow : Window
    {
        public Text NpcTalkerText;
        public Text TalkContentText;
        public Button ComfirmButton;
        public Button CancelButton;

        private IMessenger messenger;
        private NPCDialogViewModel npcDialogViewModel;

        protected override void OnCreate(IBundle bundle)
        {
            messenger = Messenger.Default;


            npcDialogViewModel = new NPCDialogViewModel(messenger);
            npcDialogViewModel.Dialog_RentCar.PropertyChanged += Dialog_RentCar_PropertyChanged;


            BindingSet<NPCDialogWindow, NPCDialogViewModel> bindingSet = this.CreateBindingSet(npcDialogViewModel);

        }

        private void Dialog_RentCar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            NpcTalkerText.text = npcDialogViewModel.Dialog_RentCar.TalkerName;
            TalkContentText.text = npcDialogViewModel.Dialog_RentCar.TalkContent;
            Debug.Log("已改变值");
        }
    }

}