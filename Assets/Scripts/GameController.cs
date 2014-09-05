using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Sprite[] sprites;
    public Camera cam;
    public GameObject phone;
    private float maxWidth;
    public float timeLeft = 30;

    public GUIText timerText;
    public GUIText gameOverText;
    public GUIText restartText;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        var corner = new Vector3(Screen.width, Screen.height, 0f);
        var targetWidth = cam.ScreenToWorldPoint(corner);
        float phoneWidth = phone.renderer.bounds.extents.x;
        maxWidth = targetWidth.x - phoneWidth;
        StartCoroutine(Spawn());
        UpdateTimerText();
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
            UpdateTimerText();
    }

    private string UpdateTimerText()
    {
        return timerText.text = "Time Left: " + Mathf.RoundToInt(timeLeft).ToString();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (timeLeft > 0)
        {
            var spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth), transform.position.y, 0f);
            var spawnRotation = Quaternion.identity;

            Instantiate(phone, spawnPosition, spawnRotation);
            var spriteNum = Random.Range(0, sprites.Length - 1);
            phone.GetComponent<SpriteRenderer>().sprite = sprites[spriteNum];
            phone.tag = spriteNum < 3 ? "Bad" : "Good";
            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
        }

        yield return new WaitForSeconds(2f);

        gameOverText.enabled = true;
        restartText.enabled = true;

    }


}
