using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataTableAdapters;

public partial class login : System.Web.UI.Page
{ NhanVienTableAdapter _Nvad = new NhanVienTableAdapter();
   

    protected void Page_Load(object sender, EventArgs e)
    {       

    }
    protected void tbDangNhap_Click(object sender, EventArgs e)
    {
        string _T = txtMaNv.Text;
        string _MK = txtMatKhau.Text;
        Data.NhanVienDataTable _Nvtb = _Nvad.GetNhanVien();
        int _length = _Nvtb.Count;
        for (int i = 0; i < _length; i++)
        {
            if (_T == _Nvtb[i].MaNhanVien.Trim())
            {               
                if (_MK == _Nvtb[i].MatKhau.Trim()){
                    lbCanhBao.Text ="Đã Đăng Nhập!";
                    Session["TaiKhoan"] = _Nvtb[i].MaNhanVien.Trim();                    
                    txtMaNv.Text = "*";                 

                    HttpCookie TK_Nv = new HttpCookie("TK_Nv", _Nvtb[i].MaNhanVien.Trim());
                    TK_Nv.Expires = DateTime.Now.AddDays(1); // Sau 1 ngày hết hạn
                    Response.Cookies.Add(TK_Nv);
                    i = _length-1;        
                }
                    else
                    lbCanhBao.Text = "Tài Khoản Này! Chưa Kích Hoat";
            }
            else
            {
                lbCanhBao.Text = "Không có Tài Khoản Này!";
            }
        }
    }
    }

