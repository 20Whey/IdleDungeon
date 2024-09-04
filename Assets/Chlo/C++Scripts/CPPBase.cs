using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CPPBase : MonoBehaviour
{
[DllImport("backend")]
private static extern int[,] returnShape(int[,] originalMatrix);
}
