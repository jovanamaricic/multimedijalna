using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform igrac;

    // Update is called once per frame
    void Update()
    {
        if(igrac.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, igrac.position.y, transform.position.z);
        }
    }
}
