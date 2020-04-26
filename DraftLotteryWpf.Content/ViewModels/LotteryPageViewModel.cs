using DraftLotteryWpf.Common;
using DraftLotteryWpf.Content.Services;
using DraftLotteryWpf.Content.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace DraftLotteryWpf.Content.ViewModels
{
    public class LotteryPageViewModel : BindableBase, IRegionMemberLifetime
    {
        #region インタフェース
        /// <summary>
        /// RegionManager
        /// </summary>
        private readonly IRegionManager _regionManager;
        /// <summary>
        /// EventAggregator
        /// </summary>
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region コマンド・プロパティ
        /// <summary>
        /// 停止コマンド
        /// </summary>
        public DelegateCommand StopCommand { get; private set; }
        /// <summary>
        /// 戻るコマンド
        /// </summary>
        public DelegateCommand GoBackCommand { get; private set; }
        /// <summary>
        /// 選択されたユーザー情報
        /// </summary>
        public ObservableCollection<User> SelectedUsers { get; set; } = new ObservableCollection<User>();

        private List<User> _result = new List<User>();
        /// <summary>
        /// 結果格納用
        /// </summary>
        public List<User> Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        private bool _isStopped = false;
        /// <summary>
        /// ストップフラグ
        /// </summary>
        public bool IsStopped
        {
            get { return _isStopped; }
            set { SetProperty(ref _isStopped, value); }
        }

        /// <summary>
        /// インスタンスを使い回すか
        /// </summary>
        public bool KeepAlive { get; } = false;
        #endregion

        /// <summary>
        /// WPFタイマ
        /// </summary>
        private DispatcherTimer _dispatcherTimer;
        /// <summary>
        /// 抽選結果
        /// </summary>
        private List<User> _results = new List<User>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="eventAggregator"></param>
        public LotteryPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            // インタフェースを受け取る
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MessageSentEvent>().Subscribe(SelectedUsersReceived);

            // コマンドを定義
            StopCommand = new DelegateCommand(ExecuteStopCommand, CanExecuteStopCommand);
            StopCommand.ObservesProperty(() => IsStopped);
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand);

            Result = new List<User>(SelectedUsers);

            // 抽選開始
            Loaded();
        }

        /// <summary>
        /// 選択されたユーザー一覧取得イベント
        /// </summary>
        /// <param name="users"></param>
        private void SelectedUsersReceived(ObservableCollection<User> users)
        {
            SelectedUsers = users;
        }

        /// <summary>
        /// 読込完了時イベント
        /// </summary>
        private void Loaded()
        {
            // タイマ設定
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _dispatcherTimer.Tick += new EventHandler(_dispatcherTimer_Tick);
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// タイマイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Result = SelectedUsers.OrderBy(item => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// 抽選を停止する
        /// </summary>
        private void ExecuteStopCommand()
        {
            _dispatcherTimer.Stop();
            IsStopped = true;

            var session = new Session()
            {
                Name = DateTime.Now.ToString("yyyy/MM/dd (ddd) HH:mm:ss"),
                Result = Result
            };
            SessionsDataStore.AddSession(session);
        }

        /// <summary>
        /// 抽選が停止可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteStopCommand()
        {
            return !IsStopped;
        }

        /// <summary>
        /// 戻る
        /// </summary>
        private void ExecuteGoBackCommand()
        {
            _dispatcherTimer.Stop();
            IsStopped = true;
            _regionManager.RequestNavigate("ContentRegion", nameof(TopPage));
        }
    }
}
