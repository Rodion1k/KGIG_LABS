namespace Lp_Lab01
{
    public class CChildView
    {
        public CMatrix A;
        public CMatrix B;
        public CMatrix V1;
        public CMatrix V2;

        public CChildView()
        {
            A = new CMatrix(3, 3);
            B = new CMatrix(3, 3);
            V1 = new CMatrix(3, 1);
            V2 = new CMatrix(3, 1);
            LibGraph.InitMatrix(A);
            LibGraph.InitMatrix(B);
            LibGraph.InitMatrix(V1);
            LibGraph.InitMatrix(V2);
        }
    }
}