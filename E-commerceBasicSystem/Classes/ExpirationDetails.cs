using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerceBasicSystem.Interfaces;

namespace E_commerceBasicSystem.Classes
{
    public class ExpirationDetails : IExpirable
    {
        public DateTime expiryDate { get; set; }

        public ExpirationDetails(DateTime expiryDate)
        {
            this.expiryDate = expiryDate;
        }

        public void setExpiryDate(DateTime expiryDate)
        {
            this.expiryDate = expiryDate;
        }

        public bool isExpired()
        {
            return DateTime.Now > expiryDate;
        }
    }
}
