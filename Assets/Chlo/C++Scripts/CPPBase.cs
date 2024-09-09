using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;
using System.Linq;
[InitializeOnLoad]
public class CPPBase : MonoBehaviour
{



    //private static extern int[,] returnShape(int[,] originalMatrix);
    [DllImport("test")]
    private static extern int returnTenPlusWhatever(int a);

    private static extern string[] FeedInData(string[] data);
    public int maxX;
    public int maxY;
    public Vector2[,] Matrix;

    void Start()
    {
        // Debug.Log(returnTenPlusWhatever(1));
CreateGrid();
FeedInData(RuinGrid(Matrix));
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

    public string[] RuinGrid(Vector2[,] matrix){
    List<string> partiallyRuinedGrid = new List<string>();

     foreach (var item in matrix)
     {
        partiallyRuinedGrid.Add(item.ToString());
        
     }
    //Debug.Log(partiallyRuinedGrid[3]);
    return partiallyRuinedGrid.ToArray();

    }


}
