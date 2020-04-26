using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DraftLotteryWpf.Common
{
    /// <summary>
    /// セッション情報
    /// </summary>
    public class Session : INotifyPropertyChanged
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

        private DateTime _createDate = DateTime.Now;
        /// <summary>
        /// 作成日付
        /// </summary>
        public DateTime CreateDate
        {
            get => _createDate;
            set
            {
                if (value == _createDate)
                {
                    return;
                }
                _createDate = value;
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

        private List<User> _result;
        /// <summary>
        /// 結果
        /// </summary>
        public List<User> Result
        {
            get => _result;
            set
            {
                if (value == _result)
                {
                    return;
                }
                _result = value;
                RaisePropertyChanged();
            }
        }
    }
}
