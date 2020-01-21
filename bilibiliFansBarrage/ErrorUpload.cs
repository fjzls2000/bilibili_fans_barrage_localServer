using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace bilibiliFansBarrage
{
    public class ErrorUpload
    {
        public static string HttpGet(string url)
        {
            WebRequest myWebRequest = WebRequest.Create(url);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Stream ReceiveStream = myWebResponse.GetResponseStream();
            string responseStr = "";
            if (ReceiveStream != null)
            {
                StreamReader reader = new StreamReader(ReceiveStream, Encoding.UTF8);
                responseStr = reader.ReadToEnd();
                reader.Close();
            }
            myWebResponse.Close();
            return responseStr;
        }


        public static void UploadError(string Error)
        {
            try
            {
                HttpGet("http://ft2.club:1088/e=" + System.Web.HttpUtility.UrlEncode(Error));
            }
            catch (Exception) { }
        }
        public static void AskUploadError(string Error)
        {
            if (MessageBox.Show(Error + "\n\nѡ��'ȷ��'�ϱ�����������ߣ����򽫲����ϴ������κθ�����Ϣ��", "���ݿ�����ʱ��������", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UploadError(Error);
            }
        }
    }
}