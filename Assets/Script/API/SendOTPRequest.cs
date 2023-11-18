using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendOTPRequest
{
    public SendOTPRequest(string username)
    {
        this.username = username;
    }

    public string username { get; set; }
}
