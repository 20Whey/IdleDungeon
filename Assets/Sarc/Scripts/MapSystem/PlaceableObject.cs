using System;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{

    public event Action<GameObject> OnPlaced;

    public bool Placed { get; private set; }

    private Vector3 origin;

    [SerializeField] private BoundsInt area;


    public bool CanBePlaced()
    {
        Vector3Int posiitonInt = MapSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = posiitonInt;

        return MapSystem.Instance.CanTakeArea(areaTemp);
    }

    public void Place()
    {
        Vector3Int posiitonInt = MapSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = posiitonInt;

        Placed = true;

        MapSystem.Instance.TakeArea(areaTemp);

        OnPlaced?.Invoke(gameObject);
    }

    public void CheckPlacement()
    {
        if (CanBePlaced()) {
            Place();
            origin = transform.position;

        } else {
            Debug.LogWarning("Unallowed Placeable Tile!");
        }
    }
}