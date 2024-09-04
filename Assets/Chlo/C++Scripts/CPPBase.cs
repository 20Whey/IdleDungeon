using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
[InitializeOnLoad]
public class CPPBase : MonoBehaviour
{
//private static extern int[,] returnShape(int[,] originalMatrix);
    [DllImport("test")]
   private static extern int returnTenPlusWhatever(int a);



    void Start(){
       Debug.Log(returnTenPlusWhatever(1));
    }

}
