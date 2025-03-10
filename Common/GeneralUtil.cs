namespace TaskManagementSystem.Common
{
    public class GeneralUtil
    {
        public static string GeneratedKey
        {
            get
            {
                Thread.Sleep(100);

                DateTime l_CurrentDate = System.DateTime.Now;

                return GeneralUtil.ConvertSystemDateStringFormat(l_CurrentDate)

                    + GeneralUtil.ConvertSystemTimeFormat(l_CurrentDate)

                    + l_CurrentDate.Millisecond.ToString("0000");


            }
        }

        public static string ConvertSystemDateStringFormat(DateTime? aDate)
        {
            try
            {
                if (aDate.HasValue)
                {
                    #region convert date to string format

                    int l_Year = aDate.Value.Year;
                    int l_month = aDate.Value.Month;
                    int l_day = aDate.Value.Day;

                    string l_strYear = l_Year.ToString();
                    string l_strMonth = l_month.ToString("00");
                    string l_strDay = l_day.ToString("00");
                    return l_strYear + l_strMonth + l_strDay;

                    #endregion
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {

                return string.Empty;
            }
        }
        public static string ConvertSystemTimeFormat(DateTime aDate)
        {
            string l_Time = "";

            l_Time += aDate.Hour.ToString("00");

            l_Time += aDate.Minute.ToString("00");

            l_Time += aDate.Second.ToString("00");

            return l_Time;
        }
    }
}
