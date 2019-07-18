using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;

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

        public static readonly Restriccion r1 = new Restriccion(cab, vec1, menorIgual, termIndepe1);
        public static readonly Restriccion r2 = new Restriccion(cab, vec2, mayorIgual, termIndepe2);

        public static readonly List<Restriccion> restricciones = new List<Restriccion> { r1, r2 };
        public const double termIndepe1 = 24;
        public const double termIndepe2 = 800;



        FuncionObjetivo FO = new FuncionObjetivo(cab, fo, true);

        [TestMethod]
        public void EstandarizarRestricciones()
        {
            SimplexTService stService = new SimplexTService();

            IEnumerable<RestriccionEstandarizada> result = stService.EstandarizarRestricciones(restricciones);

            result = stService.EstandarizarVector(result);

            TablaSimplex ts = new TablaSimplex(FO, result);

            stService.PivotarTSimplex(ref ts);
        }

        [TestMethod]
        public void TablaSimplexTest()
        {
            SimplexTService stService = new SimplexTService();


        }
    }
}
