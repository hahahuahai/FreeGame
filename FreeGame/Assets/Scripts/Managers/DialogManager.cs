using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    /// <summary>
    /// Dialog管理
    /// </summary>
    public class DialogManager : SingletonNoMono<DialogManager>
    {
        static List<Dialogs_CSV> dialogs_CSVs = new List<Dialogs_CSV>();

        public override void Init()
        {
            base.Init();

            if (dialogs_CSVs.Count == 0)
            {
                dialogs_CSVs = CsvHelper.Csv2List<Dialogs_CSV>(CsvNames.Dialogs);
                Debug.Log("CsvNames.Dialogs已初始化！");
            }
        }

        public static Dialogs_CSV GetDialogByID(int id)
        {
            if (dialogs_CSVs.Count == 0)
            {
                return null;
            }

            foreach (var dialog in dialogs_CSVs)
            {
                if (dialog.ID == id)
                {
                    return dialog;
                }
            }
            return null;
        }

        public static Dialogs_CSV GetDialogByTalkerName(string talkName)
        {
            if (dialogs_CSVs.Count == 0)
            {
                return null;
            }

            foreach (var dialog in dialogs_CSVs)
            {
                if (dialog.TalkerName == talkName)
                {
                    return dialog;
                }
            }
            return null;
        }
    }

}
