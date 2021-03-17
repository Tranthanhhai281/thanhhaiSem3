using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Li4u
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["DGDangNhap"]) == "")
            {
                lnkdangxuat.Visible = false;
                hlnkTaiKhoan.Visible = false;
                lbtaikhoan.Visible = false;
            }
            else
            {
                lnkdangxuat.Visible = true;
                hlnkTaiKhoan.Visible = true;
                lbtaikhoan.Visible = true;
                hlnkTaiKhoan.Text = Convert.ToString(Session["DGDangNhap"]);
            }
        }
        protected void btTimKiem_Click(object sender, EventArgs e)
        {
            int _TK = Convert.ToInt32(drpTim.SelectedValue.ToString());
            string _txTK = txtTim.Text.Trim();
            if (_TK == 1)
            {
                Response.Redirect("~/ThuVien/DocGia/TKTuaSach.aspx?TenSach=" + _txTK);
            }
            if (_TK == 2)
            {
                Response.Redirect("~/ThuVien/DocGia/TKTenTacGia.aspx?TenTacGia=" + _txTK);
            }
            if (_TK == 3)
            {
                Response.Redirect("~/ThuVien/DocGia/TKTenNhaXuatBan.aspx?TenNhaXuatBan=" + _txTK);
            }
            if (_TK == 4)
            {
                Response.Redirect("~/ThuVien/DocGia/TKNamXuatBan.aspx?NamXuatBan=" + _txTK.Trim());
            }
        }
        protected void MeNu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void lnkDangXuat_Click(object sender, EventArgs e)
        {
            Session["DGDangNhap"] = "";
            Response.Cookies["DGDangNhap"].Expires = DateTime.Now; // Hết hạn trong Cookies, nghĩa là bị loại bỏ
            Response.Redirect("~/ThuVien/DocGia/Default.aspx");
            lnkdangxuat.Visible = false;
            hlnkTaiKhoan.Visible = false;
            lbtaikhoan.Visible = false;
        }
    }
}