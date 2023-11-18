using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ResetPassCripts : MonoBehaviour
{
    public GameObject panelLogin, pannelResetPass;
    public TMP_InputField edtEmail, edtPass, edtOTP;
    public TMP_Text txtError;

    public void doiMatKhau()
    {
        var user = edtEmail.text;
        var pass = edtPass.text;
        int otp;
        int.TryParse(edtOTP.text, out otp);

        ResetPassRequest resetPassRequest = new ResetPassRequest(user, otp, pass);
        ResetPass(resetPassRequest);
        StartCoroutine(ResetPass(resetPassRequest)); // cấp quyền cho CheckLogin
    }

    IEnumerator ResetPass(ResetPassRequest resetPassRequest)
    {
        string jsonStringRequest = JsonConvert.SerializeObject(resetPassRequest);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/reset-password", "POST");
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
            ResetPassReponse resetPassReponse = JsonConvert.DeserializeObject<ResetPassReponse>(jsonString);
            if (resetPassReponse.status == 0)
            {
                //tài khoản không đúng
                txtError.text = resetPassReponse.notification;
                Debug.Log(resetPassReponse.notification);
            }
            else
            {
                txtError.text = resetPassReponse.notification;
                //SceneManager.LoadScene("Test");
                panelLogin.SetActive(true);
                pannelResetPass.SetActive(false);
            }
        }
        request.Dispose();
    }
}
