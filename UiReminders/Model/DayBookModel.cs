using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiReminders.Model
{
    public class DayBookModel
    {
        public DayBookModel(DateTime dateMessage, string message)
        {
            DateMessage = dateMessage;
            Message = message;
        }

        public DayBookModel(int id, DateTime dateMessage, string message) : this(dateMessage, message)
        {
            Id = id;
        }

        /// <summary>
        /// The method that will represent a unique identifier for each text that 
        /// will be entered on a marked day
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This method will generate a time signature for the text
        /// that will be entered on the indicated day</summary>
        public DateTime DateMessage { get; set; }

        /// <summary>
        /// This method will represent the string that will
        /// be entered for a specified day
        /// </summary>
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return $@"Id: {Id}, DateMessage: {DateMessage}, Message: {Message}";
        }
    }
}
