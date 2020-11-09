using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private PlayerControl playerControl;

    private void Awake()
    {
        playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerControl.onPlayerDetectionTriggerEnter2D(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerControl.onPlayerDetectionTriggerExit2D(col);
    }
}
