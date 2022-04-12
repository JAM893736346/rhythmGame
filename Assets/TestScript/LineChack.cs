using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag=="point")
        {
            GetComponent<SpriteRenderer>().color=Color.red;
            StartCoroutine(nameof(ChangeWhite));
        }
    }
    IEnumerator ChangeWhite()
    {
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color=Color.white;
    }
}
