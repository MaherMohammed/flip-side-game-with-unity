using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public static PlayerLogic plLogic;
    int flip;
    void Start()
    {
        plLogic = FindObjectOfType<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, Speed * Time.deltaTime);

        // transform.Translate(plLogic.Speed, 0, 0);
        transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
    }
}
