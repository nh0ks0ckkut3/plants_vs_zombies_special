using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegisterScripts : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField edtEmail, edtUsername, edtIngame, edtPassword, edtAge, edtGender;
    public TMP_Text txtError;
    public GameObject pannelLogin;
  //"email":"pr0h0afccf@gmail.com",
  //"username":"0osupr",
  //"ingame":"Đoàn Thanh Hòa",
  //"password":"12345",
  //"age":27,
  //"gender":"name"
  public void kiemTraDangKy()
    {
        var email = edtEmail.text;
        var username = edtUsername.text;
        var password = edtPassword.text;
        int age;
        var gender = edtGender.text;
        var ingame = edtIngame.text;
    if (int.TryParse(edtAge.text, out age))
    {
        RegisterRequest registerRequest = new RegisterRequest( email, username, ingame, password, age, gender);
        CheckRegister(registerRequest);
        StartCoroutine(CheckRegister(registerRequest));
    }
    else
    {
        txtError.text = "tuổi phải là số";
    }
  }
    IEnumerator CheckRegister(RegisterRequest registerRequest)
    {
        string jsonStringRequest = JsonConvert.SerializeObject(registerRequest);
        var request = new UnityWebRequest("https://api-plantsvszombie-bason-694aafc26756.herokuapp.com/users/register", "POST");

        //chuyển đổi chuỗi JSON thành một mảng byte, với mã hóa UTF-8.
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw); // gửi dữ liệu lên server
        request.downloadHandler = new DownloadHandlerBuffer(); // nhận dữ liệu từ server trả về
        request.SetRequestHeader("Content-Type", "application/json");
        // khi gửi dữ liệu lên server, hàm này sẽ tạm dừng trong khi gửi dữ liệu thành công hoặc có lỗi
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
      txtError.text = "có lỗi xảy ra khi đăng ký, thử lại sau";
        }
        else
        {
            // trả về dữ liệu phản hồi của server
            var jsonString = request.downloadHandler.text.ToString();
            // chuyển đổi kiểu Json thành một đối tượng C#
            RegisterReponse registerReponse = JsonConvert.DeserializeObject<RegisterReponse>(jsonString);
            
            panel.SetActive(false);
            pannelLogin.SetActive(true);
            txtError.text = registerReponse.message;
    }
        request.Dispose();
    }
}
