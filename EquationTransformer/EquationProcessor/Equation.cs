using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquationTransformer.EquationProcessor
{
    public class Equation
    {
        public List<Summand> Left { get; private set; }
        public List<Summand> Right { get; private set; }

        public Equation(string equation)
        {
            if (equation.IndexOf('=') == -1)
                throw new EquationException($"Invalid equation: {equation}");

            var parts = equation.Split('=');

            if (parts.Length != 2)
                throw new EquationException($"Invalid equation: {equation}");

            var leftString = parts[0];
            var rightString = parts[1];

            Left = ParseEquationSide(leftString);
            Right = ParseEquationSide(rightString);
        }

        public Equation(List<Summand> left, List<Summand> right)
        {
            Left = SortSummands(left);
            Right = SortSummands(right);
        }

        private List<Summand> ParseEquationSide(string input)
        {
            var parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i] == "-")
                {
                    parts[i + 1] = "-" + parts[i + 1];
                }
            }
            var signs = new[] { "+", "-" };
            var summandStrings = parts.Where(c => !signs.Contains(c)).ToArray();

            var summands = summandStrings.Select(c => new Summand(c));
            return SortSummands(summands);
        }

        private List<Summand> SortSummands(IEnumerable<Summand> input)
        {
            return input
                .OrderByDescending(c => c.Power)
                .ThenByDescending(c => c.Variable.Length)
                .ToList();
        }

        public override string ToString()
        {
            var leftSide = EquationSideToString(Left);
            var rightSide = EquationSideToString(Right);
            return $"{leftSide} = {rightSide}";
        }

        private string EquationSideToString(IList<Summand> summands)
        {
            var s = "0";
            if (summands.Count > 0)
            {
                var sb = new StringBuilder();
                for (var i = 0; i < summands.Count; i++)
                {
                    var summand = summands[i];
                    if (i != 0)
                    {
                        if (summand.IsPositive)
                        {
                            sb.Append($" + {summand}");
                        }
                        else
                        {
                            sb.Append($" - {summand}");
                        }
                    }
                    else
                    {
                        if (summand.IsPositive)
                        {
                            sb.Append(summand);
                        }
                        else
                        {
                            sb.Append($" -{summand}");
                        }
                    }
                }
                s = sb.ToString();
            }
            return s;
        }
    }
}
