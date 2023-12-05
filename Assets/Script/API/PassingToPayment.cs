using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingToPayment : MonoBehaviour
{
  // Start is called before the first frame update
  public float amount, cost;
  public static PassingToPayment Instance;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
  public void setAmount()
  {
    amount = cost;
  }
}
