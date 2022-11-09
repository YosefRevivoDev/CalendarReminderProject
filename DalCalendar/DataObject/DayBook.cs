
using System.ComponentModel.DataAnnotations;

namespace DalReminders.DataObject
{
    /// <summary>
    /// This class will represent a day marked on a calendar with a reminder
    /// </summary>
    public class DayBook
    {
        public DayBook(int id, DateTime dateMessage, string message)
        {
            Id = id;
            DateMessage = dateMessage;
            Message = message;
        }

        /// <summary>
        /// The method that will represent a unique identifier for each text that 
        /// will be entered on a marked day
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// This method will generate a time signature for the text
        /// that will be entered on the indicated day</summary>
        public DateTime DateMessage { get; set; }

        /// <summary>
        /// This method will represent the string that will
        /// be entered for a specified day
        /// </summary>
        [Required]
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return $@"Id: {Id}, DateMessage: {DateMessage}, Message: {Message}";
        }
    }
}
