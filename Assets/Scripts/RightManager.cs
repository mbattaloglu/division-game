using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightManager : MonoBehaviour
{
    public GameObject remaining1, remaining2, remaining3;

    public void CheckRights(int remainingRight)
    {
        if (remainingRight == 3)
        {
            remaining1.SetActive(true);
            remaining2.SetActive(true);
            remaining3.SetActive(true);
        }
        else if (remainingRight == 2)
        {
            remaining1.SetActive(true);
            remaining2.SetActive(true);
            remaining3.SetActive(false);
        }
        else if (remainingRight == 1)
        {
            remaining1.SetActive(true);
            remaining2.SetActive(false);
            remaining3.SetActive(false);
        }
        else if (remainingRight == 0)
        {
            remaining1.SetActive(false);
            remaining2.SetActive(false);
            remaining3.SetActive(false);
        }
    }
}
