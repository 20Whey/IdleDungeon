using TMPro;
using UnityEngine;

public class GoldManager : Singleton<GoldManager>
{
    public TMP_Text goldText;
    private int goldCount = 200;

    private bool enoughGold;
    public bool EnoughGold => enoughGold;

    private void Start()
    {
        goldText.text = goldCount.ToString();

        enoughGold = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8)) {
            IncreaseGold(1000);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            DecreaseGold(1000);
        }

        if (goldCount < 0) {
            Debug.LogError("Invalid gold amount!");
            return;
        }
    }

    public void IncreaseGold(int gold)
    {
        goldCount += gold;
        goldText.text = goldCount.ToString();
    }
    public void DecreaseGold(int gold)
    {
        if (goldCount >= gold) {
            goldCount -= gold;
            goldText.text = goldCount.ToString();
            enoughGold = true;
        } else {
            enoughGold = false;
            Debug.LogWarning("Not enough gold!");
        }
    }

}
