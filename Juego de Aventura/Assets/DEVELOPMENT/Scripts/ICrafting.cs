using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ICrafting : MonoBehaviour
{
    private List<IRecipe> recipes;
    private IInventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<IInventory>();
        recipes = Resources.LoadAll<IRecipe>("Presets/Recipes").ToList();
    }

    private void Craft(IRecipe recipe)
    {
        if (inventory.QuerryRemove(recipe.components))
            inventory.Add(recipe.result, 2);
    }
}