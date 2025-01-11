using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCut : MonoBehaviour
{
     [SerializeField] private Line_checker lineChecker;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            if (!lineChecker.lineCut.Contains(other.GetComponent<LineRenderer>()))
            {
                lineChecker.lineCut.Add(other.GetComponent<LineRenderer>());
            }

        }
    }
}
