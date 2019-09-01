using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.FuzzySimplexService
{
    public class DataManagement
    {
        public IDictionary<string, double> OrderDictionaryByVariable(IDictionary<string, double> dictionary)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            if (dictionary != null && dictionary.Count() > 0)
            {
                foreach (KeyValuePair<string, double> item in dictionary.Where(d => d.Key.Contains("X")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
                foreach (KeyValuePair<string, double> item in dictionary.Where(d => d.Key.Contains("S")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
                foreach (KeyValuePair<string, double> item in dictionary.Where(d => d.Key.Contains("e")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
                foreach (KeyValuePair<string, double> item in dictionary.Where(d => d.Key.Contains("A")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
            }

            return result;
        }

        public IDictionary<string, TRFN> OrderDictionaryByVariable(IDictionary<string, TRFN> dictionary)
        {
            Dictionary<string, TRFN> result = new Dictionary<string, TRFN>();

            if (dictionary != null && dictionary.Count() > 0)
            {
                foreach (KeyValuePair<string, TRFN> item in dictionary.Where(d => d.Key.Contains("X")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
                foreach (KeyValuePair<string, TRFN> item in dictionary.Where(d => d.Key.Contains("S")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
                foreach (KeyValuePair<string, TRFN> item in dictionary.Where(d => d.Key.Contains("e")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
                foreach (KeyValuePair<string, TRFN> item in dictionary.Where(d => d.Key.Contains("A")).OrderBy(d => d.Key).ToDictionary(x => x.Key, x => x.Value)) result.Add(item.Key, item.Value);
            }

            return result;
        }

        public IEnumerable<IDictionary<string, double>> OrderDictionaryByVariable(IEnumerable<IDictionary<string, double>> listD)
        {
            List<Dictionary<string, double>> result = new List<Dictionary<string, double>>();

            if(listD != null && listD.Count() > 0) foreach(IDictionary<string, double> dicts in listD) result.Add(OrderDictionaryByVariable(dicts).ToDictionary(x => x.Key, x => x.Value));
            
            return result;
        }

        public IEnumerable<IDictionary<string, TRFN>> OrderDictionaryByVariable(IEnumerable<IDictionary<string, TRFN>> listD)
        {
            List<Dictionary<string, TRFN>> result = new List<Dictionary<string, TRFN>>();

            if (listD != null && listD.Count() > 0) foreach (IDictionary<string, TRFN> dicts in listD) result.Add(OrderDictionaryByVariable(dicts).ToDictionary(x => x.Key, x => x.Value));

            return result;
        }

        public VectorEquation OrderDictionaryByVariable(VectorEquation equation)
        {
            return new VectorEquation(equation.Nombre, OrderDictionaryByVariable(equation.CuerpoVector), equation.TerminoIndependiente);
        }

        public FuzzyVectorEquation OrderDictionaryByVariable(FuzzyVectorEquation equation)
        {
            if (equation.Vector != null) return new FuzzyVectorEquation(equation.Name, OrderDictionaryByVariable(equation.Vector), equation.IndependentTerm);
            else return new FuzzyVectorEquation(equation.Name, OrderDictionaryByVariable(equation.FuzzyVector), equation.IndependentTerm);
        }

        public FuzzyObjectiveFunction OrderDictionaryByVariable(FuzzyObjectiveFunction equation)
        {
            return new FuzzyObjectiveFunction(equation.Name, OrderDictionaryByVariable(equation.FuzzyVector), equation.IndependentTerm, equation.IsMax);
        }

        public IEnumerable<FuzzyVectorEquation> OrderDictionaryByVariable(IEnumerable<FuzzyVectorEquation> equationlist)
        {
            List<FuzzyVectorEquation> result = new List<FuzzyVectorEquation>();

            if (equationlist != null && equationlist.Count() > 0) foreach (FuzzyVectorEquation equation in equationlist) result.Add(OrderDictionaryByVariable(equation));

            return result;
        }

        public IEnumerable<VectorEquation> OrderDictionaryByVariable(IEnumerable<VectorEquation> equationlist)
        {
            List<VectorEquation> result = new List<VectorEquation>();

            if (equationlist != null && equationlist.Count() > 0) foreach (VectorEquation equation in equationlist) result.Add(OrderDictionaryByVariable(equation));

            return result;
        }
    }
}
