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
        [TestMethod]
        public void EstandarizarRestricciones()
        {
            SimplexTService stService = new SimplexTService();

            List<string> cab1 = new List<string> { "X1", "X2" };
            List<double> vec1 = new List<double> { 6, 4 };
            string op1 = "<=";
            double termIndepe1 = 24;

            List<string> cab2 = new List<string> { "X1", "X2" };
            List<double> vec2 = new List<double> { 1, 1 };
            string op2 = ">=";
            double termIndepe2 = 800;

            Restriccion r1 = new Restriccion(cab1,vec1,op1,termIndepe1);
            Restriccion r2 = new Restriccion(cab2,vec2,op2,termIndepe2);

            IEnumerable<RestriccionEstandarizada> result = stService.EstandarizarRestricciones(new List<Restriccion> { r1, r2 });

            result = stService.EstandarizarVector(result);


        }
    }
}
