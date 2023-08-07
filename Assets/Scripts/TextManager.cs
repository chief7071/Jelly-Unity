using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public static TextManager instance;
    private int score;

    public void IncreaseScore()
    {
        score++;
        instance.textMesh.text = "Altcoin bag: " + score;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add other logic here if needed for the TextManager script
    }
}
