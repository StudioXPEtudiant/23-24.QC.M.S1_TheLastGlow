using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private bool isInMenu;
    public InventoryManager invManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && isInMenu == false)
        {
            inventory.SetActive(true);
            invManager.ListItems();
            isInMenu = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInMenu == true)
        {
            inventory.SetActive(false);
            isInMenu = false;
        }
    }
}
