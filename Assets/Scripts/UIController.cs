using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Converst Score input to text and puts it into the scoreText UI Object.
    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
