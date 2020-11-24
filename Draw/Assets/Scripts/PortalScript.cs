using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject otherPortal;

    public void TeleportWater(GameObject water)
    {
        water.transform.position = otherPortal.transform.GetChild(0).transform.position;
    }
}
