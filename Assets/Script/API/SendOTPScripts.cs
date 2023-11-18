using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SendOTPScripts : MonoBehaviour
{
    public GameObject panelOTP, panelResetPass;
    public TMP_InputField edtUser;
    public TMP_Text txtError;

    public void layOTP()
    {
        var email = edtUser.text;
        SendOTPRequest sendOTPRequest = new SendOTPRequest(email);
        SendOTP(sendOTPRequest);
        StartCoroutine(SendOTP(sendOTPRequest)); // cấp quyền cho CheckLogin
    }

    IEnumerator SendOTP(SendOTPRequest sendOTPRequest)
    {
        string jsonStringRequest = JsonConvert.SerializeObject(sendOTPRequest);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/send-otp", "POST");
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
            SendOTPReponse sendOTPReponse = JsonConvert.DeserializeObject<SendOTPReponse>(jsonString);
            if (sendOTPReponse.status == 0)
            {
                //tài khoản không đúng
                txtError.text = sendOTPReponse.notification;
                Debug.Log(sendOTPReponse.notification);
            }
            else
            {
                txtError.text = sendOTPReponse.notification;
                panelOTP.SetActive(false);
                panelResetPass.SetActive(true);
                //SceneManager.LoadScene("Test");
            }
        }
        request.Dispose();
    }
}
