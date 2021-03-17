using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataTableAdapters;

public partial class ThuVien_QuanLy_ThemTacGia : System.Web.UI.Page
{
    public void ham(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { lbthongbaorong.Visible = false; }

    }
    protected void lbThem_Click(object sender, EventArgs e)
    {
        bool _cotg = false;
        string _tentacgia = txtTacGia.Text;
        TacGiaTableAdapter tacgia_ = new TacGiaTableAdapter();
        Data.TacGiaDataTable ban_tacgia = tacgia_.GetTacGia();
        /*chèn số*/
        int luu = 0;
        int _stt;
        bool _co = false;

        if (ban_tacgia.Count > 0)                   //có dữ liệu.
        {
            for (int i = 0; i < ban_tacgia.Count-1; i++)
            {
                if (ban_tacgia[i + 1].MaTacGia - ban_tacgia[i].MaTacGia != 1)//có lỗ rỗng
                {
                    _co = true;
                    luu = i;
                    i = ban_tacgia.Count - 1;
                }
            }
            if (ban_tacgia[0].MaTacGia != 1) //vị trí 0 khác 1.
                _stt = 1;
            else
            {
                if (_co == true)//có lỗ trống.
                    _stt = ban_tacgia[luu].MaTacGia + 1;
                else
                    _stt = ban_tacgia[ban_tacgia.Count - 1].MaTacGia + 1;
            }
        }
        else
        {
            _stt = 1;
        }
        /*Kết thúc chèn*/
        if (_tentacgia== "")
        {
            lbthongbaorong.Visible = true;
        }
        else  //thêm tác giả khi txttacgia.text!=""
        {
            lbthongbaorong.Visible = false;
            if (ban_tacgia.Count > 0)
            {
                for (int i = 0; i < ban_tacgia.Count; i++)
                {
                    if (ban_tacgia[i].TenTacGia.Trim() ==_tentacgia)
                    {
                        _cotg = false;
                        i = ban_tacgia.Count;
                    }
                    else
                        _cotg = true;
                }
            }
            else
            {
                tacgia_.ThemTacGia(_stt, _tentacgia);
                ham("Tác Giả " + _tentacgia + " Đã Được Lưu Vào Danh Sách");
            }


            if (_cotg == true)
            {
                tacgia_.ThemTacGia(_stt, _tentacgia);
                ham("Tác Giả "+_tentacgia + " Đã Được Lưu Vào Danh Sách");
            }
            else
            {
                ham("Tác Giả "+_tentacgia+" Đã Có Trong Danh Sách");
            }
        }
    }
    protected void lbKhongThem_Click(object sender, EventArgs e)
    {
        txtTacGia.Text = "";
        string duong_dan=Request.QueryString["duongdan"];
        if (duong_dan != "")
            Response.Redirect("~/ThuVien/QuanLy/"+duong_dan);
        else
            Response.Redirect("~/ThuVien/QuanLy/Default.aspx");
    }
}
