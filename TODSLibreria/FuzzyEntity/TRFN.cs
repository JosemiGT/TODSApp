using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.FuzzyEntity
{
    /// <summary>
    /// Trapezoidal Fuzzy Number
    /// </summary>
    public class TRFN
    {
        #region Prop

        public double A1 { get; }
        public double A2 { get; }
        public double A3 { get; }
        public double A4 { get; }
        public IEnumerable<double> TRFNnumType { get { return new double[4] { A1, A2, A3, A4 }; } }


        public double L { get; }
        public double U { get; }
        public double Alfa { get; }
        public double Beta { get; }
        public IEnumerable<double> TRFNABType { get { return new double[4] { L, U, Alfa, Beta }; } }


        public bool isValide { get { return (A1 <= A2 && A2 <= A3 && A3 <= A4); } }
        public bool isSymmetric { get { return (Beta == Alfa); } }
        #endregion

        #region Constructors
        public TRFN(Constantes.NDType nDType, double a1, double a2, double a3alf, double a4bet)
        {
            if(nDType == Constantes.NDType.AlfaBetaType) { this.L = a1; this.U = a2; this.Alfa = a3alf; this.Beta = a4bet; this.A2 = a1; this.A3 = a2; this.A1 = a1 - a3alf; this.A4 = a2 + a4bet; }
            else if(nDType == Constantes.NDType.NumType) { this.A1 = a1; this.A2 = a2; this.A3 = a3alf; this.A4 = a4bet; this.L = a2; this.U = a3alf; this.Alfa = a2 - a1; this.Beta = a4bet - a3alf; }
        }

        public TRFN(double n)
        {
            new TRFN(Constantes.NDType.AlfaBetaType, n, n, 0, 0);
        }
        #endregion

        #region PrivateMethod

        #endregion
    }
}
