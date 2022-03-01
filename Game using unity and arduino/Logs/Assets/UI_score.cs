using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_score : MonoBehaviour
{   
    private TextMeshProUGUI TextMesh;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    public void add()
    {
        score++;
             
    }
    // Update is called once per frame
    void Update()
    {
        TextMesh.text = score.ToString();
        
    }
}
