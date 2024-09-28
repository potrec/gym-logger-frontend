namespace gym_logger_backend.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ParseDate(string dateString)
        {
            return DateTime.SpecifyKind(DateTime.ParseExact(dateString, "dd-MM-yyyy", null), DateTimeKind.Utc);
        }
    }
}
