using UnityEngine;

public class MSCupLogoController : MonoBehaviour
{

    public Camera cam;
    private float maxWidth;

    void Start ()
    {
        if (cam == null)
            cam = Camera.main;

        var corner = new Vector3(Screen.width, Screen.height, 0f);
        var targetWidth = cam.ScreenToWorldPoint(corner);
        float playerWidth = renderer.bounds.extents.x;
        maxWidth = targetWidth.x - playerWidth;
    }
    
    void FixedUpdate ()
    {
        var currentPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        float targetWidth = Mathf.Clamp(currentPosition.x, -maxWidth, maxWidth);
        var newPosition = new Vector3(targetWidth, 0f, 0f);
        rigidbody2D.MovePosition(newPosition);
    }
}
