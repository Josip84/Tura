using DBEntities.Entities.Users;
using DBEntities.Entities.Vehicles;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntities.Entities.Tours
{
    public class Tours
    {
        [Key]
        public Guid UID { get; set; }
        public int TourNumber { get; set; }
        public string TourMark {  get; set; }
        public DateOnly TourDate { get; set; }
        public string Permissions { get; set; }
        public Vehicle Vechicle1ID { get; set; }
        public Vehicle Vechicle2ID { get; set; }
        public int LPostalNumber { get; set; }
        public string LCityTown {  get; set; }
        public string LCountry { get; set; }
        public int UPostalNumber { get; set; }
        public string UCityTown { get; set; }
        public string UCountry { get; set; }
        public string CustomerName {  get; set; }
        public double Price { get; set; }
        public string? InvoiceNumber { get; set; }
        public double DebtAmount { get; set; }
        public bool Received { get; set; }
        public bool IPR { get; set; }
        public bool InvoniceIssued { get; set; }
        public bool Return { get; set; }
        public string? Remark { get; set; }
        public bool MonthlyPayer { get; set; }
        public User Employee { get; set; }
        public User EmployeeIPR { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
