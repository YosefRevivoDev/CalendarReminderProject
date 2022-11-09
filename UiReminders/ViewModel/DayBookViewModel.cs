using System;
using System.Windows.Media;
using UiReminders.Model;

namespace UiReminders.ViewModel
{
    public class DayBookViewModel : BaseViewModel
    {
        private static Brush redColorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
        private static Brush blueColorBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue"));

        private static Brush greenColorForground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
        private static Brush orangeColorForground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange"));

        public DayBookModel DayBookModel { get; set; }

        public DayBookViewModel(DayBookModel dayBookModel)
        {
            this.DayBookModel = dayBookModel;

            Id = dayBookModel.Id;
            dateMessage = dayBookModel.DateMessage;
            message = dayBookModel.Message;
            (backgroundColor, foregroundColor) = dayColor(dateMessage.DayOfWeek);
        }

        public DayBookViewModel()    { }

        /// <summary>
        /// The method that will represent a unique identifier for each text that 
        /// will be entered on a marked day
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Brush backgroundColor;

        public Brush BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
        }

        /// <summary>
        /// 
        /// </summary>
        private Brush foregroundColor;

        public Brush ForegroundColor
        {
            get { return foregroundColor; }
            set { foregroundColor = value; OnPropertyChanged(nameof(ForegroundColor)); }
        } 

        /// <summary>
        /// This method will generate a time signature for the text
        /// that will be entered on the indicated day</summary>
        private DateTime dateMessage;

        public DateTime DateMessage
        {
            get { return dateMessage; }

            set
            {
                dateMessage = value;
                OnPropertyChanged(nameof(DateMessage));
                (backgroundColor, foregroundColor) = dayColor(dateMessage.DayOfWeek);
            }
        }

        /// <summary>
        /// This method will represent the string that will
        /// be entered for a specified day
        /// </summary>

        private string message;

        public string Message
        {
            get { return message; }

            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        private (Brush, Brush) dayColor(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Friday or DayOfWeek.Saturday => (redColorBackground, orangeColorForground),
                _ => (blueColorBackground, greenColorForground),
            };
        }
    }
}
