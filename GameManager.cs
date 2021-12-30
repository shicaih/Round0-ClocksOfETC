using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerChar;
    public GameObject playerSphere;
    public GameObject final;
    public float capHeight = 7.5f;
    public Text finalText, finalExtraText, unitsNum;
    public int collectable = 12;
    public AudioSource winAudio, loseAudio;

    string winText = "Congratulations!";
    string loseText = "Hey babe work harder next time!";
    string winExtraText = "You will graduate with honor, but remember to save some time for your friends and family~ ";
    string loseExtraText = "cause' you heart need to be in the work!";

    bool gameOn = true;
    // Start is called before the first frame update
    void Start()
    {
        gameOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
        gameStateValidate();
        Debug.Log(gameOn);

        void updateUI()
        {
            unitsNum.text = (collectable * 4).ToString();
        }

        void playerWin()
        {
            winAudio.Play();
            finalText.text = winText;
            finalExtraText.text = winExtraText;
            final.SetActive(true);
            Destroy(playerChar);
            Destroy(playerSphere);
        }

        void playerLose()
        {
            loseAudio.Play();
            finalText.text = loseText;
            finalExtraText.text = loseExtraText;
            final.SetActive(true);
            Destroy(playerChar);
            Destroy(playerSphere);
        }

        void gameStateValidate()
        {
            if (gameOn && collectable == 0)
            {
                playerWin();
                gameOn = false;
            }

            if (gameOn && playerSphere.transform.position.y < -20f)
            {
                playerLose();
                gameOn = false;
            }
        }
    }
}
