using UnityEngine;

[CreateAssetMenu]
public class UnitSO : ScriptableObject
{
    public new string name;
    public Sprite uIIcon;
    public GameObject prefabToSpawn;
    public int goldCost;
}
