using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class bosbanScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool isOpen = false;
    public Transform Player;
    public GameObject Coin;
    void Start()
    {
        if (Random.value < 0.7) {
            Coin.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen) {
            transform.localPosition += new Vector3(0, 0, (-0.732f - transform.localPosition.z)/20);
        } else if (!isOpen) {
            transform.localPosition += new Vector3(0, 0, (0.09799995f - transform.localPosition.z)/20);
        }
    }

    void OnMouseDown(){
        float dist = Vector3.Distance(transform.position, Player.position);
        if (dist < 2f) {
            isOpen = !isOpen;
        }
    }
}
