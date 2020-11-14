using EZYPOS.View;

namespace EZYPOS.View
{
    public static class MessageYesNo
    {
        private static ConfirmationBox db = null;

        public static bool ShowDefault()
        {
            db = new ConfirmationBox();
            return db.ShowDialog() == true ? true : false;
        }

        public static bool ShowCustom(string title, string message, string buttonAccept, string buttonReject)
        {
            db = new ConfirmationBox(title, message, buttonAccept, buttonReject);
            return db.ShowDialog() == true ? true : false;
        }
    }
}
