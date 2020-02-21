using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TilesSpawningWall))]
public class FloatingTile : MonoBehaviour
{
    public TilesSpawningWall tilesSendingHole;
    private const string PLAYER_TAG = "Player";
    private const string TILE_PASSING_WALL_TAG = "TilePassingWall";


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != PLAYER_TAG &&
        other.gameObject.tag != TILE_PASSING_WALL_TAG) {
            tilesSendingHole.ChangeDirection();
            Debug.Log("Hit non-player object");
        }
        Debug.Log("OnTriggerEnter");
    }
}
