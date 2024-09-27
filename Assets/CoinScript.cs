using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist < 2.5f) {
            Player.GetComponent<PlayerOtherStuff>().Coins++;
            Destroy(gameObject);
        }
    }
}
