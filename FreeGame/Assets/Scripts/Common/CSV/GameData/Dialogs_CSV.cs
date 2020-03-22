using Loxodon.Framework.Observables;

namespace FreeGame
{
    public class Dialogs_CSV : ObservableObject
    {
        private int id;
        private string talkerName;
        private string talkContent;
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
            get { return this.talkContent; }
            set { this.Set<string>(ref this.talkContent, value, "TalkContent"); }
        }
    }
}
