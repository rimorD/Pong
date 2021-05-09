using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    public Text leftScoreboard;
    public Text rightScoreboard;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftPlayerGoal()
    {
        scoreLeft++;
        leftScoreboard.text = scoreLeft.ToString();
    }

    public void RightPlayerGoal()
    {
        scoreRight++;
        rightScoreboard.text = scoreRight.ToString();
    }
}
