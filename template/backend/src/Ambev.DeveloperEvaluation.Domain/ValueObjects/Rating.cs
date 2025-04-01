using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class Rating
    {
        public decimal Rate { get; }

        public int Count { get; }

        public Rating(decimal rate, int count)
        {
            Rate = rate;
            Count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj is Rating rating)
            {
                return Rate == rating.Rate && Count == rating.Count;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rate, Count);
        }
    }
}
