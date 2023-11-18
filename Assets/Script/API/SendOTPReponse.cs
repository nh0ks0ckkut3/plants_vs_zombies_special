using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendOTPReponse 
{
    public SendOTPReponse(string notification, int status)
    {
        this.notification = notification;
        this.status = status;
    }

    public string notification { get; set; }
    public int status { get; set; }
}
