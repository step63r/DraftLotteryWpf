using DraftLotteryWpf.Common;
using DraftLotteryWpf.Content.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;

namespace DraftLotteryWpf.Content.ViewModels
{
    public class TopPageViewModel : BindableBase, IRegionMemberLifetime
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
        /// 開始コマンド
        /// </summary>
        public DelegateCommand StartCommand { get; private set; }
        /// <summary>
        /// ユーザー設定コマンド
        /// </summary>
        public DelegateCommand ConfigureUsersCommand { get; private set; }
        /// <summary>
        /// 履歴確認コマンド
        /// </summary>
        public DelegateCommand ShowHistoriesCommand { get; private set; }

        private List<User> _allUsers;
        /// <summary>
        /// ユーザー情報一覧
        /// </summary>
        public List<User> AllUsers
        {
            get { return _allUsers; }
            set { SetProperty(ref _allUsers, value); }
        }

        private List<User> _selectedUsers;
        /// <summary>
        /// 選択されたユーザー情報
        /// </summary>
        public List<User> SelectedUsers
        {
            get { return _selectedUsers; }
            set { SetProperty(ref _selectedUsers, value); }
        }

        /// <summary>
        /// インスタンスを使い回すか
        /// </summary>
        public bool KeepAlive { get; } = false;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="eventAggregator"></param>
        public TopPageViewModel(RegionManager regionManager, IEventAggregator eventAggregator)
        {
            // インタフェースを受け取る
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            // コマンドを定義
            StartCommand = new DelegateCommand(ExecuteStartCommand, CanExecuteStartCommand);
            ConfigureUsersCommand = new DelegateCommand(ExecuteConfigureUsersCommand, CanExecuteConfigureUsersCommand);
            ShowHistoriesCommand = new DelegateCommand(ExecuteShowHistoriesCommand, CanExecuteShowHistoriesCommand);

            // 初期化処理
            UsersDataStore.Initialize();
            AllUsers = UsersDataStore.GetUsers();
        }

        /// <summary>
        /// 抽選を開始する
        /// </summary>
        public void ExecuteStartCommand()
        {

        }

        /// <summary>
        /// 抽選が開始可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteStartCommand()
        {
            return SelectedUsers.Count > 1;
        }

        /// <summary>
        /// ユーザー設定を実行する
        /// </summary>
        public void ExecuteConfigureUsersCommand()
        {

        }

        /// <summary>
        /// ユーザー設定が実行可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteConfigureUsersCommand()
        {
            return false;
        }

        /// <summary>
        /// 履歴確認を実行する
        /// </summary>
        public void ExecuteShowHistoriesCommand()
        {

        }

        /// <summary>
        /// 履歴確認が実行可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteShowHistoriesCommand()
        {
            return false;
        }
    }
}
