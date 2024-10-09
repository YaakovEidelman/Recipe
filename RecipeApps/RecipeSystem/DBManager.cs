namespace RecipeSystem
{
    public class DBManager
    {
        public static void SetConnString(string conn, bool tryopen, string userid = "", string password = "")
        {
            SQLUtility.SetConnectionString(conn, tryopen, userid, password);
        }
    }
}
