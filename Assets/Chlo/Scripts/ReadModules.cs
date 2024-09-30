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

    private Dictionary<string, Color32> dict;
    public List<MapContainer[]> MapContainers;
    void Start()
    {
        dict = ReturnPixelKey();
        MapContainers = ProcessModules(dict, SpecialFilterPoolGen("", MapModule.RmSize.Large));
    }

    private bool checkForSimilarity(Color32 color1, Color32 color2)
    {
        if (color1.r == color2.r && color1.g == color2.g && color1.b == color2.b)
        {
            return true;
        }

        return false;
    }
    List<MapContainer[]> ProcessModules(Dictionary<string, Color32> tileset, List<MapModule>[] filteredModules)
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
                    Color32 curPix = mpMdl.mapSprite.GetPixel(x, y);
                    //BAD CODE AHEAAD
                    if (checkForSimilarity(curPix,tileset["Wall"]))
                    {
                        str = "Wall";
                    } else if (checkForSimilarity(curPix,tileset["Floor"]))
                    {
                        str = "Floor";
                    } else if (checkForSimilarity(curPix,tileset["NatBuilding"]))
                    {
                        str = "NatBuilding";
                    }else if (checkForSimilarity(curPix,tileset["Entrance"]))
                    {
                        str = "Entrance";
                    } else if (checkForSimilarity(curPix,tileset["Door"]))
                    {
                        str = "Door";
                    } else if (checkForSimilarity(curPix,tileset["Impassable"]))
                    {
                        str = "Impassable";
                    }else if (checkForSimilarity(curPix,tileset["NWCorner"]))
                    {
                        str = "NWCorner";
                    }else if (checkForSimilarity(curPix,tileset["NECorner"]))
                    {
                        str = "NECorner";
                    }else if (checkForSimilarity(curPix,tileset["SWCorner"]))
                    {
                        str = "SWCorner";
                    }else if (checkForSimilarity(curPix,tileset["SECorner"]))
                    {
                        str = "SECorner";
                    }else if (checkForSimilarity(curPix,tileset["4Corners"]))
                    {
                        str = "4Corners";
                    }else if (checkForSimilarity(curPix,tileset["W2Corner"]))
                    {
                        str = "W2Corner";
                    }else if (checkForSimilarity(curPix,tileset["E2Corner"]))
                    {
                        str = "E2Corner";
                    }else if (checkForSimilarity(curPix,tileset["N2Corner"]))
                    {
                        str = "N2Corner";
                    }else if (checkForSimilarity(curPix,tileset["S2Corner"]))
                    {
                        str = "S2Corner";
                    }
                    else
                    {
                        str = "";
                    }
                    

                    

                    
                    
                 /*
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
                            Debug.Log(curPix);
                            str = "Door";
                            break;
                    }*/

                    miniResult.Add(new MapContainer(new Vector2(x, y), str, curPix));
                }
            }
            result.Add(miniResult.ToArray());
        }

        return result;
    }


    private Dictionary<string, Color32> ReturnPixelKey()
    {
        GameObject pixelGameObject = GameObject.Find("GlobalColorInterpreter");
        return pixelGameObject.GetComponent<SetGlobalColors>().GlobalColors;
    }

    public List<MapModule>[] SpecialFilterPoolGen(string dir, MapModule.RmSize maxRoomSize)
    {
        List<MapModule>[] ret = new List<MapModule>[(int)maxRoomSize];
        for (var i = 0; i < (int)maxRoomSize; i++)
        {
            var tmp = Resources.LoadAll("Rooms/" + dir, typeof(MapModule)).Cast<MapModule>().ToArray();
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
 


