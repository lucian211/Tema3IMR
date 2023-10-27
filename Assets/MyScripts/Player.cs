using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject score;
    bool scoreActive = false;
    float timeScore = 4.0f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void FixedUpdate()
    {
        if(scoreActive==true)
        {
            timeScore = timeScore - Time.deltaTime;
            if(timeScore<=0)
            {
                scoreActive = false;
                timeScore = 4.0f;
                score.SetActive(false);
            }
        }
    }

    public void IncreaseScore(Vector3 throwPosition, Vector3 targetPosition)
    {
        float distance = Vector3.Distance(targetPosition, throwPosition);
        int points = (int)distance;
        //  Debug.Log(points);
        score.SetActive(true);
        scoreActive = true;
        scoreText.text = points.ToString()+ " Points";

    }
}