using UnityEngine;

public class PlaceableObject : MonoBehaviour
{

    public bool Placed { get; private set; }

    private Vector3 origin;

    [SerializeField] private BoundsInt area;

    public bool CanBePlaced()
    {
        Vector3Int posiitonInt = BuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = posiitonInt;

        return BuildingSystem.Instance.CanTakeArea(areaTemp);
    }

    public void Place()
    {
        Vector3Int posiitonInt = BuildingSystem.Instance.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = posiitonInt;

        Placed = true;

        BuildingSystem.Instance.TakeArea(areaTemp);
    }

    public void CheckPlacement()
    {
        if (CanBePlaced()) {
            Place();
            origin = transform.position;

        } else {
            Destroy(transform.gameObject);
        }
    }
}