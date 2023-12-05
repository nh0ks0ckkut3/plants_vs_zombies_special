using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payment : MonoBehaviour
{
  // Start is called before the first frame update
  public float cost;
    public void setAmount()
  {
    PassingToPayment.Instance.amount = cost;
  }
}
