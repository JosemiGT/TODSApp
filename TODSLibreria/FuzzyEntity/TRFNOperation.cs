using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.FuzzyEntity
{
    public class TRFNOperation
    {
        public TRFN Addition(TRFN N1, TRFN N2)
        {
            return new TRFN(Constantes.NDType.AlfaBetaType, N1.L + N2.L, N1.U + N2.U, N1.Alfa + N2.Alfa, N1.Beta + N2.Beta);
        }

        public TRFN Subtraction(TRFN N1, TRFN N2)
        {
            return new TRFN(Constantes.NDType.AlfaBetaType, N1.L - N2.L, N1.U - N2.U, N1.Alfa + N2.Alfa, N1.Beta + N2.Beta);
        }

        public TRFN Multiplication(TRFN N1, TRFN N2)
        {
            OperacionesNumericas opn = new OperacionesNumericas();
            double t = (tmult(N1, N2).Max() - tmult(N1, N2).Min()) / 2;
            double ab = opn.ValorAbsoluto((N1.U * N2.Alfa) + opn.ValorAbsoluto(N2.U * N1.Alfa));
            return new TRFN(Constantes.NDType.AlfaBetaType, opn.Media(N1.L, N1.U)*opn.Media(N2.L, N2.U) - t, opn.Media(N1.L, N1.U) * opn.Media(N2.L, N2.U) + t, opn.ValorAbsoluto(ab), opn.ValorAbsoluto(ab));
        }

        public TRFN MakeNegative(TRFN N)
        {
            return (N != null) ? new TRFN(Constantes.NDType.AlfaBetaType, -N.U, -N.L, N.Alfa, N.Beta) : null;
        }

        public TRFN OperateConstant(TRFN N, string op, double constant)
        {
            switch (op)
            {
                case Constantes.Suma: return new TRFN(Constantes.NDType.AlfaBetaType ,N.L + constant, N.U + constant, N.Alfa + constant, N.Beta + constant);
                case Constantes.Resta: return new TRFN(Constantes.NDType.AlfaBetaType, N.L - constant, N.U - constant, N.Alfa - constant, N.Beta - constant);
                case Constantes.Multiplicacion: return new TRFN(Constantes.NDType.AlfaBetaType, N.L * constant, N.U * constant, N.Alfa * constant, N.Beta * constant);
                case Constantes.Division: return (constant != 0) ? (new TRFN(Constantes.NDType.AlfaBetaType, N.L / constant, N.U / constant, N.Alfa / constant, N.Beta / constant)) : null; 
                default: return null;
            }
        }

        public TRFN Rest(TRFN N1, TRFN N2)
        {
            return !(IsEquivalent(N1,N2)) ? Addition(N1, MakeNegative(N2)) : new TRFN(0);
        }

        public double OperateConstant(double n1, string op, double n2)
        {
            switch (op)
            {
                case Constantes.Suma: return n1 + n2;
                case Constantes.Resta: return n1 - n2;
                case Constantes.Multiplicacion: return n1 * n2;
                case Constantes.Division: return n1 / n2;
                default: return new double();
            }

        }

        public IEnumerable<TRFN> OperateConstant(IEnumerable<TRFN> ListN, string op, double constant)
        {
            return ListN.Select(x => (x != null) ? OperateConstant(x, op, constant):null).ToList();
        }

        public IEnumerable<double> OperateConstant(IEnumerable<double> ListN, string op, double constant)
        {
            return ListN.Select(x => OperateConstant(x, op, constant)).ToList();
        }

        public IEnumerable<TRFN> OperateFuzzyConstant(IEnumerable<double> ListN, string op, TRFN constant)
        {
            return ListN.Select(x => OperateConstant(constant, op, x)).ToList();
        }

        public IEnumerable<TRFN> Operate(IEnumerable<TRFN> ListN1, string op, IEnumerable<double> ListN2)
        {
            return ListN1.Zip(ListN2, (x, y) => OperateConstant(x, op, y));
        }

        public IEnumerable<double> Operate(IEnumerable<double> ListN1, string op, IEnumerable<double> ListN2)
        {
            return ListN1.Zip(ListN2, (x, y) => OperateConstant(x, op, y));
        }

        public bool IsEquivalent(TRFN N1, TRFN N2)
        {
            return ((N1.L + N1.U) / 2 == (N2.L + N2.U) / 2);
        }

        public IEnumerable<TRFN> ReduceFuzzyRows(IEnumerable<TRFN> Flist1, IEnumerable<TRFN> Flist2)
        {
            return Flist1.Zip(Flist2, (x, y) => Rest(x, y));
        }

        public IEnumerable<TRFN> AdditionFuzzyRows(IEnumerable<TRFN> Flist1, IEnumerable<TRFN> Flist2)
        {
            return Flist1.Zip(Flist2, (x, y) => Addition(x, y));
        }

        private IEnumerable<double> tmult(TRFN N1, TRFN N2)
        {
            return new double[4] { N1.L * N2.L, N1.L * N2.U, N1.U * N2.L, N1.U * N2.U };
        }

        

    }
}
