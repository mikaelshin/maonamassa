namespace MaoNaMassa.Common
{
    using System;

    public static class TimeCalculator
    {
        public static string GetTimeAgo(DateTime time)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - time.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "um segundo atrás" : ts.Seconds + " segundos atrás";
            }

            if (delta < 60 * 2)
            {
                return "um minuto atrás";
            }

            if (delta < 45 * 60)
            {
                return ts.Minutes + " minutos atrás";
            }

            if (delta < 90 * 60)
            {
                return "uma hora atrás";
            }

            if (delta < 24 * 60 * 60)
            {
                return ts.Hours + " horas atrás";
            }

            if (delta < 48 * 60 * 60)
            {
                return "ontem";
            }

            if (delta < 30 * 24 * 60 * 60)
            {
                return ts.Days + " dias atrás";
            }

            if (delta < 12 * 30 * 24 * 60 * 60)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? " um mês atrás" : months + " meses atrás";
            }

            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "um ano atrás" : years + " anos atrás";
        }
    }
}
