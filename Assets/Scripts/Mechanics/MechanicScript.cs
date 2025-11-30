using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MechanicScript : MonoBehaviour
{
    public GameObject player;
    public GameObject yellowDoor;
    public GameObject blueDoor;
    public GameObject redDoor;
    public float moveDistance;
    public float moveTime;
    public float pickupTime;

    public void PickupItem(GameObject gameObject)
    {
        gameObject.transform.DOMove(player.transform.position, pickupTime).OnComplete(() =>
            {
                DOTween.Kill(gameObject.transform);
                gameObject.SetActive(false);
            });
    }
    public void OpenDoor (GameObject gameObject)
    {
        gameObject.transform.DOMoveY(gameObject.transform.position.y - moveDistance, moveTime);
    }

    public void OpenYellowDoor()
    {
        OpenDoor(yellowDoor);
    }

    public void OpenBlueDoor()
    {
        OpenDoor(blueDoor);
    }

    public void OpenRedDoor()
    {
        OpenDoor(redDoor);
    }
}
