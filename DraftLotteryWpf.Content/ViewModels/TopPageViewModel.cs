using DraftLotteryWpf.Common;
using DraftLotteryWpf.Content.Services;
using DraftLotteryWpf.Content.Views;
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
        /// ユーザー追加コマンド
        /// </summary>
        public DelegateCommand AddUserToSelectedUsersCommand { get; private set; }
        /// <summary>
        /// ユーザー削除コマンド
        /// </summary>
        public DelegateCommand RemoveUserFromSelectedUsersCommand { get; private set; }
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

        private User _selectedUserInAllUsers;
        /// <summary>
        /// 一覧で選択しているユーザー
        /// </summary>
        public User SelectedUserInAllUsers
        {
            get { return _selectedUserInAllUsers; }
            set { SetProperty(ref _selectedUserInAllUsers, value); }
        }

        private User _selectedUserInSelectedUsers;
        /// <summary>
        /// 選択されたユーザー情報で選択しているユーザー
        /// </summary>
        public User SelectedUserInSelectedUsers
        {
            get { return _selectedUserInSelectedUsers; }
            set { SetProperty(ref _selectedUserInSelectedUsers, value); }
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
            AddUserToSelectedUsersCommand = new DelegateCommand(ExecuteAddUserToSelectedUsersCommand, CanExecuteAddUserToSelectedUsersCommand);
            AddUserToSelectedUsersCommand.ObservesProperty(() => SelectedUserInAllUsers);
            RemoveUserFromSelectedUsersCommand = new DelegateCommand(ExecuteRemoveUserFromSelectedUsersCommand, CanExecuteRemoveUserFromSelectedUsersCommand);
            RemoveUserFromSelectedUsersCommand.ObservesProperty(() => SelectedUserInSelectedUsers);
            StartCommand = new DelegateCommand(ExecuteStartCommand, CanExecuteStartCommand);
            StartCommand.ObservesProperty(() => SelectedUsers);
            ConfigureUsersCommand = new DelegateCommand(ExecuteConfigureUsersCommand);
            ShowHistoriesCommand = new DelegateCommand(ExecuteShowHistoriesCommand, CanExecuteShowHistoriesCommand);

            // 初期化処理
            UsersDataStore.Initialize();
            AllUsers = UsersDataStore.GetUsers();
        }

        /// <summary>
        /// ユーザーを追加する
        /// </summary>
        private void ExecuteAddUserToSelectedUsersCommand()
        {
            SelectedUsers.Add(SelectedUserInAllUsers);
        }

        /// <summary>
        /// ユーザーが追加可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteAddUserToSelectedUsersCommand()
        {
            return SelectedUserInAllUsers != null && SelectedUsers.Contains(SelectedUserInAllUsers);
        }

        /// <summary>
        /// ユーザーを削除する
        /// </summary>
        private void ExecuteRemoveUserFromSelectedUsersCommand()
        {
            SelectedUsers.Remove(SelectedUserInSelectedUsers);
        }

        /// <summary>
        /// ユーザーが削除可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteRemoveUserFromSelectedUsersCommand()
        {
            return SelectedUserInSelectedUsers != null;
        }

        /// <summary>
        /// 抽選を開始する
        /// </summary>
        private void ExecuteStartCommand()
        {

        }

        /// <summary>
        /// 抽選が開始可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteStartCommand()
        {
            return SelectedUsers != null && SelectedUsers.Count > 1;
        }

        /// <summary>
        /// ユーザー設定を実行する
        /// </summary>
        private void ExecuteConfigureUsersCommand()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ConfigureUsersPage));
        }

        /// <summary>
        /// 履歴確認を実行する
        /// </summary>
        private void ExecuteShowHistoriesCommand()
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
