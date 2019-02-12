using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Budget.Models
{
    public class BudgetDay
    {
        public int Id { get; set; }
        [Column(TypeName = "Date"), Index("BudgetDateIndex", IsUnique = true)]
        public DateTime Date { get; set; }
        public decimal Earned { get; set; }
        public decimal Spent { get; set; }
        public bool Logged { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LoggedTime { get; set; }
    }
}