namespace DraftLotteryWpf.Common
{
    /// <summary>
    /// ユーザー情報
    /// </summary>
    public class User
    {
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; private set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public User()
        {
            Guid = System.Guid.NewGuid().ToString();
        }
    }
}
