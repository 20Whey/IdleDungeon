using UnityEngine;

[CreateAssetMenu]
public class PlaceableSO : ScriptableObject
{
    public new string name;
    public Sprite uIIcon;
    public GameObject prefabToSpawn;
    public int goldCost;
}
