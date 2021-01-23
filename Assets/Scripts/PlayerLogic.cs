using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerLogic : MonoBehaviour
{
    int gameOverPlayed;
    int pausePlayed;

    int escapePressed;
    public AudioClip CoinSound;
    public AudioClip ObstacleSound;

    public AudioClip notMatchingCoin;

    public AudioClip PauseAndGameOver;
    public AudioClip Ex;
    private int gameOver;
    AudioSource myAudioSource1;
    AudioSource myAudioSource2;
    AudioSource myAudioSource3;
    AudioSource myAudioSource4;
    AudioSource myAudioSource5;
    //AudioSource myAudioSource3;
    public Text YouLooseText;
    bool cam;
    private int count;
    public TMP_Text HealthText;
    public TMP_Text ScoreText;
    public GameObject Obstacle;
    public GameObject ObstacleTwoLanes;
    public GameObject ObstacleThreeLanes;
    public GameObject YellowCoin;
    public GameObject CyanCoin;
    public GameObject BlueCoin;
    public GameObject HealthPoint;

    private int SpacePressed;
    private int ChooseObstacle;

    int CPressed;
    private float timing;
    private float nextPoint;
    private static int Health;
    // private List<float> positions;
    private int Score;
    // private float HealthPosition;
    //float Passed;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    int ChooseCoin;
    public float Speed;
    float CoinsPos;
    private List<GameObject> DrawnObstaclesGround;
    private List<GameObject> DrawnObstaclesRoof;
    GameObject tmp1;
    GameObject tmp2;
    // private int isAbove;
    // private List<GameObject> ObstaclesTwoLanes;
    // private List<GameObject> ObstaclesThreeLanes;


    public Camera mainCamera;
    private float ObstaclesPosition;
    //private List<GameObject> Obstacles;
    // Start is called before the first frame update
    void Start()
    {
        pausePlayed = 0;
        gameOver = 0;
        gameOverPlayed = 0;
        escapePressed = 0;
        //cam = false;
        CPressed = 0;
        count = 1;
        Time.timeScale = 1;
        Speed = 5;
        //isAbove = 0;
        SpacePressed = 0;
        //HealthPosition = 5f;
        //count = 0;
        //sCoinsPos = -29f;
        Health = 3;
        DrawnObstaclesGround = new List<GameObject>();
        DrawnObstaclesRoof = new List<GameObject>();
        ObstaclesPosition = -30f;
        // Passed = -30f;



        for (int i = 0; i < 50; i++)
        {
            int randomObstacleGround = Random.Range(1, 4);
            int randomObstacleRoof = Random.Range(1, 4);
            int randomXGround = Random.Range(-1, 2);
            int randomXRoof = Random.Range(-1, 2);
            ChooseCoin = Random.Range(1, 4);


            if (randomObstacleGround == 1)
            {
                tmp1 = Instantiate(Obstacle, new Vector3(randomXGround, 0.5f, ObstaclesPosition), Quaternion.identity);
                drawCoinBesidesSmallObstacles(randomXGround, 0.5f, ObstaclesPosition);
            }
            else
            {
                if (randomObstacleGround == 2)
                {
                    int rand = Random.Range(1, 3);
                    if (rand == 1)
                    {

                        tmp1 = Instantiate(ObstacleTwoLanes, new Vector3(1, 0.5f, ObstaclesPosition), Quaternion.identity);
                        drawCoinBesidesTwoLanesObstacles(1, 0.5f, ObstaclesPosition);
                    }
                    else
                    {
                        tmp1 = Instantiate(ObstacleTwoLanes, new Vector3(-1, 0.5f, ObstaclesPosition), Quaternion.identity);
                        drawCoinBesidesTwoLanesObstacles(-1, 0.5f, ObstaclesPosition);
                    }
                }
                else
                {
                    tmp1 = Instantiate(ObstacleThreeLanes, new Vector3(0, 0.5f, ObstaclesPosition), Quaternion.identity);
                }
            }
            drawCoinsAfterObstacles(ObstaclesPosition, 0.5f);
            DrawnObstaclesGround.Add(tmp1);


            // drawing roof Obstacles

            if (randomObstacleRoof == 1)
            {
                tmp2 = Instantiate(Obstacle, new Vector3(randomXRoof, 2.5f, ObstaclesPosition), Quaternion.identity);
                drawCoinBesidesSmallObstacles(randomXRoof, 2.5f, ObstaclesPosition);
            }
            else
            {
                if (randomObstacleRoof == 2)
                {
                    int rand2 = Random.Range(1, 3);
                    if (rand2 == 1)
                    {

                        tmp2 = Instantiate(ObstacleTwoLanes, new Vector3(1, 2.5f, ObstaclesPosition), Quaternion.identity);
                        drawCoinBesidesTwoLanesObstacles(1, 2.5f, ObstaclesPosition);
                    }
                    else
                    {
                        tmp2 = Instantiate(ObstacleTwoLanes, new Vector3(-1, 2.5f, ObstaclesPosition), Quaternion.identity);
                        drawCoinBesidesTwoLanesObstacles(-1, 2.5f, ObstaclesPosition);

                    }
                }
                else
                {
                    if (randomObstacleGround == 3)
                    {
                        tmp2 = Instantiate(Obstacle, new Vector3(randomXRoof, 2.5f, ObstaclesPosition), Quaternion.identity);
                        //print("Here............");
                    }
                    else
                    {

                        tmp2 = Instantiate(ObstacleThreeLanes, new Vector3(0, 2.5f, ObstaclesPosition), Quaternion.identity);
                    }
                }
            }
            drawCoinsAfterObstacles(ObstaclesPosition, 2.5f);
            DrawnObstaclesRoof.Add(tmp2);
            // positions.Add(ObstaclesPosition);

            ObstaclesPosition = ObstaclesPosition + 10.0f;

        }
        myAudioSource1 = AddAudio(false, true, 0.7f);
        myAudioSource2 = AddAudio(false, true, 0.7f);
        myAudioSource3 = AddAudio(false, true, 0.7f);
        myAudioSource4 = AddAudio(true, false, 0.7f);
        myAudioSource5 = AddAudio(true, false, 0.5f);
        // myAudioSource3 = AddAudio(false, true, 0.7f);
        //StartPlayingSounds();
        myAudioSource1.clip = CoinSound;
        myAudioSource2.clip = ObstacleSound;
        myAudioSource3.clip = notMatchingCoin;
        myAudioSource4.clip = PauseAndGameOver;
        myAudioSource5.clip = Ex;
        myAudioSource5.Play();
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
    public void setHealth(int h)
    {
        if (Health > 0 && Health <= 3)
        {
            Health += h;
            if (Health > 3)
            {
                Health = 3;
            }
        }
    }


    //1 Yellow
    // 2 Blue
    // 3 Cyan
    void drawCoinBesidesSmallObstacles(float xNotToDraw, float yPos, float zPos)
    {

        if (xNotToDraw == -1)
        {
            int colorOfCoin1 = Random.Range(1, 4);
            if (colorOfCoin1 == 1)
            {
                Instantiate(YellowCoin, new Vector3(0, yPos, zPos), Quaternion.identity);
            }
            else
            {
                if (colorOfCoin1 == 2)
                {
                    Instantiate(BlueCoin, new Vector3(0, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin1 == 3)
                    {
                        Instantiate(CyanCoin, new Vector3(0, yPos, zPos), Quaternion.identity);
                    }
                }
            }



            int colorOfCoin2 = Random.Range(1, 4);
            if (colorOfCoin2 == 1)
            {
                Instantiate(YellowCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
            }
            else
            {
                if (colorOfCoin2 == 2)
                {
                    Instantiate(BlueCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin2 == 3)
                    {
                        Instantiate(CyanCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                    }
                }
            }

        }

        else
        {
            if (xNotToDraw == 0)
            {

                int colorOfCoin1 = Random.Range(1, 4);
                if (colorOfCoin1 == 1)
                {
                    Instantiate(YellowCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin1 == 2)
                    {
                        Instantiate(BlueCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                    }
                    else
                    {
                        if (colorOfCoin1 == 3)
                        {
                            Instantiate(CyanCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                        }
                    }
                }



                int colorOfCoin2 = Random.Range(1, 4);
                if (colorOfCoin2 == 1)
                {
                    Instantiate(YellowCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin2 == 2)
                    {
                        Instantiate(BlueCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                    }
                    else
                    {
                        if (colorOfCoin2 == 3)
                        {
                            Instantiate(CyanCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                        }
                    }
                }
            }
            else
            {
                int colorOfCoin1 = Random.Range(1, 4);
                if (colorOfCoin1 == 1)
                {
                    Instantiate(YellowCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin1 == 2)
                    {
                        Instantiate(BlueCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                    }
                    else
                    {
                        if (colorOfCoin1 == 3)
                        {
                            Instantiate(CyanCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                        }
                    }
                }



                int colorOfCoin2 = Random.Range(1, 4);
                if (colorOfCoin2 == 1)
                {
                    Instantiate(YellowCoin, new Vector3(0, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin2 == 2)
                    {
                        Instantiate(BlueCoin, new Vector3(0, yPos, zPos), Quaternion.identity);
                    }
                    else
                    {
                        if (colorOfCoin2 == 3)
                        {
                            Instantiate(CyanCoin, new Vector3(0, yPos, zPos), Quaternion.identity);
                        }
                    }
                }
            }
        }

    }


    void drawCoinBesidesTwoLanesObstacles(float xNotToDraw, float yPos, float zPos)
    {
        if (xNotToDraw == -1)
        {
            int colorOfCoin1 = Random.Range(1, 4);
            if (colorOfCoin1 == 1)
            {
                Instantiate(YellowCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
            }
            else
            {
                if (colorOfCoin1 == 2)
                {
                    Instantiate(BlueCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin1 == 3)
                    {
                        Instantiate(CyanCoin, new Vector3(1, yPos, zPos), Quaternion.identity);
                    }
                }
            }
        }
        else
        {
            if (xNotToDraw == 1)
            {
                int colorOfCoin1 = Random.Range(1, 4);
                if (colorOfCoin1 == 1)
                {
                    Instantiate(YellowCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                }
                else
                {
                    if (colorOfCoin1 == 2)
                    {
                        Instantiate(BlueCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                    }
                    else
                    {
                        if (colorOfCoin1 == 3)
                        {
                            Instantiate(CyanCoin, new Vector3(-1, yPos, zPos), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }


    void DrawCoinRandom(int color, Vector3 pos)
    {
        if (color == 1)
        {
            Instantiate(YellowCoin, pos, Quaternion.identity);
        }
        else
        {
            if (color == 2)
            {
                Instantiate(CyanCoin, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(BlueCoin, pos, Quaternion.identity);
            }
        }
    }
    void drawCoinsAfterObstacles(float zPos, float yPos)
    {
        int rand1 = Random.Range(1, 4);
        int rand2 = Random.Range(1, 4);
        int rand3 = Random.Range(1, 4);
        int rand4 = Random.Range(1, 4);
        DrawCoinRandom(rand1, new Vector3(1, yPos, zPos + 3f));
        DrawCoinRandom(rand1, new Vector3(-1, yPos, zPos + 3f));
        DrawCoinRandom(rand1, new Vector3(1, yPos, zPos + 6f));
        DrawCoinRandom(rand1, new Vector3(-1, yPos, zPos + 6f));

    }




    void OnTriggerEnter(Collider other)
    {
        if (transform.position.y == 0.2f)
        {

            if (other.gameObject.tag == "Collectible" && other.gameObject.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
            {
                Destroy(other.gameObject);
                Score += 10;
                ScoreText.text = "Score: " + Score;
                // GetComponent<AudioSource>().Play();

                myAudioSource1.Play();
            }
            else
            {
                if (other.gameObject.tag == "Collectible" && other.gameObject.GetComponent<Renderer>().material.color != gameObject.GetComponent<Renderer>().material.color)
                {
                    Destroy(other.gameObject);
                    Score -= 5;
                    ScoreText.text = "Score: " + Score;
                    myAudioSource3.Play();
                }
            }
        }
        else
        {
            if (transform.position.y == 2.8f)
            {
                if (other.gameObject.tag == "Collectible" && other.gameObject.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
                {
                    Destroy(other.gameObject);
                    Score -= 5;
                    ScoreText.text = "Score: " + Score;
                    myAudioSource3.Play();
                }
                else
                {
                    if (other.gameObject.tag == "Collectible" && other.gameObject.GetComponent<Renderer>().material.color != gameObject.GetComponent<Renderer>().material.color)
                    {
                        // print("maher");
                        Destroy(other.gameObject);
                        Score += 10;
                        ScoreText.text = "Score: " + Score;
                        //GetComponent<AudioSource>().Play();
                        myAudioSource1.Play();
                    }
                }
            }
        }



        if (other.gameObject.tag == "Hazard")
        {
            int randomX = Random.Range(-1, 2);
            other.gameObject.transform.position = new Vector3(randomX, other.gameObject.transform.position.y, ObstaclesPosition);
            setHealth(-1);
            HealthText.text = "Health: " + Health;
            ObstaclesPosition = ObstaclesPosition + 10f;
            myAudioSource2.Play();

        }
        else
        {
            if (other.gameObject.tag == "Hazard2")
            {
                int rand = Random.Range(1, 3);
                if (rand == 1)
                {

                    // int randomX = Random.Range(-1, 2);
                    other.gameObject.transform.position = new Vector3(1, other.gameObject.transform.position.y, ObstaclesPosition);
                    drawCoinBesidesTwoLanesObstacles(1, other.gameObject.transform.position.y, ObstaclesPosition);
                    setHealth(-1);
                    HealthText.text = "Health: " + Health;
                    ObstaclesPosition = ObstaclesPosition + 10f;
                    myAudioSource2.Play();
                }
                else
                {
                    //int randomX = Random.Range(-1, 2);
                    other.gameObject.transform.position = new Vector3(-1, other.gameObject.transform.position.y, ObstaclesPosition);
                    drawCoinBesidesTwoLanesObstacles(-1, other.gameObject.transform.position.y, ObstaclesPosition);
                    setHealth(-1);
                    HealthText.text = "Health: " + Health;
                    ObstaclesPosition = ObstaclesPosition + 10f;
                    myAudioSource2.Play();
                }
            }
            else
            {
                if (other.gameObject.tag == "Hazard3")
                {

                    int randomX = Random.Range(-1, 2);
                    other.gameObject.transform.position = new Vector3(0, other.gameObject.transform.position.y, ObstaclesPosition);
                    //drawCoinBesidesTwoLanesObstacles(randomX, other.gameObject.transform.position.y, ObstaclesPosition);
                    setHealth(-1);
                    HealthText.text = "Health: " + Health;
                    ObstaclesPosition = ObstaclesPosition + 10f;
                    myAudioSource2.Play();
                }
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CoinCollider")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }

        if (other.gameObject.tag == "collider")
        {
            //print("ttttttttttt");

            int randomX = Random.Range(-1, 2);
            other.gameObject.transform.parent.transform.position = new Vector3(randomX, other.gameObject.transform.parent.transform.position.y, ObstaclesPosition);
            drawCoinBesidesSmallObstacles(randomX, other.gameObject.transform.parent.transform.position.y, ObstaclesPosition);
            drawCoinsAfterObstacles(ObstaclesPosition, other.gameObject.transform.parent.transform.position.y);
            ObstaclesPosition += 10f;

        }
        else
        {
            if (other.gameObject.tag == "collider2")
            {
                //print("ttttttttttt");
                int rand = Random.Range(1, 3);
                if (rand == 1)
                {
                    other.gameObject.transform.parent.transform.position = new Vector3(1, other.gameObject.transform.parent.transform.position.y, ObstaclesPosition);
                    drawCoinBesidesTwoLanesObstacles(1, other.gameObject.transform.parent.transform.position.y, ObstaclesPosition);
                    drawCoinsAfterObstacles(ObstaclesPosition, other.gameObject.transform.parent.transform.position.y);

                    ObstaclesPosition += 10f;
                }
                else
                {

                    other.gameObject.transform.parent.transform.position = new Vector3(-1, other.gameObject.transform.position.y, ObstaclesPosition);
                    drawCoinBesidesTwoLanesObstacles(-1, other.gameObject.transform.parent.transform.position.y, ObstaclesPosition);
                    drawCoinsAfterObstacles(ObstaclesPosition, other.gameObject.transform.parent.transform.position.y);

                    ObstaclesPosition += 10f;
                }
            }
            else
            {
                if (other.gameObject.tag == "collider3")
                {
                    other.gameObject.transform.parent.transform.position = new Vector3(0, other.gameObject.transform.position.y, ObstaclesPosition);
                    drawCoinsAfterObstacles(ObstaclesPosition, other.gameObject.transform.parent.transform.position.y);
                    ObstaclesPosition += 10f;
                }
            }
        }
    }

    // bool cameraToggled = false;
    // public void changeCameraMode()
    // {
    //     Vector3 camPos = mainCamera.gameObject.transform.position;
    //     camPos = new Vector3(camPos.x + 5, camPos.y, camPos.z);
    //     Quaternion rotateView = mainCamera.gameObject.transform.rotation;

    //     mainCamera.gameObject.transform.position = camPos;
    //     mainCamera.gameObject.transform.rotation = Quaternion.Euler(rotateView.x, -40, rotateView.z);

    // }

    // public void setSideView()
    // {

    //     mainCamera.gameObject.transform.position = new Vector3(5, 2.5f, -3);
    //     mainCamera.gameObject.transform.rotation = Quaternion.Euler(17, -45, 0);

    // }
    // private bool escapePressed = false;
    void Update()
    {
        if (gameOver == 0)
        {



            if (Input.GetKeyDown("escape"))
            {
                pause();
            }


            if (Input.GetKeyDown("e"))
            {
                setHealth(1);
            }

            if (Score > count * 50)
            {
                //print(Speed);
                Speed += 2f;
                count++;

            }

            if (Input.GetKeyDown("q"))
            {
                Score += 10;
                ScoreText.text = "Score: " + Score;
            }


            //print("player: " + Speed);
            transform.Translate(0, 0, Speed * Time.deltaTime);
            // if (cam == false)
            // {

            //gameObject.transform.GetChild(2).gameObject.SetActive(false);
            if (Input.GetKeyDown("space"))
            {
                if (SpacePressed == 1)
                {
                    // gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    // gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    SpacePressed = 0;
                }
                else
                {
                    if (SpacePressed == 0)
                    {
                        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        // gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        SpacePressed = 1;
                    }
                }
            }

            /*if (cam)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }





            else
            {
                if (transform.position.y == 0.2f)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).gameObject.SetActive(false);

                }
                if (transform.position.y == 2.8)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    gameObject.transform.GetChild(2).gameObject.SetActive(false);
                }

                else
                {
                    if (cam == true)
                    {
                        gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        gameObject.transform.GetChild(1).gameObject.SetActive(false);
                        gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    }
                }
            }*/



            HealthText.text = "Health: " + Health;
            if (Health == 0)
            {
                if (gameOverPlayed == 0)
                {
                    Time.timeScale = 0;
                    GameOverMenu.SetActive(true);
                    gameOver = 1;
                    myAudioSource5.Pause();
                    myAudioSource4.Play();
                    gameOverPlayed = 1;

                }


            }

        }
    }

    public void resume()
    {
        if (escapePressed == 1)
        {

            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            myAudioSource5.Play();
            myAudioSource4.Pause();
            escapePressed = 0;
        }
        else
        {
            if (escapePressed == 0)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                myAudioSource5.Pause();
                myAudioSource4.Play();
                escapePressed = 1;
            }
        }

    }

    public void pause()
    {
        if (escapePressed == 0)
        {

            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            escapePressed = 1;
            pausePlayed = 1;
            myAudioSource5.Pause();
            myAudioSource4.Play();
            pausePlayed = 1;
        }
        else
        {
            if (escapePressed == 1)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                escapePressed = 0;
                myAudioSource4.Pause();
                myAudioSource5.Play();
            }
        }
    }

}



