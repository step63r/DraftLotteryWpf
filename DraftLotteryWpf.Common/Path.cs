using System;

namespace DraftLotteryWpf.Common
{
    /// <summary>
    /// パス設定
    /// </summary>
    public static class Path
    {
        /// <summary>
        /// 基底ディレクトリ
        /// </summary>
        public static string BaseDir = string.Format(@"{0}\DraftLotteryWpf", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        /// <summary>
        /// ユーザーファイル名
        /// </summary>
        public static string UsersFileName = @"users.xml";
        /// <summary>
        /// セッション情報ファイル名
        /// </summary>
        public static string SessionsFileName = @"sessions.xml";
    }
}
