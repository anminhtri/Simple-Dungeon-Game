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
    public GameObject yellowKey;
    public GameObject blueKey;
    public GameObject redKey;
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
    public void PickupYellowKey()
    {
        yellowKey.transform.DOMove(player.transform.position, pickupTime).OnComplete(() =>
            {
                DOTween.Kill(yellowKey.transform);
                yellowKey.SetActive(false);
            });
    }
    public void OpenYellowDoor()
    {
        yellowDoor.transform.DOMoveY(yellowDoor.transform.position.y - moveDistance, moveTime);
    }
    public void PickupBlueKey()
    {
        blueKey.transform.DOMove(player.transform.position, pickupTime).OnComplete(() =>
            {
                DOTween.Kill(blueKey.transform);
                blueKey.SetActive(false);
            });
    }
    public void OpenBlueDoor()
    {
        blueDoor.transform.DOMoveY(blueDoor.transform.position.y - moveDistance, moveTime);
    }
    public void PickupRedKey()
    {
        redKey.transform.DOMove(player.transform.position, pickupTime).OnComplete(() =>
            {
                DOTween.Kill(redKey.transform);
                redKey.SetActive(false);
            });
    }
    public void OpenRedDoor()
    {
        redDoor.transform.DOMoveY(redDoor.transform.position.y - moveDistance, moveTime);
    }
}
