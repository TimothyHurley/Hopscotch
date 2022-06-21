using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Move : MonoBehaviour
{
    // Reduces z axis of object by 8 and destroys object if z value is negative.
    public void Move()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z - 8);

        if (transform.position.z < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
