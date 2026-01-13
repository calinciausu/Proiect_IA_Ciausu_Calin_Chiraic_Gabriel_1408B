using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BayesianInference
{
    public class Node
    {
        public string Name { get; set; }
        public List<string> ParentNames { get; set; } = new List<string>();

        public List<double> Probabilities { get; set; } = new List<double>();

        public double GetProbability(bool value, Dictionary<string, bool> evidence)
        {
            double pTrue;

            if (ParentNames.Count == 0)
            {
                pTrue = Probabilities[0];
            }
            else
            {
                int index = 0;
                foreach (var parent in ParentNames)
                {
                    bool parentVal = evidence[parent];
                    index = (index << 1) | (parentVal ? 1 : 0);
                }
                pTrue = Probabilities[index];
            }

            return value ? pTrue : (1.0 - pTrue);
        }
    }

    public class BayesianNet
    {
        public List<Node> Nodes { get; private set; } = new List<Node>();
        public List<string> VariableNames => Nodes.Select(n => n.Name).ToList();

        public void LoadFromFile(string filePath)
        {
            Nodes.Clear();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                var parts = line.Split(';');
                var node = new Node();

                foreach (var part in parts)
                {
                    var segment = part.Trim();
                    if (segment.StartsWith("Nod:"))
                    {
                        node.Name = segment.Substring(4).Trim();
                    }
                    else if (segment.StartsWith("Parinti:"))
                    {
                        var parentsStr = segment.Substring(8).Trim();
                        if (!parentsStr.Equals("None", StringComparison.OrdinalIgnoreCase))
                        {
                            node.ParentNames = parentsStr.Split(',').Select(p => p.Trim()).ToList();
                        }
                    }
                    else if (segment.StartsWith("Prob:"))
                    {
                        var valStr = segment.Substring(5).Trim();
                        node.Probabilities.Add(double.Parse(valStr, CultureInfo.InvariantCulture));
                    }
                    else if (segment.StartsWith("CPT:"))
                    {
                        var arrayStr = segment.Substring(4).Trim().Trim('[', ']');
                        var vals = arrayStr.Split(',').Select(v => double.Parse(v, CultureInfo.InvariantCulture));
                        node.Probabilities.AddRange(vals);
                    }
                }
                Nodes.Add(node);
            }
        }


        public static double[] EnumerationAsk(string X, Dictionary<string, bool> e, BayesianNet bn)
        {
            var Q = new double[2]; 

            var eTrue = new Dictionary<string, bool>(e);
            eTrue[X] = true;
            double pTrue = EnumerateAll(bn.Nodes, eTrue);

            var eFalse = new Dictionary<string, bool>(e);
            eFalse[X] = false;
            double pFalse = EnumerateAll(bn.Nodes, eFalse);

            double sum = pTrue + pFalse;
            return new double[] { pTrue / sum, pFalse / sum };
        }

        public static double EnumerateAll(List<Node> vars, Dictionary<string, bool> e)
        {
            if (vars.Count == 0) return 1.0;

            var Y = vars[0];
            var rest = vars.Skip(1).ToList();

            if (e.ContainsKey(Y.Name))
            {
                double probY = Y.GetProbability(e[Y.Name], e);
                return probY * EnumerateAll(rest, e);
            }
            else
            {

                var eTrue = new Dictionary<string, bool>(e);
                eTrue[Y.Name] = true;
                double term1 = Y.GetProbability(true, eTrue) * EnumerateAll(rest, eTrue);

                var eFalse = new Dictionary<string, bool>(e);
                eFalse[Y.Name] = false;
                double term2 = Y.GetProbability(false, eFalse) * EnumerateAll(rest, eFalse);

                return term1 + term2;
            }
        }
    }

   
}

