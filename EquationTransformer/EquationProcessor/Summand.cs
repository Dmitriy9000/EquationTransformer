using System;
using System.Text.RegularExpressions;

namespace EquationTransformer.EquationProcessor
{
    public class Summand
    {
        public float Multiplier { get; private set; }
        public int Power { get; private set; }
        public string Variable { get; private set; }

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
                        throw new Exception($"Incorrect summand format: {toParse}");
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
                    Multiplier = -1;
                    remain = remain.Remove(0, 1);
                }
                else
                {
                    Multiplier = 1;
                }

                var regex = new Regex(@"(?<mult>[+|-]?\d?[.]?\d)?(?<v>\w+)?");
                var match = regex.Match(remain);

                if (!match.Success)
                    throw new Exception($"Incorrect summand format: {toParse}");

                if (match.Groups["mult"].Success)
                {
                    var mult = match.Groups["mult"];
                    if (!string.IsNullOrWhiteSpace(match.Groups["mult"].Value))
                    {
                        Multiplier *= float.Parse(match.Groups["mult"].Value);
                    }
                }
                else
                    Multiplier *= 1;

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
            catch (Exception exception)
            {
                throw new Exception($"Incorrect summand format: {toParse}");
            }
        }
    }
}
