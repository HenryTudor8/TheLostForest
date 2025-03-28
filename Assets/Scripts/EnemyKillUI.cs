using UnityEngine;
using TMPro;

public class EnemyKillUI : MonoBehaviour
{
    public TextMeshProUGUI killText;

    void Update()
    {
        killText.text = "Enemies Defeated: " + Enemy.killcounter;
    }
}

