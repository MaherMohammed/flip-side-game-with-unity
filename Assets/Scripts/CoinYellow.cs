using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinYellow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
