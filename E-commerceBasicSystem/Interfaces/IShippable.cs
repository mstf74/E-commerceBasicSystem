using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceBasicSystem.Interfaces
{
    public interface IShippable
    {
        public double weight { get; set; }
        void setWeight(double weight);
        double getWeight();
    }
}
