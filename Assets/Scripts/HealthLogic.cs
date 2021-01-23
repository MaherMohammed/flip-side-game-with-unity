using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerLogic plLogic;
    private float posGround;
    private float posRoof;
    public GameObject HealthPoint1;
    public GameObject HealthPoint2;
    public AudioClip HealthPointSound;
    AudioSource myAudioSource;
    void Start()
    {
        plLogic = FindObjectOfType<PlayerLogic>();
        posGround = 45f;
        posRoof = 25f;
        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                Instantiate(HealthPoint1, new Vector3(0, 0.5f, posGround), Quaternion.identity);

            }
            posGround += 40;
        }

        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {

                Instantiate(HealthPoint2, new Vector3(0, 2.5f, posRoof), Quaternion.identity);
            }
            posRoof += 100;
        }

        //myAudioSource1 = AddAudio(false, true, 0.7f);
        myAudioSource = AddAudio(false, true, 0.7f);
        // myAudioSource3 = AddAudio(false, true, 0.7f);
        //StartPlayingSounds();
        myAudioSource.clip = HealthPointSound;
        //myAudioSource2.clip = ObstacleSound;
        //myAudioSource3.clip = HealthPointSound;
    }
    public AudioSource AddAudio(bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        //newAudio.clip = clip; 
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HealthCollider")
        {
            //print("hereeee");
            other.gameObject.transform.parent.transform.position = new Vector3(0, 0.5f, posGround);
            posGround += 40;
        }
        else
        {
            if (other.gameObject.tag == "HealthCollider2")
            {
                //print("hereeee");
                other.gameObject.transform.parent.transform.position = new Vector3(0, 2.5f, posRoof);
                posRoof += 100;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Health")
        {

            other.gameObject.transform.position = new Vector3(0, 0.5f, posGround);
            posGround += 20;
            plLogic.setHealth(1);
            myAudioSource.Play();
        }
        else
        {
            if (other.gameObject.tag == "Health2")
            {

                other.gameObject.transform.position = new Vector3(0, 2.5f, posRoof);
                posRoof += 20;
                plLogic.setHealth(1);
                myAudioSource.Play();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
