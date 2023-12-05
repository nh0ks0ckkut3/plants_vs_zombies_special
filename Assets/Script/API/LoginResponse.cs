using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginResponse
{
    public LoginResponse(string _id, string email, string username, int __v, string ingame, int age, string gender, int level)
    {
        this._id = _id;
        this.email = email;
        this.username = username;
        this.__v = __v;
        this.ingame = ingame;
        this.age = age;
        this.gender = gender;
        this.level = level;
        this.error = "false";
    }

    public string _id { get; set; }
    public string email { get; set; }
    public string username { get; set; }
    public string ingame { get; set; }  
    public int age {  get; set; }
    public string gender { get; set; }   
    public int __v { get; set; }   
    public int level { get; set; }
    public string error { get; set; }
}
