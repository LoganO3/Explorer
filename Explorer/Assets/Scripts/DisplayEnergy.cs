using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayEnergy : MonoBehaviour
{

    TextMeshProUGUI energyText;
    Player player;

    // Use this for initialization
    void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = player.GetEnergy().ToString();
    }
}
