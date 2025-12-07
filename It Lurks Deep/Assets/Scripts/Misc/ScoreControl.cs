using TMPro;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public float score;

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
