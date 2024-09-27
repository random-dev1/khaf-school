using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyTextS : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text money;
    public GameObject Player;
    void Start()
    {
        money = GetComponent<TextMeshProUGUI>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + Player.GetComponent<PlayerOtherStuff>().Coins.ToString();
    }
}
