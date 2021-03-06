using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject LevelControl;
    [SerializeField] private GameObject Player;
    [SerializeField] private Image fillImage;
    public GameObject score;
    public GameObject winGameText;
    public float totalTime = 0f;
    private float elapsedTime = 0f;

    private string winningText = "You win!";

    // Update is called once per frame
    void Update()
    {
        //only count if the player is moving (so not during the countdown to start lol)
        if (Player.GetComponent<PlayerDemoMovementController>().canMove)
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime > totalTime)
        {
            // stop the player from moving when time finishes
            Player.GetComponent<PlayerDemoMovementController>().canMove = false;
            // turn off the progress bar
            gameObject.SetActive(false);
            // display winning text
            winGameText.GetComponent<TextMeshProUGUI>().text = winningText;
            Vector3 pos = new Vector3(0, -90, 0);
            score.GetComponent<RectTransform>().position = winGameText.GetComponent<RectTransform>().position + pos;
        }

        //progress is the elapsed time divided by the total amount of time the map should take
        fillImage.fillAmount = elapsedTime / totalTime;
    }
}