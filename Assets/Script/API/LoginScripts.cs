using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class LoginScripts : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField edtUser, edtPass;
    public TMP_Text txtError;

    public void kiemTraDangNhap()
    {
        var user = edtUser.text;
        var pass = edtPass.text;

        LoginRequest loginRequest = new LoginRequest(user, pass);
        CheckLogin(loginRequest);
        StartCoroutine(CheckLogin(loginRequest)); // cấp quyền cho CheckLogin
    }

    IEnumerator CheckLogin(LoginRequest loginRequest)
    {
        string jsonStringRequest = JsonConvert.SerializeObject(loginRequest);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/login", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw); // gửi dữ liệu lên server
        request.downloadHandler = new DownloadHandlerBuffer(); // nhận dữ liệu từ server trả về
        request.SetRequestHeader("Content-Type", "application/json");
        // khi gửi dữ liệu lên server, hàm này sẽ tạm dừng trong khi gửi dữ liệu thành công hoặc có lỗi
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            // nếu result của yêu cầu không phải là success =>>>> lỗi
            Debug.Log(request.error);
        }
        else
        {
            // trả về dữ liệu phản hồi của server
            var jsonString = request.downloadHandler.text.ToString();
            // chuyển đổi kiểu Json thành một đối tượng C#
            LoginResponse loginReponse = JsonConvert.DeserializeObject<LoginResponse>(jsonString);
            if (loginReponse.status == 0)
            {
                //tài khoản không đúng
                txtError.text = loginReponse.notification;
                Debug.Log(loginReponse.notification);
            }
            else
            {
                panel.SetActive(false);
                txtError.text = loginReponse.notification;
                //SceneManager.LoadScene("Test");
            }
        }
        request.Dispose();
    }

}
