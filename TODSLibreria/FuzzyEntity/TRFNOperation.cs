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
            double ab = (N1.U * N2.Alfa + N2.U * N2.Alfa);
            return new TRFN(Constantes.NDType.AlfaBetaType, opn.Media(N1.L, N1.U)*opn.Media(N2.L, N2.U) - t, opn.Media(N1.L, N1.U) * opn.Media(N2.L, N2.U) + t, opn.ValorAbsoluto(ab), opn.ValorAbsoluto(ab));
        }

        public TRFN MakeNegative(TRFN N)
        {
            return (N != null) ? new TRFN(Constantes.NDType.AlfaBetaType, -N.U, -N.L, N.Alfa, N.Beta) : null;
        }

        public bool IsEquivalent(TRFN N1, TRFN N2)
        {
            return ((N1.L + N1.U) / 2 == (N2.L + N2.U) / 2);
        }

        private IEnumerable<double> tmult(TRFN N1, TRFN N2)
        {
            return new double[4] { N1.L + N2.L, N1.L + N2.U, N1.U + N2.L, N1.U + N2.U };
        }

    }
}
