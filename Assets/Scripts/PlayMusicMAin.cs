﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicMAin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        while (true)
        {

            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
