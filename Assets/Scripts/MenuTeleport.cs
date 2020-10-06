using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTeleport : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    public Direction dir;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Plane")
        {
            Vector2 vector = new Vector2();

            switch (dir)
            {
                case Direction.Left:
                    vector = new Vector2(-this.transform.position.x - 10f, col.transform.position.y);
                    break;
                case Direction.Right:
                    vector = new Vector2(-this.transform.position.x + 10f, col.transform.position.y);
                    break;
            }

            col.transform.position = vector;
        }
    }
}
