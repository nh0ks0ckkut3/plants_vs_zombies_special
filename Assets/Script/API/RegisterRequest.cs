using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterRequest
{

    public RegisterRequest(string email, string username, string ingame, string password, int age, string gender)
    {
        this.username = username;
        this.password = password;
        this.age = age;
        this.gender = gender;
        this.email = email;
        this.ingame = ingame;

    }


    public string email { get; set; }
    public string username { get; set; }
    public string ingame { get; set; }
    public string password { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
}
