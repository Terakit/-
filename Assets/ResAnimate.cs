using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResAnimate : MonoBehaviour
{
    public Resources R;
    void Update()
    {
        if (R.animator.GetInteger("����")==2)
        {
            R.Invoke("GetResourceDel",0);
        }
    }
}
