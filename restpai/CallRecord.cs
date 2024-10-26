using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class CallRecord
    {
        public int Id { get; set; }
        public DateTime CallDate { get; set; } // Дата разговора
        public string OwnerName { get; set; } // ФИО владельца
        public string CityCode { get; set; } // Код города
        public int DurationInMinutes { get; set; } // Продолжительность разговора
        public decimal TotalCost { get; set; } // Общая стоимость разговора
    }
}