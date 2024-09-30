using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using MapSpace;
using Unity.Mathematics;

public class createTiles : MonoBehaviour
{

    public GameObject[] baseTiles;
    private ReadModules RdModules;
    public GameObject readingObj;
   // public MapModule test;
    public List<GameObject> Map; 
    // Start is called before the first frame update
    void Start()
    {
      //  CPPBase = gameObject.GetComponent<CPPBase>();
      RdModules =  readingObj.GetComponent<ReadModules>();
    }

    // Update is called once per frame
   
    void Update(){

    if(Input.GetKeyDown(KeyCode.F)){
       // currentMap = CPPBase.result;
      //  string[] inProgress = currentMap.Split(",");
        //foreach (var item in inProgress){
         //   string[] curr = item.Split(".");

         utiliseOnMap(RdModules.MapContainers[0]);
         // }
    }
    }


    private List<GameObject> utiliseOnMap(MapContainer[] roomBits){
    /*    int x = Int32.Parse(input[0]);
        int y =  Int32.Parse(input[1]);
        string key = input[2]; 
        Vector2 ourVec = new Vector2(x, y);*/
        
        GameObject chosenObject;
       // if (UnityEngine.Random.Range(0, 10) >= 9) key = "C";
       foreach (MapContainer cont in roomBits)
       {
           switch (cont.Type)
           {
               case "A":
                   /*  //I'm Sorry Dijktra :l
                      if (UnityEngine.Random.Range(0, 2) == 1) goto case "B";*/
                   chosenObject = baseTiles[0];
                   break;
               case "B":
                   chosenObject = baseTiles[1];
                   break;
               case "C":
               default:
                   chosenObject = baseTiles[2];
                   break;
           }

           GameObject newOb = Instantiate(chosenObject, cont.RelativePos, Quaternion.identity);
           Map.Add(newOb);
       }

       return Map;
        
    }
}
