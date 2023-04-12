using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public class GameManager
    {
        public int[,] squares;
        int w = 0;
        int h = 0;
        int winnum;
       
        public GameManager(int x,int y,int winnum) {
            w = x;h= y;
            squares= new int[x,y];  
            this.winnum = winnum;
        }
        public GameManager Clone()
        {
            GameManager mg= new GameManager(w,h,winnum);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    mg.squares[i, j] = squares[i,j];
                }
            }
            return mg;
        }
        public List<int[]> getemptySquares()
        {
            List<int[]> sqrs= new List<int[]>();
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (squares[i, j] == 0)
                    {
                        int[] z = { i, j };
                        sqrs.Add(z);
                    }
                }
            }
            return sqrs;
          }
        public void put(int x,int y,piece p) {
            if (squares[x, y] == 0)
            {
                squares[x, y]= (int)p;
            }
            else
            {
                throw new Exception("Already exists");
            }
        }
        public state checkstate()
        {
            for(int i=0;i<w;i++)
            {
                for(int j = 0; j < h; j++)
                {
                    if (i == 2)
                    {

                    }
                    var f = CheckSquare(i, j);
                    if (f!=state.None)
                    {
                        return f;
                    }
                }
            }
            return state.None;
        }
        state CheckSquare(int x,int y)
        {
            state st = state.None;
            var a = squares[x, y];
            if (a == 0)
            {
                return st;
            }
            var win = state.X_wins;
            if ((piece)a == piece.O)
            {
                win = state.O_wins;
            }
            int c = 1;
            for(int i = 1; i < winnum; i++)
            {
                if (x + i < w && a == squares[x + i, y] )
                {
                    c++;
                }
            }
            if (c == winnum)
            {
                return win;
            }
            c = 1;
            for (int i = 1; i < winnum; i++)
            {
                if (y + i < h && a == squares[x , y+i])
                {
                    c++;
                }
            }
            if (c == winnum)
            {
                return win;
            }
            c = 1;
            for (int i = 1; i < winnum; i++)
            {
                if (y + i < h &&x+i<w&& a == squares[x+i, y + i])
                {
                    c++;
                }
            }
            if (c == winnum)
            {
                return win;
            }
            c = 1;
            for (int i = 1; i < winnum; i++)
            {
                if (y + i < h && x - i >-1 && a == squares[x - i, y + i])
                {
                    c++;
                }
            }
            if (c == winnum)
            {
                return win;
            }

            return st;
        }
    }
    public enum piece { X=1,O=-1};
    public enum state { O_wins=-1,X_wins=1,None=0}
}
