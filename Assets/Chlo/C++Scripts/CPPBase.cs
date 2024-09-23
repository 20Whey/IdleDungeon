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
    [DllImport("test.dll")]
    [return: MarshalAs(UnmanagedType.BStr)]
    private static extern string retrieveData(string input);
    
    public int maxX;
    public int maxY;
    private string result;
    public Vector2[,] Matrix;
    void Start()
    {
    // string[] result = retrieveData(turnPositionsIntoStringArray(CreateGrid()), 100);

        //result = ;

       result = retrieveData(turnPositionsIntoStringArray(CreateGrid(maxX, maxY)));
      byte[] rawBytes = Encoding.Unicode.GetBytes(result);

        // Convert the raw byte array to an ASCII string
        string asciiResult = Encoding.ASCII.GetString(rawBytes);
        Debug.Log(asciiResult);
      /*   IntPtr bstrPtr = Marshal.StringToBSTR(result);  // Get BSTR pointer
        string recoveredString = Marshal.PtrToStringAnsi(bstrPtr);
        Debug.Log(recoveredString);
      // for (int i = 0; i < 100; i++)
        //{
        /*
           IntPtr ptr = Marshal.ReadIntPtr(result, 5 * IntPtr.Size);
              Marshal.PtrToStringBSTR(ptr);
     */
        
        
    }

    // Debug.Log(returnTenPlusWhatever(1));
    //Debug.Log(returnTenPlusWhatever(2));
   // Debug.Log();
    
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
        partiallyRuinedGrid += item.x.ToString() + item.y.ToString() + " ";

        //Debug.Log(partiallyRuinedGrid);
     }
    
    return partiallyRuinedGrid;
    }


}
