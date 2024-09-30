using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using MapSpace;
using Unity.Mathematics;
using UnityEngine.UIElements;

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
      Map = utiliseOnMap(RdModules.MapContainers.ElementAt(0));
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
           chosenObject = baseTiles[0];
           GameObject newOb = Instantiate(chosenObject, cont.RelativePos, Quaternion.identity);
           switch (cont.Type)
           {
               case "Wall":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "Floor":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "NatBuilding":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "Entrance":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "Door":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "NWCorner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "NECorner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "SWCorner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "SECorner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "4Corners":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "E2Corner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "N2Corner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;

                   break;
               case "S2Corner":
                   newOb.GetComponent<SpriteRenderer>().color = cont.Clor;
                   break;
               default:
                   newOb.GetComponent<SpriteRenderer>().color = Color.white;
                   break;
           }

           Debug.Log(cont.Type + " " + cont.Clor);
         
           Map.Add(newOb);
       }

       return Map;
        
    }
}
