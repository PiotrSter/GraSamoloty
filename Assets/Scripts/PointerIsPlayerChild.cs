using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerIsPlayerChild : MonoBehaviour
{
    public GameObject pointer;

    public void SetParent(GameObject newParent)
    {
        pointer.transform.parent = newParent.transform;
    }

    
}
