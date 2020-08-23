using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


class Board
{
    public int whiteCount;
    public int blackCount;

    public int[,] board = new int[8, 8];




    bool isOnBoard(Coordinate c)
    {
        int x = c.x;
        int y = c.y;
        return (0 <= x && x <= 7 && 0 <= y && y <= 7);
    }

    public List<Coordinate> CaptureAll(Coordinate m, int color)
    {
        List<Coordinate> p = new List<Coordinate>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Coordinate d = new Coordinate(x, y);
                foreach (Coordinate coor in piecesToCapture(m, d, color))
                {
                    //board[coor.x, coor.y] = color;
                    p.Add(coor);
                    //Console.WriteLine(coor.AsString());
                }
            }
        }
        return p;
    }

    List<Coordinate> piecesToCapture(Coordinate m, Coordinate d, int color)
    {
        List<Coordinate> p = new List<Coordinate>();
        Coordinate n = m + d;
        if (isOnBoard(n) && board[n.x, n.y] == -color)
        {
            
            for (int i = 1; i < 8; i++)
            {
                Coordinate v = d * i;
                Coordinate s = m + v;
                if (isOnBoard(s) && board[s.x, s.y] == -color)
                {
                    p.Add(s);
                }
				else if (isOnBoard(s) && (board[s.x, s.y] == color))
                {
                    return p;
                }
				else if (isOnBoard(s) && board[s.x, s.y] == 0){
					return new List<Coordinate>();
				}
            }
        }

        return new List<Coordinate>();
    }


	public int nWhite(){
	//	int count = 0;
    whiteCount=0;
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++){
				if (board[i, j] == 1){
					whiteCount += 1;
				}
			}

		}
		return whiteCount;
	}

	public int nBlack(){
	//	int count = 0;
    blackCount=0;
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++){
				if (board[i, j] == -1){
					blackCount += 1;
				}
			}
			
		}
		return blackCount;
	}



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

