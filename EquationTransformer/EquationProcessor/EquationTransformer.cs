using System;
using System.Collections.Generic;
using System.Linq;

namespace EquationTransformer.EquationProcessor
{
    public class EquationTransformer
    {
        public Equation Tranform(Equation input)
        {
            var transfered = TransferSummandsToLeft(input);
            var result = Compact(transfered);
            return result;
        }

        private Equation TransferSummandsToLeft(Equation eq)
        {
            var newList = new List<Summand>();
            newList.AddRange(eq.Left);
            foreach (var rs in eq.Right)
            {
                newList.Add(new Summand(rs.Multiplier, rs.Power, rs.Variable, !rs.IsPositive));
            }
            return new Equation(newList, new List<Summand>());
        }

        private Equation Compact(Equation input)
        {
            var grouped = input.Left.GroupBy(c => new { c.Variable, c.Power });
            var compacted = new List<Summand>();
            foreach (var g in grouped)
            {
                var multiplier = g.Sum(f => f.IsPositive ? f.Multiplier : -f.Multiplier);
                if (multiplier != 0)
                {
                    compacted.Add(new Summand(Math.Abs(multiplier), g.Key.Power, g.Key.Variable, multiplier >= 0));
                }
            }
            var result = new Equation(compacted, new List<Summand>());
            return result;
        }
    }
}
