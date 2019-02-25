using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkMeerssman1C_Script : MonoBehaviour
{
    float ranzigTimertje = 5;

    void Update()
    {
       if(ranzigTimertje >= 0)
        {
            ranzigTimertje -= Time.deltaTime;
        }
       else
        {
            RandomJump();
            ranzigTimertje = 5;
        }
    }

    void RandomJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(500, 750));    
    }
}
