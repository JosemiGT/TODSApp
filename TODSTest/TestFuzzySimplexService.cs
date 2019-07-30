using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODSLibreria;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.FuzzySimplexService;
using TODSLibreria.SimplexEntity;

namespace TODSTest
{
    [TestClass]
    public class TestFuzzySimplexService
    {
        public static readonly List<string> cab = new List<string> { "X1", "X2", "X3" };

        public static readonly List<TRFN> foNum = new List<TRFN> { new TRFN(Constantes.NDType.AlfaBetaType, 13, 15, 2, 2),
                                                                new TRFN(Constantes.NDType.AlfaBetaType, 12, 14, 3, 3),
                                                                new TRFN(Constantes.NDType.AlfaBetaType, 15, 17, 2, 2) };
        
        public static readonly List<double> vec1 = new List<double> { 12, 13, 12 };
        public static readonly List<double> vec2 = new List<double> { 14, 0, 13 };
        public static readonly List<double> vec3 = new List<double> { 12, 15, 0 };
        public static readonly TRFN termIndepe1 = new TRFN(Constantes.NDType.AlfaBetaType, 475, 505, 6, 6);
        public static readonly TRFN termIndepe2 = new TRFN(Constantes.NDType.AlfaBetaType, 460, 480, 8, 8);
        public static readonly TRFN termIndepe3 = new TRFN(Constantes.NDType.AlfaBetaType, 465, 495, 5, 5);

        public static readonly FuzzyConstraint r1 = new FuzzyConstraint("S1",cab, vec1, Constantes.MenorIgual, termIndepe1);
        public static readonly FuzzyConstraint r2 = new FuzzyConstraint("S2",cab, vec2, Constantes.MenorIgual, termIndepe2);
        public static readonly FuzzyConstraint r3 = new FuzzyConstraint("S3",cab, vec3, Constantes.MenorIgual, termIndepe3);

        public static readonly List<FuzzyConstraint> fuzzyConstraint = new List<FuzzyConstraint> { r1, r2, r3 };

        [TestMethod]
        public void FuzzySimplex()
        {
            FuzzyPrimalSimplexService service = new FuzzyPrimalSimplexService();

            List<FuzzyVectorEquation> constraints = service.StandardizeConstraints(fuzzyConstraint).ToList();

            FuzzyObjectiveFunction fo = new FuzzyObjectiveFunction(cab, foNum, new TRFN(0), true);

            bool isCorrect = service.StandardizeObjectiveFunction(constraints, ref fo);

            FuzzyTableau tableau = new FuzzyTableau(constraints, fo);

            isCorrect = service.Pivoting(ref tableau, out KeyValuePair<string, double> variableMinima, out KeyValuePair<string, double> pivote);
            isCorrect = service.ReduceColumns(ref tableau, pivote, variableMinima.Key);

        }
    }
}
