using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceBasicSystem.Interfaces
{
    public interface IExpirable
    {
        public DateTime expiryDate { get; set; }
        void setExpiryDate(DateTime expiryDate);
        bool isExpired();
    }
}
