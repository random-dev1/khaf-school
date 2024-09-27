using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnergyTextS : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text energy;
    public GameObject Player;
    void Start()
    {
        energy = GetComponent<TextMeshProUGUI>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int dfsd = (int)Player.GetComponent<PlayerOtherStuff>().Energy;
        energy.text = "Energy: " + dfsd.ToString();
    }
}
