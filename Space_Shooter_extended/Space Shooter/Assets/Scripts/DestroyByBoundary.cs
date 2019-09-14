using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit(Collider pOther)
    {
        Destroy(pOther.gameObject);
    }

}
