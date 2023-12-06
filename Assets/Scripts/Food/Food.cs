using UnityEngine;

public class Food : MonoBehaviour
{
    public int Health = 1;

    public void SetInActive() =>
        gameObject.SetActive(false);
}