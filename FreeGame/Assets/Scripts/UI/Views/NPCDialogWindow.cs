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

        protected override void OnCreate(IBundle bundle)
        {
            
        }
    }

}