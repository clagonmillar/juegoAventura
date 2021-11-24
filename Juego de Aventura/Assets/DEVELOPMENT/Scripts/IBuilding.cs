using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IBuilding : MonoBehaviour
{
    [SerializeField] private IBuild build; 
    private TextMeshPro ui;
    private IInventory inventory;
    private bool update;

    private void Start()
    {
        inventory = FindObjectOfType<IInventory>(true);
        ui = GetComponentInChildren<TextMeshPro>(true);
        ui.gameObject.SetActive(false);
    }

    public void Build()
    {
        if (inventory.QuerryRemove(build.components))
        {
            Transform building = Instantiate(build.result).transform;
            building.SetPositionAndRotation(transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.text = "BUILDING: " + build.name + "\n\n";
            ui.gameObject.SetActive(true);

            foreach (var comp in build.components)
            {
                bool hasItem = inventory.Check(comp.item.name, comp.quantity);
                ui.text += $"{(hasItem ? "<color=green>" : "<color=red>")}{comp.quantity} x {comp.item.name}</color>\n";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            ui.gameObject.SetActive(false);
    }
}
