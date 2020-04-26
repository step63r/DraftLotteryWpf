using Prism.Events;
using System.Collections.ObjectModel;

namespace DraftLotteryWpf.Common
{
    /// <summary>
    /// 選択されたユーザー情報を送受信するイベントクラス
    /// </summary>
    public class MessageSentEvent : PubSubEvent<ObservableCollection<User>>
    {
    }
}
