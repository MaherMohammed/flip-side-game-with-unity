using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeDown, swipeUp;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    public AudioClip switchColor;

    AudioSource myAudioSource1;

    public AudioClip switchPlatForm;
    AudioSource myAudioSource2;
    int CameraChanged;
    public float Speed;
    int RightPressed;
    int LeftPressed;
    public float HorSpeed;
    public float timing;
    private float beginingPos;
    private float endingPos;
    int positionGround = 1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameObject.transform.GetChild(0).transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z - 3f);
        CameraChanged = 0;

        int myColor = Random.Range(1, 4);
        if (myColor == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (myColor == 2)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
            else
            {
                if (myColor == 3)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }

        Speed = 5;
        RightPressed = 0;
        LeftPressed = 0;
        HorSpeed = 5;
        timing = 0f;
        beginingPos = 0f;

        myAudioSource1 = AddAudio(false, true, 1f);
        myAudioSource1.clip = switchColor;

        myAudioSource2 = AddAudio(false, true, 1f);
        myAudioSource2.clip = switchPlatForm;

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



    //true ==> side show
    //false ==> normal mode

    public void ChangeCameraMode()
    {
        print(CameraChanged);
        if (CameraChanged == 0)
        {
            gameObject.transform.GetChild(0).transform.position = new Vector3(transform.position.x + 13f, 3f, transform.position.z);
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, -40, 0);
            print("teslam");
            CameraChanged = 1;
        }
        else
        {
            if (CameraChanged == 1)
            {
                if (positionGround == 1)
                {
                    transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
                    //transform.GetChild(0).transform.position = new Vector3(transform.GetChild(0).transform.position.x, 2.6f, transform.GetChild(0).transform.position.z);

                    gameObject.transform.GetChild(0).transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z - 3f);
                    gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);

                    //positionGround = 0;
                }
                else
                {
                    if (positionGround == 0)
                    {
                        transform.position = new Vector3(transform.position.x, 2.6f, transform.position.z);
                        //transform.GetChild(0).transform.position = new Vector3(transform.GetChild(0).transform.position.x, 2.6f, transform.GetChild(0).transform.position.z);

                        gameObject.transform.GetChild(0).transform.position = new Vector3(transform.position.x, 2.6f, transform.position.z - 3f);
                        gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);

                        //positionGround = 1;
                    }
                }


                CameraChanged = 0;
                print("maher");
            }
        }
    }
    // void changeColor(int color){
    //     if (color == 1)
    //     {
    //         gameObject.GetComponent<Renderer>().material.color == Color.yellow;
    //     }
    //     else
    //     {
    //         if (color == 2)
    //         {
    //            this.gameObject.GetComponent<Renderer>().material.color == Color.cyan;
    //         }
    //     }
    // }

    // Update is called once per frame
    public void flipMode()
    {
        myAudioSource2.Play();
        if (positionGround == 1)
        {

            transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z);
            transform.GetChild(0).transform.position = new Vector3(transform.GetChild(0).transform.position.x, 2.6f, transform.GetChild(0).transform.position.z);
            positionGround = 0;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
            transform.GetChild(0).transform.position = new Vector3(transform.GetChild(0).transform.position.x, 1.5f, transform.GetChild(0).transform.position.z);
            positionGround = 1;
        }
    }

    void Update()
    {
        getSwipe();






        if (Input.GetKeyDown("r"))
        {
            myAudioSource1.Play();
            int rand = Random.Range(1, 4);
            if (rand == 1)
            {

                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                if (rand == 2)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                }
                else
                {
                    if (rand == 3)
                    {
                        gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
            }
        }




        timing = timing + Time.deltaTime;
        //print(timing);
        if (timing >= 15)
        {
            myAudioSource1.Play();
            int color = Random.Range(1, 4);
            if (color == 1)
            {
                //print("yellow");
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                if (color == 2)
                {
                    //print("cyannn");
                    gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                }
                else
                {
                    //print("blue");
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
            timing = 0f;
        }





        if (Input.GetKeyDown("c"))
        {
            ChangeCameraMode();
        }




        if (Input.GetKeyDown("space"))
        {
            flipMode();


        }
        // transform.Translate(0, 0, Speed * Time.deltaTime);

        //move Rigth
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d") || swipeRight)
        {
            RightPressed = 1;
            if (beginingPos == -1)
            {
                endingPos = 0;
            }
            else
            {
                if (beginingPos == 0)
                {
                    endingPos = 1;
                }
            }
        }

        if (RightPressed == 1)
        {


            transform.Translate(HorSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x > endingPos)
            {
                transform.position = new Vector3(endingPos, transform.position.y, transform.position.z);
                // transform.position.x = 0;
                RightPressed = 0;
                beginingPos = endingPos;
            }


        }




        // move left

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a") || swipeLeft)
        {
            LeftPressed = 1;
            if (beginingPos == 1)
            {
                endingPos = 0;
            }
            else
            {
                if (beginingPos == 0)
                {
                    endingPos = -1;
                }
            }
        }

        if (LeftPressed == 1)
        {


            transform.Translate(-HorSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x < endingPos)
            {
                transform.position = new Vector3(endingPos, transform.position.y, transform.position.z);
                // transform.position.x = 0;
                LeftPressed = 0;
                beginingPos = endingPos;
            }


        }


    }

    void getSwipe()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }

    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
