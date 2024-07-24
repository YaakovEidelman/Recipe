namespace RecipeSystem
{
    public class DBManager
    {
        public static void SetConnString(string conn)
        {
            SQLUtility.ConnectionString = conn;
        }
    }
}
