using ImprovedTimers;
using UnityEngine;

public class TreasureHoard : MonoBehaviour
{
    private FrequencyTimer goldTickTimer;
    [Tooltip("Every 1/3 a second you will gain gold")]
    [SerializeField] private int goldGainFrequency = 3;

    private int goldIncreaseRate = 1;

    private PlaceableObject placeableObject;

    private void Awake()
    {
        placeableObject = GetComponent<PlaceableObject>();
        placeableObject.OnPlaced += PlaceableObject_OnPlaced;
        goldTickTimer = new FrequencyTimer(goldGainFrequency);
    }

    private void PlaceableObject_OnPlaced(GameObject obj)
    {
        if (obj == gameObject) {
            goldTickTimer.Start();
        }
    }

    private void Start()
    {
        goldTickTimer.OnTick += AddGold;
    }

    private void AddGold()
    {
        GoldManager.Instance.IncreaseGold(goldIncreaseRate);
    }

}
