using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for LayThoiGian
/// </summary>
public class LayThoiGian
{
    public string Get_Day()
    {
        DateTime dt = DateTime.Now;
        string str = dt.ToString("dd/MM/yyyy").Trim();
        str = str.Substring(0, 2);
        return str;
    }
    public string Get_Month()
    {
        DateTime dt = DateTime.Now;
        string str = dt.ToString("dd/MM/yyyy").Trim();
        str = str.Substring(3, 2);
        return str;
    }
    public string Get_Year()
    {
        DateTime dt = DateTime.Now;
        string str = dt.ToString("dd/MM/yyyy").Trim();
        str = str.Substring(6, 4);
        return str;
    }
    public bool SoSanhThoiGian(int ngayht, int thanght, int namht, int ngay, int thang, int nam)
    {
        //return true chưa hết hạn
        if (namht - nam == 0)
        {
            if (thanght - thang== 0)
            {
                if (ngayht - ngay <=0)
                    return true;
                else
                    return false;
            }
            else
                if (thanght - thang <0)
                    return true;
                else
                    return false;
        }
        else
            if (namht - nam < 0)
                return true;
            else
                return false;
    }
    public bool Luot_Muon(int ngayht, int thanght, int namht, int ngay, int thang, int nam)
    {
        //return true chưa hết hạn
        if (namht - nam == 0)
        {
            if (thanght - thang == 0)
            {                
                if (ngayht - ngay >= 0)
                    return true;
                else
                    return false;
            }
            else
                if (thanght - thang > 0)
                    return true;
                else
                    return false;
        }
        else
            if (namht - nam > 0)
                return true;
            else
                return false;
    }
    public string[] catchuoi(string s,char t)
    {
        string[] _A = new string[10];
        _A=s.Split(t);
        return _A;
    }
   /* public bool chuoivangay(string d_ate)
    {
        string[] _substr = d_ate.Split('/');
        if (_substr.Length == 3)
        {
            if (_substr[0].Length == 2 && _substr[1].Length == 2 && _substr[2].Length >= 4)
            {
                if (_substr[0][0] == '0' || _substr[0][0] == '1' || _substr[1][0] == '2' || _substr[0][0] == '3' && char.IsDigit(_substr[0][1]) == true)
                  {
                    if (Convert.ToInt32(_substr[0]) <= 31 && Convert.ToInt32(_substr[0]) > 0)
                    {
                        if (_substr[1][0] == '1' || _substr[1][0] == '0' && char.IsDigit(_substr[1][1]) == true)
                        {
                            if (Convert.ToInt32(_substr[1]) > 0 && Convert.ToInt32(_substr[1]) <= 12)
                            {
                                if (char.IsDigit(_substr[2][0]) == true && char.IsDigit(_substr[2][1]) == true && char.IsDigit(_substr[2][2]) == true && char.IsDigit(_substr[2][3]) == true)
                                    return true;
                                else
                                    return false;//không được năm
                            }
                            else
                                return false;//không được tháng
                        }
                        else
                            return false;//không được tháng
                    }
                    else
                        return false;//không được ngày
                }
                else
                    return false;//"không được ngày"
            }
            else
                return false;//"không được độ dài"
        }
        return false; //"không được độ dài chuỗi"
    }*/
    public bool chuoivangay(string d_ate)
    {
        string[] _substr = d_ate.Split('/');
        if (_substr.Length == 3)
        {
            if (_substr[0].Length == 2 && _substr[1].Length == 2 && _substr[2].Length >= 4)
            {
                return true;
            }
            else
                return false;//"không được độ dài"
        }
        return false; //"không được độ dài chuỗi"
    }
}
