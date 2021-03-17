using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Li4u
{
    public partial class MasterPageQL : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["TaiKhoan"]) == "")
            {
                lnkdangnhap.Visible = true;
                lnkdangxuat.Visible = false;
                hlnkTaiKhoan.Visible = false;
            }
            else
            {
                lnkdangnhap.Visible = false;
                lnkdangxuat.Visible = true;
                hlnkTaiKhoan.Visible = true;
                hlnkTaiKhoan.Text = Convert.ToString(Session["TaiKhoan"]);
            }
        }
        protected void tbTim_Click(object sender, EventArgs e)
        {
            int _TK = Convert.ToInt32(drpTim.SelectedValue.ToString());
            string _txTK = txtTim.Text;
            if (_TK == 1)
            {
                Response.Redirect("~/ThuVien/QuanLy/TKTuaSach.aspx?TenSach=" + _txTK);

            }
            if (_TK == 2)
            {
                Response.Redirect("~/ThuVien/QuanLy/TKTenTacGia.aspx?TenTacGia=" + _txTK);
            }
            if (_TK == 3)
            {
                Response.Redirect("~/ThuVien/QuanLy/TKTenNhaXuatBan.aspx?TenNhaXuatBan=" + _txTK);
            }
            if (_TK == 4)
            {
                Response.Redirect("~/ThuVien/QuanLy/TKNamXuatBan.aspx?NamXuatBan=" + _txTK);
            }

        }

        protected void lnkdangxuat_Click(object sender, EventArgs e)
        {
            Session["TaiKhoan"] = "";
            Response.Cookies["TK_Nv"].Expires = DateTime.Now; // Hết hạn trong Cookies, nghĩa là bị loại bỏ        
            lnkdangnhap.Visible = true;
            lnkdangxuat.Visible = false;
            hlnkTaiKhoan.Visible = false;
            Response.Redirect("~/ThuVien/QuanLy/Default.aspx");
        }
        protected void grdTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}