using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOtherStuff : MonoBehaviour
{
    // Start is called before the first frame update
    public int Coins;
    public float Energy = 100;
    PlayerMovementTutorial playerMovement;
    public Image[] hotbarSlots;
    public Sprite emptySlotSprite;
    public Sprite[] itemSprites;
    public GameObject[] itemPrefabs;
    private GameObject equippedItem = null;
    public void AddItem(Sprite itemSprite)
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (hotbarSlots[i].sprite == emptySlotSprite)
            {
                hotbarSlots[i].sprite = itemSprite;
                break;
            }
        }
    }

    public void EquipItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < hotbarSlots.Length)
        {
            if (hotbarSlots[slotIndex].sprite != emptySlotSprite)
            {
                if (equippedItem != null)
                {
                    Destroy(equippedItem);
                }

                equippedItem = Instantiate(itemPrefabs[slotIndex], transform.position + transform.forward, Quaternion.identity);
                equippedItem.transform.parent = transform;
            }
        }
    }
    void Start()
    {
        playerMovement = GetComponent<PlayerMovementTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.sprinting && Energy > 0) {
            Energy -= 10f * Time.deltaTime;
        } else if (Energy < 100) {
            if (playerMovement.walking) {
                Energy += 0.5f * Time.deltaTime;
            } else {
                Energy += 1f * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) EquipItem(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) EquipItem(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) EquipItem(6);
        if (Input.GetKeyDown(KeyCode.Alpha8)) EquipItem(7);
        if (Input.GetKeyDown(KeyCode.Alpha9)) EquipItem(8);
    }
}
