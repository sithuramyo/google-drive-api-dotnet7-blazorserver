namespace GoogleDriveAPI.Utility
{
    public static class Utility
    {
        public static string? ToUniqueName(this string st)
        {
            if (st == null) return null;
            string now = DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            return now + st;
        }
    }
}
