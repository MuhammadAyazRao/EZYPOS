namespace EZYPOS.View
{
    public static class MessageBox
    {
        private static MessageUI msg = null;
        public static void ShowDefault()
        {
            msg = new MessageUI();
            msg.Show();
        }

        public static void ShowCustom(string message, string title, string btnTitle)
        {
            msg = new MessageUI(message, title, btnTitle);
            msg.ShowDialog();
        }
    }
}
