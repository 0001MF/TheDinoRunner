using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int CoinValue = 1;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Score.instance.updateScore(CoinValue);
        }
    }
}
