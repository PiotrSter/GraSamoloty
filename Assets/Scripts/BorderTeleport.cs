using System.Collections;
using System.Collections.Generic;
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
        if (obj.gameObject.tag == "Enemy")
        {
            Vector2 vector = new Vector2();

            switch (dir)
            {
                case Direction.Top:
                    vector = new Vector2(obj.transform.position.x, -this.transform.position.y + 7.0f);
                    break;

                case Direction.Left:
                    vector = new Vector2(-this.transform.position.x - 7.0f, obj.transform.position.y);
                    break;

                case Direction.Bot:
                    vector = new Vector2(obj.transform.position.x, -this.transform.position.y - 7.0f);
                    break;

                case Direction.Right:
                    vector = new Vector2(-this.transform.position.x + 7.0f, obj.transform.position.y);
                    break;
            }

            obj.transform.position = vector;
        }
        else if (obj.name == "PlayerDetection")
        {
            Vector2 vector = new Vector2();

            switch (dir)
            {
                case Direction.Top:
                    vector = new Vector2(obj.transform.position.x, -this.transform.position.y + 10.0f);
                    break;

                case Direction.Left:
                    vector = new Vector2(-this.transform.position.x - 10.0f, obj.transform.position.y);
                    break;

                case Direction.Bot:
                    vector = new Vector2(obj.transform.position.x, -this.transform.position.y - 10.0f);
                    break;

                case Direction.Right:
                    vector = new Vector2(-this.transform.position.x + 10.0f, obj.transform.position.y);
                    break;
            }

            obj.transform.parent.position = vector;
        }
        else if (obj.gameObject.tag == "Boss")
        {
            Vector2 vector = new Vector2();

            switch (dir)
            {
                case Direction.Top:
                    vector = new Vector2(obj.transform.position.x, -this.transform.position.y + 15.0f);
                    break;

                case Direction.Left:
                    vector = new Vector2(-this.transform.position.x - 15.0f, obj.transform.position.y);
                    break;

                case Direction.Bot:
                    vector = new Vector2(obj.transform.position.x, -this.transform.position.y - 15.0f);
                    break;

                case Direction.Right:
                    vector = new Vector2(-this.transform.position.x + 15.0f, obj.transform.position.y);
                    break;
            }

            obj.transform.position = vector;
        }
    }
}
