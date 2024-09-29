using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.Mathematics;

public class createTiles : MonoBehaviour
{

    public GameObject[] baseTiles;
    private CPPBase CPPBase;
    private string currentMap;
    public List<GameObject> Map; 
    // Start is called before the first frame update
    void Start()
    {
        CPPBase = gameObject.GetComponent<CPPBase>();
    }

    // Update is called once per frame
   
    void Update(){

    if(Input.GetKeyDown(KeyCode.F)){
        currentMap = CPPBase.result;
        string[] inProgress = currentMap.Split(",");
        foreach (var item in inProgress){
            string[] curr = item.Split(".");
            utiliseOnMap(curr);
        }
    }
    }


    private List<GameObject> utiliseOnMap(params string[] input){
        int x = Int32.Parse(input[0]);
        int y =  Int32.Parse(input[1]);
        string key = input[2]; 
        Vector2 ourVec = new Vector2(x, y);
        GameObject chosenObject;
        if (UnityEngine.Random.Range(0, 10) >= 9) key = "C";
        switch(key){
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
        GameObject newOb = Instantiate(chosenObject, ourVec, Quaternion.identity);
        Map.Add(newOb);
        return Map;
    }
}
