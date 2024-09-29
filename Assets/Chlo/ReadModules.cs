using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MapSpace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReadModules : MonoBehaviour
{

    void Awake()
    {
        ReturnPixelKey();
        ProcessModules(ReturnPixelKey(), SpecialFilterPoolGen("", MapModule.RmSize.Medium));
    }

    List<MapContainer[]> ProcessModules(Dictionary<string, Color> tileset, List<MapModule>[] filteredModules)
    {
        
        
        List<MapContainer[]> result = new List<MapContainer[]>();
        string str = "";
        foreach (var mpMdl in filteredModules[0])
        {
            List<MapContainer> miniResult = new List<MapContainer>();
            for (int x = 0; x < mpMdl.mapSprite.width; x++)
            {
                for (int y = 0; y < mpMdl.mapSprite.height; y++)
                {
                    var curPix = mpMdl.mapSprite.GetPixel(x, y);
                    switch (curPix)
                    {
                        case var value when value == tileset["Wall"]:
                            str = "Wall";
                            break;

                        case var value when value == tileset["NatBuilding"]:
                            str = "NatBuilding";
                            break;
                        case var value when value == tileset["Entrance"]:
                            str = "Entrance";
                            break;
                        case var value when value == tileset["Door"]:
                            str = "Door";
                            break;
                        case var value when value == tileset["Impassable"]:
                            str = "Impassable";
                            break;
                        
                        default:
                            str = "Door";
                            break;
                    }

                    miniResult.Add(new MapContainer(new Vector3(x, y), str));
                }
            }

            result.Add(miniResult.ToArray());
        }

        return result;
    }


    private Dictionary<string, Color> ReturnPixelKey()
    {
        GameObject pixelGameObject = GameObject.Find("pixelKey");
        return pixelGameObject.GetComponent<SetGlobalColors>().GlobalColors;
    }

    public List<MapModule>[] SpecialFilterPoolGen(string dir, MapModule.RmSize maxRoomSize)
    {
        List<MapModule>[] ret = new List<MapModule>[(int)maxRoomSize];
        for (var i = 0; i < (int)maxRoomSize; i++)
        {
            MapModule[] tmp = (MapModule[])Resources.LoadAll("Rooms/" + dir, typeof(MapModule)).ToArray();
            List<MapModule> returnee = new List<MapModule>();
            foreach (var f in tmp)
            {
                if (f.declaredSize == maxRoomSize)
                {
                    returnee.Add(f);
                }
                ret[i] = returnee;
            }
        }
        return ret;
    }
}
 


