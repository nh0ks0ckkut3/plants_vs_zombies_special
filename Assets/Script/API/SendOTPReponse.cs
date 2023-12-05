using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendOTPReponse 
{
    public SendOTPReponse(string message)
    {
        this.message = message;
    }

    public string message { get; set; }
}
