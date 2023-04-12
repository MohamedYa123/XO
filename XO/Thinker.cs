using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public class Thinker
    {
        public int totalBranches=0;
        int absolute(piece piectoput,piece target)
        {
            if(piectoput==target) return 1;
            return -1;
        }
        public int[] FindBest(GameManager gm,piece piecetoput,piece target,int depth, int alpha = int.MinValue, int beta = int.MaxValue)
        {
            if (depth == 0)
            {
                return null;
            }
            int[] best = { 0, 0,0 };
            var ls = gm.getemptySquares();
            int targetInt=(int)target;
            int piecetputInt=(int)piecetoput;
            int alpha2=alpha;
            int beta2=beta; 
            int Topeval = -100;
            if (target != piecetoput)
            {
             //   Topeval = 100;
            }
            foreach(var a in ls) { 
            
                var mg=gm.Clone();
                mg.put(a[0], a[1], piecetoput);
                var z=mg.checkstate();
                var ZInt = (int)z;
                if ((int)z == (int)piecetoput)
                {
                    best[0] = a[0];
                    best[1] = a[1];
                    best[2] = 1;
                    totalBranches++;
                    return best;
                }
                else
                {
                    
                    var next = piece.X;
                    if (piecetoput == piece.X)
                    {
                        next=piece.O;
                    }
                    if (depth != 1)
                    {
                        int xv = FindBest(mg,next, target, depth - 1,alpha2,beta2)[2]*-1;
                        var sxv = xv * absolute(piecetoput, target);
                        if (( xv > Topeval) )
                        {
                            best[0] = a[0];
                            best[1] = a[1];
                            Topeval = xv;
                            best[2]= xv;
                        }
                        if (piecetoput == target)
                        {
                            if (beta <= sxv)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (alpha >= sxv)
                            {
                                break;
                            }

                        }
                        if (piecetoput == target&&sxv>alpha2)
                        {
                            alpha2 = sxv;
                        }
                        else if (piecetoput != target && sxv < beta2)
                        {
                            beta2 = sxv;
                        }
                        if (Topeval == 1)
                        {
                            totalBranches++;
                            return best;
                        }
                        continue;
                    }
                    totalBranches++;
                   // best[2] = ZInt;
                    if (( ZInt > Topeval))
                    {
                        best[2] = ZInt;
                        Topeval = ZInt;
                    }
                    if (ZInt != 0)
                    {
                    //    break;
                    }
                }

            }
            return best;
        }
    }
}
