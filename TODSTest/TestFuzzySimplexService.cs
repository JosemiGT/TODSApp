﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODSLibreria;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.FuzzySimplexService;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexSpine;

namespace TODSTest
{
    [TestClass]
    public class TestFuzzySimplexService
    {
        //public static readonly List<string> cab = new List<string> { "X1", "X2", "X3" };

        //public static readonly List<TRFN> foNum = new List<TRFN> { new TRFN(Constantes.NDType.AlfaBetaType, 13, 15, 2, 2),
        //                                                        new TRFN(Constantes.NDType.AlfaBetaType, 12, 14, 3, 3),
        //                                                        new TRFN(Constantes.NDType.AlfaBetaType, 15, 17, 2, 2) };

        //public static readonly List<double> vec1 = new List<double> { 12, 13, 12 };
        //public static readonly List<double> vec2 = new List<double> { 14, 0, 13 };
        //public static readonly List<double> vec3 = new List<double> { 12, 15, 0 };
        //public static readonly TRFN termIndepe1 = new TRFN(Constantes.NDType.AlfaBetaType, 475, 505, 6, 6);
        //public static readonly TRFN termIndepe2 = new TRFN(Constantes.NDType.AlfaBetaType, 460, 480, 8, 8);
        //public static readonly TRFN termIndepe3 = new TRFN(Constantes.NDType.AlfaBetaType, 465, 495, 5, 5);

        //public static readonly FuzzyConstraint r1 = new FuzzyConstraint("S1",cab, vec1, Constantes.MenorIgual, termIndepe1);
        //public static readonly FuzzyConstraint r2 = new FuzzyConstraint("S2",cab, vec2, Constantes.MenorIgual, termIndepe2);
        //public static readonly FuzzyConstraint r3 = new FuzzyConstraint("S3",cab, vec3, Constantes.MenorIgual, termIndepe3);

        //public static readonly List<FuzzyConstraint> fuzzyConstraint = new List<FuzzyConstraint> { r1, r2, r3 };

        //[TestMethod]
        //public void FuzzySimplex()
        //{
        //    FuzzyPrimalSimplexService service = new FuzzyPrimalSimplexService();

        //    List<FuzzyVectorEquation> constraints = service.StandardizeConstraints(fuzzyConstraint).ToList();

        //    FuzzyObjectiveFunction fo = new FuzzyObjectiveFunction(cab, foNum, new TRFN(0), true);

        //    bool isCorrect = service.StandardizeObjectiveFunction(constraints, ref fo);

        //    FuzzyTableau tableau = new FuzzyTableau(constraints, fo);

        //    isCorrect = service.Pivoting(ref tableau, out KeyValuePair<string, double> variableMinima, out KeyValuePair<string, double> pivote);
        //    isCorrect = service.ReduceColumns(ref tableau, pivote, variableMinima.Key);

        //}

        [TestMethod]
        public void FuzzySimplexAnddata()
        {
            string path = @"C:\Users\josa.gamarro.tornay\Desktop\Test\FuzzyLPTProblem.xlsx";
            SimplexSpine spine = new SimplexSpine(path, new Config());

            //spine.ExecuteSimplexSpine(Constantes.FuzzyPrimalSimplex, "FuzzyTest");
            //spine.ExecuteSimplexSpine(Constantes.FuzzyPrimalSimplex, "FuzzyInitialTest");
            //spine.ExecuteSimplexSpine(Constantes.FuzzyPrimalSimplex, "FuzzyTransportTestMin");
            //spine.ExecuteSimplexSpine(Constantes.FuzzyPrimalSimplex, "FuzzyTransportTest");
            spine.ExecuteSimplexSpine(Constantes.FuzzyPrimalSimplex, "ModeloTransporteDifuso");
        }

        [TestMethod]
        public void FuzzyOperationsBody()
        {
            TRFNOperation fop = new TRFNOperation();

            List<TRFN> L1 = new List<TRFN> { new TRFN(Constantes.NDType.AlfaBetaType, -15, -13, 2, 2),
                                             new TRFN(Constantes.NDType.AlfaBetaType, -14, -12, 3, 3),
                                             new TRFN(Constantes.NDType.AlfaBetaType, -17, -15, 2, 2) };

            List<double> L2 = new List<double> { 1.076923077, 0, 1, 0, 0.07692307692, 0 };

            TRFN referencia = new TRFN(Constantes.NDType.AlfaBetaType, -17, -15, 2, 2);

            List<TRFN> L3 = fop.OperateFuzzyConstant(L2, Constantes.Multiplicacion, referencia).ToList();

            List<TRFN> result = fop.ReduceFuzzyRows(L1, L3).ToList();



        }

        [TestMethod]
        public void FuzzyOperationsFO()
        {
            TRFNOperation fop = new TRFNOperation();

            TRFN n1 = new TRFN(Constantes.NDType.AlfaBetaType, 15, 17, 2, 2);
            TRFN n2 = new TRFN(Constantes.NDType.AlfaBetaType, 460, 480, 8, 8);

            n2 = fop.OperateConstant(n2, Constantes.Division, 13);
            //n2 = fop.MakeNegative(n2);

            TRFN result = fop.Multiplication(n1, n2);
            //result = fop.OperateConstant(result, Constantes.Division, 13);
            //result = fop.MakeNegative(result);

        }

        [TestMethod]
        public void GetFuzzyParameter()
        {
            string path = @"C:\Users\josa.gamarro.tornay\Desktop\Test\FuzzyLPTProblem.xlsx";
            ConectorDatosApp conector = new ConectorDatosApp();
            conector.GetFuzzyParameter(path, "FuzzyParameter", out List<FuzzyParameter> fuzzyParameter);

        }
    }
}
