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
    public TMP_InputField edtUser, edtPass;
    public TMP_Text txtError;

    public void kiemTraDangKy()
    {
        var user = edtUser.text;
        var pass = edtPass.text;

        RegisterRequest registerRequest = new RegisterRequest( user, pass);
        CheckRegister(registerRequest);
        StartCoroutine(CheckRegister(registerRequest)); // cấp quyền cho CheckLogin
    }
    IEnumerator CheckRegister(RegisterRequest registerRequest)
    {
        string jsonStringRequest = JsonConvert.SerializeObject(registerRequest);
        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/register", "POST");

        //chuyển đổi chuỗi JSON thành một mảng byte, với mã hóa UTF-8.
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
            RegisterReponse registerReponse = JsonConvert.DeserializeObject<RegisterReponse>(jsonString);
            if (registerReponse.status == 0)
            {
                //đăng ký không thành công
                txtError.text = registerReponse.notification;
                Debug.Log(registerReponse.notification);
            }
            else
            {
                panel.SetActive(false);
                txtError.text = registerReponse.notification;
            }
        }
        request.Dispose();
    }
}
