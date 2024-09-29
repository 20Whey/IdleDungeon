using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;
using mpTl=MapSpace.MapModule;
using UnityEngine.Sprites;
public class SetGlobalColors : MonoBehaviour
{
    [Tooltip("pixel color keys from left to right, when reaching end going down a row")]
    [SerializeField] private String[] clrNames;
    // Start is called before the first frame update
    //public mpTl mapMod;
    public Dictionary<string, Color> GlobalColors = new Dictionary<string, Color>();
    public Texture2D palette;


   
     void Awake()
     {
         ReadColorPalette(palette);
         for (var i = 0; i < GlobalColors.Count; i++)
         {
             Debug.Log("assigned " + GlobalColors.ElementAt(i).Value + " to: " + GlobalColors.ElementAt(i).Key);
         }
     }

    public void ReadColorPalette(Texture2D pal)
    {
        Color[] colors = pal.GetPixels();
        for(var i = 0; i < colors.Length; i++){
            if (clrNames[i] != "null")
            {
                GlobalColors.Add(clrNames[i], colors[i]);
            }
        }
    }
}


