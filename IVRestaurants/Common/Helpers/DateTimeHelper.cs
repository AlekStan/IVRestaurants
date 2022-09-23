using Common.Helpers.Interfaces;

namespace Common.Helpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime GetUTCNow()
        {
            return DateTime.UtcNow;
        }
    }
}
