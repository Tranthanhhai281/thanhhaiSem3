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
        if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            btThem.Enabled = false;
        }
        else
        {
            btThem.Enabled = true;
            if (!IsPostBack)
            {
                lbthongbao.Visible = false;
            }
        }
    }
    protected void lbThem_Click(object sender, EventArgs e)
    {
        bool _conxb = false;
        NhaXuatBanTableAdapter nhaxuatban_ = new NhaXuatBanTableAdapter();
        Data.NhaXuatBanDataTable ban_nxb = nhaxuatban_.GetNXB();
        /*chèn số*/
        int luu = 0;
        int _stt;
        bool _co = false;

        if (ban_nxb.Count>0)                //có dữ liệu.
        {
            for (int i = 0; i <ban_nxb.Count-1;i++)
            {
                if (ban_nxb[i+1].MaNhaXuatBan - ban_nxb[i].MaNhaXuatBan != 1)//có lỗ rỗng
                {
                    _co = true;
                    luu = i;
                    i = ban_nxb.Count - 1;
                }
            }
            if (ban_nxb[0].MaNhaXuatBan != 1) //vị trí 0 khác 1.
                _stt = 1;
            else
            {
                if (_co == true)//có lỗ trống.
                    _stt = ban_nxb[luu].MaNhaXuatBan + 1;
                else
                    _stt = ban_nxb[ban_nxb.Count - 1].MaNhaXuatBan + 1;
            }
        }
        else
        {
            _stt = 1;
        }
        /*Kết thúc chèn*/
        if (txtNhaXuatBan.Text == "")
        {
            lbthongbao.Visible = true;
        }
        else
        {
            lbthongbao.Visible = false;
            if(ban_nxb.Count>0)
            {
                for (int i = 0; i < ban_nxb.Count;i++)
                {
                    if (ban_nxb[i].TenNhaXuatBan.Trim() == txtNhaXuatBan.Text.Trim())
                    {
                        _conxb = false;
                        i = ban_nxb.Count;
                    }
                    else
                        _conxb = true;
                }
            }
            else
            {
                nhaxuatban_.ThemNXB(_stt, txtNhaXuatBan.Text);
                ham("NXB " + txtNhaXuatBan.Text + " Đã Được Lưu Vào Danh Sách");
            }


            if (_conxb == true)
            {
                nhaxuatban_.ThemNXB(_stt, txtNhaXuatBan.Text);
                ham("NXB " + txtNhaXuatBan.Text + " Đã Được Lưu Vào Danh Sách");
            }
            else
            {
                ham("NXB " + txtNhaXuatBan.Text.Trim() + "Đã Có Trong Danh Sách");
            }
        }
    }
    protected void lbKhongThem_Click(object sender, EventArgs e)
    {
        string duong_dan = Request.QueryString["duongdan"];
        if (duong_dan != "")
            Response.Redirect("~/ThuVien/QuanLy/" + duong_dan);
        else
            Response.Redirect("~/ThuVien/QuanLy/Default.aspx");
    }
}
