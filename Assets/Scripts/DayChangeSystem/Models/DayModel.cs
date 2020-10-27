using DayChangeSystem.Interfaces;

namespace DayChangeSystem.Models
{
    public class DayModel : IDayModel
    {
        private int _days;
        private int _hours;
        private int _years;

        public int Days
        {
            get => _days;
            set => _days = value;
        }

        public int Hours
        {
            get => _hours;
            set => _hours = value;
        }

        public int Years
        {
            get => _years; 
            set => _years = value;
        }
    }
}
