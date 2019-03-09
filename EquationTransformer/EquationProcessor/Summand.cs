using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EquationTransformer.EquationProcessor
{
    public class Summand
    {
        public float Multiplier { get; private set; }
        public int Power { get; private set; }
        public string Variable { get; private set; }
        public bool IsPositive { get; private set; }

        public Summand(string toParse)
        {
            try
            {
                // Power parsing
                var remain = toParse;
                if (toParse.Contains("^"))
                {
                    var powerParts = remain.Split('^');
                    if (powerParts.Length != 2)
                    {
                        throw new EquationException($"Incorrect summand format: {toParse}");
                    }
                    remain = powerParts[0];
                    Power = int.Parse(powerParts[1]);
                }
                else
                {
                    Power = 1;
                }

                // Multiplier & Variable parsing
                remain = remain.Replace("(", string.Empty);
                remain = remain.Replace(")", string.Empty);

                if (remain[0] == '-')
                {
                    IsPositive = false;
                    remain = remain.Remove(0, 1);
                }
                else
                {
                    IsPositive = true;
                }

                var regex = new Regex(@"(?<mult>[+|-]?\d?[.]?\d)?(?<v>\w+)?");
                var match = regex.Match(remain);

                if (!match.Success)
                    throw new EquationException($"Incorrect summand format: {toParse}");

                if (match.Groups["mult"].Success)
                {
                    var mult = match.Groups["mult"];
                    if (!string.IsNullOrWhiteSpace(match.Groups["mult"].Value))
                    {
                        Multiplier = float.Parse(match.Groups["mult"].Value);
                    }
                }
                else
                {
                    Multiplier = 1;
                }

                if (match.Groups["v"].Success)
                {
                    if (string.IsNullOrWhiteSpace(match.Groups["v"].Value))
                    {
                        Variable = string.Empty;
                    }
                    else
                    {
                        Variable = match.Groups["v"].Value;
                    }
                }
                else
                    Variable = string.Empty;
            }
            catch (Exception)
            {
                throw new EquationException($"Incorrect summand format: {toParse}");
            }
        }

        public Summand(float multiplier, int power, string variable, bool isPositive)
        {
            Multiplier = multiplier;
            Power = power;
            Variable = variable;
            IsPositive = isPositive;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Multiplier != 1 || (Multiplier == 1 && Variable == string.Empty))
            {
                sb.Append(Multiplier);
            }

            if (Variable != string.Empty)
            {
                if (Variable.Length > 1 && Power != 1)
                {
                    sb.Append($"({Variable})");
                }
                else
                {
                    sb.Append($"{Variable}");
                }

                if (Power != 1)
                {
                    sb.Append($"^{Power}");
                }
            }
            return sb.ToString();
        }
    }
}
