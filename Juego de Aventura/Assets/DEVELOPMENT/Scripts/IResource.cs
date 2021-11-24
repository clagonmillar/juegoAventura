using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IResource : MonoBehaviour
{
    [SerializeField] private IItem resource;
    [SerializeField] private float hp;
    public IItem Collect => resource;
}
