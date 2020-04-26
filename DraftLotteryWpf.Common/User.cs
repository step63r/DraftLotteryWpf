using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DraftLotteryWpf.Common
{
    /// <summary>
    /// ユーザー情報
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// RaisePropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _guid = System.Guid.NewGuid().ToString();
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid
        {
            get => _guid;
            set
            {
                if (value == _guid)
                {
                    return;
                }
                _guid = value;
                RaisePropertyChanged();
            }
        }

        private string _name = "";
        /// <summary>
        /// 名前
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                {
                    return;
                }
                _name = value;
                RaisePropertyChanged();
            }
        }
    }
}
