using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;


public class createBase : MonoBehaviour
{

    public GameObject tile;
    public class MatriOb
    {

        internal Color mCol;
        internal Vector2 mPosition;
        public MatriOb(Vector2 pos, Color col)
        {
            mCol = col;
            mPosition = pos;
        }
    }

    public List<MatriOb> Matrix;

    
    
    
    // Start is called before the first frame update
     void Awake()
    {
        Matrix = new List<MatriOb>();
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                var a = new MatriOb(new Vector2(i, j), Color.green);
                Matrix.Add(a);
            }
        }
    }

    void Start()
    { 
        var smlSquare = DefineShape(0, new Vector2(11, 11));
        var bigSquare = DefineShape(1, new Vector2(5, 2));
       modifyMatrix(smlSquare);
       modifyMatrix(bigSquare);
        
        DisplayPositionsAndStatus(Matrix);
    }




    void modifyMatrix(List<MatriOb> mt)
    {

        foreach (MatriOb item in mt)
        {
            for (var i = 0; i < Matrix.Count - 1; i++)
            {
                if (item.mPosition == Matrix.ElementAt(i).mPosition)
                {
                    Matrix.ElementAt(i).mCol = item.mCol;
                }
            }
        }
    }

    void DisplayPositionsAndStatus(List<MatriOb> matrix)
    {
        
        
        foreach (MatriOb nd in matrix)
        {
          GameObject curr = Instantiate(tile, nd.mPosition, Quaternion.identity);
          curr.GetComponent<SpriteRenderer>().color = nd.mCol;
          curr.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }


    
    
    
   List<MatriOb> DefineShape(int shape, Vector2 startPos)
   {
       
       switch (shape)
       {
        case 0:
            return returnSimpleCube(3, 3, startPos);
            break;
        case 1:
            return returnSimpleCube(5, 5, startPos);

            break;
        case 2:
            return returnSimpleCube(1, 1, startPos);
            break;
       }


       return null;
   }

   List<MatriOb> returnSimpleCube(int maxX, int maxY, Vector2 currentPos)
   {
       var lr = new List<MatriOb>();
       int sx = (int)currentPos.x;
       int sy = (int)currentPos.y;
       maxY += (int)currentPos.y;
       maxX += (int)currentPos.x;
       
       for (var x = sx; x < maxX; x++)
       {
           for (var y = sy; y < maxY; y++) lr.Add(new MatriOb(new Vector2(x, y), Color.red));
       } 
       
       return lr;
   }
   
   
   
   
   
   }
   


