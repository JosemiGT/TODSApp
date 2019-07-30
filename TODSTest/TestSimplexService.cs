using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;
using TODSLibreria.SimplexSpine;

namespace TODSTest
{
    [TestClass]
    public class TestSimplexService
    {

        public const string menorIgual = "<=";
        public const string mayorIgual = ">=";

        public static readonly List<string> cab = new List<string> { "X1", "X2" };
        public static readonly List<double> fo = new List<double> { 100, 125 };
        public static readonly List<double> vec1 = new List<double> { 6, 4 };
        public static readonly List<double> vec2 = new List<double> { 1, 1 };

        public static readonly Constraint r1 = new Constraint("S1",cab, vec1, menorIgual, termIndepe1);
        public static readonly Constraint r2 = new Constraint("S2", cab, vec2, mayorIgual, termIndepe2);

        public static readonly List<Constraint> restricciones = new List<Constraint> { r1, r2 };
        public const double termIndepe1 = 24;
        public const double termIndepe2 = 800;



        ObjectiveFunction FO = new ObjectiveFunction(cab, fo, true);

        [TestMethod]
        public void EstandarizarRestricciones()
        {
            SimplexTService stService = new SimplexTService();

            IEnumerable<StandardConstraint> result = stService.EstandarizarRestricciones(restricciones);

            result = stService.EstandarizarVector(result);

            if(stService.EstandarizarFuncionObjetivo(result, ref FO))
            {
                Tableau ts = new Tableau(FO, result);

                stService.PivotarTSimplex(ref ts, out KeyValuePair<string, double> variableMinima, out KeyValuePair<string, double> pivote);
                stService.ReducirColumnas(ref ts, pivote, variableMinima.Key);

            }
        }

        [TestMethod]
        public void Operaciones()
        {
            OperacionesVectoriales ov = new OperacionesVectoriales();

            List<double> r1 = new List<double> { 1, 2, 3 };
            List<double> r2 = new List<double> { 1, 2, 3 };

            List<double> s = new List<double>(ov.OperacionV1parametroV2(r1, "/", 2, r2));

            List<double> s2 = r1.Zip(r2, (x, y) => x + y).ToList();

        }

        [TestMethod]
        public void Simplex()
        {
            string path = @"C:\Users\josa.gamarro.tornay\Desktop\Test\Test.xlsx";

            SimplexSpineLogic simplex = new SimplexSpineLogic(path);
            simplex.EjecutarBasicSimplex("Test");
        }
    }
}
