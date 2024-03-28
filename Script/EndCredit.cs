using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCredit : MonoBehaviour
{
    [SerializeField] private GameObject EndcreditOb;
    public void EndCreditOn()
    {
        EndcreditOb.SetActive(true);
    }

    public void EndCreditOff()
    {
        EndcreditOb.SetActive(false);
    }
}
