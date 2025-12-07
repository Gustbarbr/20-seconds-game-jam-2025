using TMPro;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clockText;
    [SerializeField] float remainingTime;

    private void Update()
    {
        if (remainingTime > 0)
            remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            //End
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
