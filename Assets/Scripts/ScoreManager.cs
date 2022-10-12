using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void IncrementScore()
    {
        score+=1;
        scoreText.text = score.ToString();
    }
}
