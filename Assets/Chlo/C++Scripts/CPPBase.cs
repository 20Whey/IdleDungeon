using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;
using System.Linq;
using System;
[InitializeOnLoad]
public class CPPBase : MonoBehaviour
{



    //private static extern int[,] returnShape(int[,] originalMatrix);
    [DllImport("test")]
    private static extern IntPtr feedToCPP();

    [DllImport("test")]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    private static extern IntPtr retrieveData(string[] arr, int len);
    public int maxX;
    public int maxY;
    public Vector2[,] Matrix;

    void Start()
    {
        IntPtr result = retrieveData(turnPositionsIntoStringArray(CreateGrid()), 100);
        string[] processedData = new string[maxX*maxY];
        for (int i = 0; i < 4; i++)
        {
            IntPtr ptr = Marshal.ReadIntPtr(result, i * IntPtr.Size);
            processedData[i] = Marshal.PtrToStringAnsi(ptr);
            Debug.Log(processedData[i]);
        }


    // Debug.Log(returnTenPlusWhatever(1));
    //Debug.Log(returnTenPlusWhatever(2));
   // Debug.Log();
    }
    public Vector2[,] CreateGrid()
    {
        Matrix = new Vector2[maxX, maxY];

        for (var i = 0; i < maxX; i++)
        {
            for (var j = 0; j < maxY; j++)
            {
                Matrix[i, j] = new Vector2(i, j);
            }
        }
        return Matrix;
    }

    public string[] turnPositionsIntoStringArray(Vector2[,] matrix){
    List<string> partiallyRuinedGrid = new List<string>();

     foreach (var item in matrix)
     {
        partiallyRuinedGrid.Add(item.ToString());
        
     }
    //Debug.Log(partiallyRuinedGrid[3]);
    return partiallyRuinedGrid.ToArray();
    }


}
