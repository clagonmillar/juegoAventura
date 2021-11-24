using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IQuerry = IInventory.IQuerry;

[CreateAssetMenu]
public class IBuild : ScriptableObject
{
    public GameObject result;
    public IQuerry[] components;
}