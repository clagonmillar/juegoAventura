using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour
{
    private Transform root;
    private IInventory inventory;

    private void Awake()
    {
        root = Camera.main.transform;
        inventory = GetComponent<IInventory>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && Physics.Raycast(root.position, root.forward, out RaycastHit hit, 3f, LayerMask.GetMask("Interactable")))
        {
            if (hit.transform.GetComponentInParent<IResource>() != null)
                inventory.Add(hit.transform.GetComponentInParent<IResource>().Collect, Random.Range(1, 4));
            else if (hit.transform.GetComponentInParent<IObject>() != null)
                inventory.Add(hit.transform.GetComponentInParent<IObject>());
            else if (hit.transform.GetComponentInParent<IBuilding>() != null)
                hit.transform.GetComponentInParent<IBuilding>().Build();
        }
    }
}
