namespace Classes.Time {
    public class Time {
        public static string RemainingTimeToString(DateTime endDate){
            TimeSpan remainingTime = endDate - DateTime.Now;
            if (remainingTime.TotalDays > 1) {
                return $"Faltam {(int)remainingTime.TotalDays} dias {remainingTime.Hours} horas";
            }
            else if (remainingTime.TotalMinutes > 60) {
                return $"Faltam {remainingTime.Hours} horas {remainingTime.Minutes} min";
            }
            else {
                return $"Faltam {remainingTime.Minutes} min {remainingTime.Seconds} seg";
            }
        }
        public static string RemainingTimeToStringShort(DateTime endDate) {
            TimeSpan remainingTime = endDate - DateTime.Now;
            if (remainingTime.TotalDays > 0) {
                return $"{(int)remainingTime.TotalDays} dias {remainingTime.Hours} horas";
            }
            else if (remainingTime.TotalMinutes > 60) {
                return $"{remainingTime.Hours} horas {remainingTime.Minutes} min";
            } else {
                return $" {remainingTime.Minutes} min {remainingTime.Seconds} seg";
            }
        }

        public static string BetterPrintDate(DateTime endDate) {
            return $"{endDate.Day.ToString("00")}/{endDate.Month.ToString("00")}/{endDate.Year.ToString("00")} {endDate.Hour.ToString("00")}:{endDate.Minute.ToString("00")}:{endDate.Second.ToString("00")}";
        }
    
    }
}