﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PointLightMovement : MonoBehaviour
{
    //public float Speed;
    public static PlayerLogic plLogic;
    // Start is called before the first frame update
    void Start()
    {
        //Speed = 5f;
        plLogic = FindObjectOfType<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, plLogic.Speed * Time.deltaTime);

    }
}
