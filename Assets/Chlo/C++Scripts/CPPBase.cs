using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;
using System.Linq;
using System;
using System.Text;
public class CPPBase : MonoBehaviour
{
    //private static extern int[,] returnShape(int[,] originalMatrix);
    /*[DllImport("test.dll")]
    [return: MarshalAs(UnmanagedType.BStr)]
    private static extern string retrieveData(string input);
    
    public int maxX;
    public int maxY;
    public string result;
    public Vector2[,] Matrix;
    void Start()
    {
    result = retrieveData(turnPositionsIntoStringArray(CreateGrid(maxX, maxY)));
    result = returnTranslatedResult(result);
    Debug.Log(result);
    }
    //A LOT of stack overflow later
    public string returnTranslatedResult(string input){
    byte[] rawBytes = Encoding.Unicode.GetBytes(input);
    string asciiResult = Encoding.ASCII.GetString(rawBytes);
    return asciiResult; 
    }
    
    public Vector2[,] CreateGrid(int a, int b)
    {
        Matrix = new Vector2[a, b];

        for (var i = 0; i < a; i++)
        {
            for (var j = 0; j < b; j++)
            {
                Matrix[i, j] = new Vector2(i, j);
            }
        }
        return Matrix;
    }


    //turn vector2
    public string turnPositionsIntoStringArray(Vector2[,] matrix)
    {
    string partiallyRuinedGrid = "";
     foreach (var item in matrix)
     {
        string tmp = ".A,";
        if (UnityEngine.Random.Range(0, 10) >= 9) tmp = ".C,";
        partiallyRuinedGrid += item.x.ToString() +"."+ item.y.ToString() + tmp;
            

     
     }
    
    return partiallyRuinedGrid;
    }
*/

}
