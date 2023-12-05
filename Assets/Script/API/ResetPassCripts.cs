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
    public TMP_InputField edtEmail, edtCurrentPass, edtNewPass, edtNewPassRepeat;
    public TMP_Text txtError;

    public void doiMatKhau()
    {
        var currentPass = edtCurrentPass.text;
        var newPass = edtNewPass.text;
        var newPassRepeat = edtNewPass.text;
        var email = edtEmail.text;
    if (email.Length == 0 || currentPass.Length == 0 || newPass.Length == 0 || newPassRepeat.Length == 0) txtError.text = "không bỏ trống";
    else if (currentPass.Equals(newPass)) txtError.text = "mật khẩu mới phải khác mật khẩu cũ";
    else if (!newPassRepeat.Equals(newPass)) txtError.text = "xác nhận mật khẩu không đúng";
    else
    {
      ResetPassRequest resetPassRequest = new ResetPassRequest(email, currentPass, newPass);
      ResetPass(resetPassRequest);
      StartCoroutine(ResetPass(resetPassRequest));
    }
        // cấp quyền cho CheckLogin
    }

    IEnumerator ResetPass(ResetPassRequest resetPassRequest)
    {
        string jsonStringRequest = JsonConvert.SerializeObject(resetPassRequest);

        var request = new UnityWebRequest("https://api-plantsvszombie-bason-694aafc26756.herokuapp.com/users/changedPassword", "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw); // gửi dữ liệu lên server
        request.downloadHandler = new DownloadHandlerBuffer(); // nhận dữ liệu từ server trả về
        request.SetRequestHeader("Content-Type", "application/json");
        // khi gửi dữ liệu lên server, hàm này sẽ tạm dừng trong khi gửi dữ liệu thành công hoặc có lỗi
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
             txtError.text = "có lỗi xảy ra thử lại sau";
              Debug.Log(txtError.text);
        }
        else
        {
            // trả về dữ liệu phản hồi của server
            var jsonString = request.downloadHandler.text.ToString();
            // chuyển đổi kiểu Json thành một đối tượng C#
            ResetPassReponse resetPassReponse = JsonConvert.DeserializeObject<ResetPassReponse>(jsonString);
            if (resetPassReponse.message != "thành công")
            {
                //tài khoản không đúng
                txtError.text = resetPassReponse.message;
                 Debug.Log(resetPassReponse.message);
      }
            else
            {
                txtError.text = resetPassReponse.message;
                //SceneManager.LoadScene("Test");
                panelLogin.SetActive(true);
                pannelResetPass.SetActive(false);
        Debug.Log(resetPassReponse.message);
      }
        }
        request.Dispose();
    }
}
