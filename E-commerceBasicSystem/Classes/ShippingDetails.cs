using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerceBasicSystem.Interfaces;

namespace E_commerceBasicSystem.Classes
{
    public class ShippingDetails : IShippable
    {
        public double weight { get; set; }

        public ShippingDetails(double weight)
        {
            this.weight = weight;
        }

        public void setWeight(double weight)
        {
            this.weight = weight;
        }

        public double getWeight()
        {
            return weight;
        }
    }
}
