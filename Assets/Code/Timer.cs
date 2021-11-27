using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public Text timestring; 
    public Text score;
    public float secondsnow = 120f;
    public float otherseconds=128f;
    void Update()
    {
        secondsnow -= Time.deltaTime;
        otherseconds-=Time.deltaTime;
        timestring.text = "Game Timer: "+(secondsnow).ToString("00")+" seconds left";
        if (secondsnow < 0)
        {
            if(int.Parse(score.text)<10){
                timestring.text="Game Over: Your score has no medal. This level is restarting now...";
            }
            else if(int.Parse(score.text)>=10 && int.Parse(score.text)<20){
            timestring.text="Game Over: Your score is a bronze medal. This level is restarting now...";
            }
            else if(int.Parse(score.text)>=20 && int.Parse(score.text)<35){
                timestring.text="Game Over: Your score is a silver medal. This level is restarting now...";
            }
            else if(int.Parse(score.text)>=35){
                timestring.text="Game Over: Your score is a gold medal. This level is restarting now...";
            }
        }
        if(otherseconds<0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
}
