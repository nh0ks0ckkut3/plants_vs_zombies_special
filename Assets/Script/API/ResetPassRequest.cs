using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPassRequest
{
    public ResetPassRequest(string email, string currentPass,  string newPass)
    {
        this.currentPass = currentPass;
        this.newPass = newPass;
        this.email = email;
    }

    public string currentPass { get; set; }
    public string newPass { get; set; }
    public string email { get; set; }
}
