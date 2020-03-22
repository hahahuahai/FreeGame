using Loxodon.Framework.Observables;
using System;

namespace FreeGame
{
    public class Dialogs_CSV : ObservableObject
    {
        private int id;
        private string talkerName;
        private string talkerContent;

        public int ID
        {
            get { return this.id; }
            set { this.Set<int>(ref this.id, value, "ID"); }
        }
        public string TalkerName
        {
            get { return this.talkerName; }
            set { this.Set<string>(ref this.talkerName, value, "TalkerName"); }
        }
        public string TalkContent
        {
            get { return this.talkerContent; }
            set { this.Set<string>(ref this.talkerContent, value, "TalkContent"); }
        }
    }
}
