using UnityEngine;

public class BorderTeleport : MonoBehaviour
{
    private Transform player;

    public enum Direction
    {
        Top,
        Left,
        Bot,
        Right
    }

    public Direction dir;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Vector2 vector = new Vector2();

            switch (dir)
            {
                case Direction.Top:
                    vector = new Vector2(player.position.x, -this.transform.position.y + 5.0f);
                    break;

                case Direction.Left:
                    vector = new Vector2(-this.transform.position.x - 5.0f, player.position.y);
                    break;

                case Direction.Bot:
                    vector = new Vector2(player.position.x, -this.transform.position.y - 5.0f);
                    break;

                case Direction.Right:
                    vector = new Vector2(-this.transform.position.x + 5.0f, player.position.y);
                    break;
            }

            player.position = vector;

        }
    }
}
