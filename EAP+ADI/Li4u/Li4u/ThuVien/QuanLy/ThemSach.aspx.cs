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

public partial class ThuVien_QuanLy_ThemSach : System.Web.UI.Page
{
    public void ham(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }
   
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            btNhap.Enabled = false;
        }
        else
        {
            btNhap.Enabled = true;
            if (!IsPostBack)
            {
                lsttacgia.Visible = false;
                btxoaTG.Visible = false;
                btxoanxb.Visible = false;
                lstnxb.Visible = false;
                lstxbvalue.Visible = false;
                lsttgvalue.Visible = false;

                lbgia.Visible = false;
                lbsoluong.Visible = false;
                lbsotrang.Visible = false;
                lbtensach.Visible = false;
                lbnamxuatban.Visible = false;
            }
        }
    }
    protected void btNhap_Click(object sender, EventArgs e)
    {
        SachTableAdapter S_ach = new SachTableAdapter();
        Data.SachDataTable ban_sachAll = S_ach.GetSach();
        VietTableAdapter _viet = new VietTableAdapter();
        XuatBanTableAdapter _xuatban = new XuatBanTableAdapter();
        DateTime _h=DateTime.Now;
        string _strh=_h.ToString("dd/MM/yyyy");
        string[] _sub=_strh.Split('/');
        string _ngay=_sub[0];
        string _thang=_sub[1];
        string _nam=_sub[2];
        string _tensach = txttensach.Text;
        int _maphanloai = Convert.ToInt32(drploaisach.SelectedValue);
        int _tacgia = Convert.ToInt32(drptacgia.SelectedValue);
             
        string _gia = txtgia.Text;
        string _sotrang=txtsotrang.Text;
        string _Muon=drpmuondoc.SelectedValue;
        string _tinhtrang=drptinhtrang.SelectedValue;
        string _namxb=txtNamXuatBan.Text;
        string _anh = null;
        lbthongbao.Text = "";
        /*chèn số*/
        int luu = 0;
        int _stt;
        bool _co = false;
       
        if (ban_sachAll.Count > 0)//có dữ liệu.
        {
            for (int i = 0; i < ban_sachAll.Count - 1; i++)
            {
                if (ban_sachAll[i + 1].MaSach - ban_sachAll[i].MaSach != 1)//có lỗ rỗng
                {
                    _co = true;
                    luu = i;
                    i = ban_sachAll.Count - 1;
                }
            }
            if (ban_sachAll[0].MaSach != 1)//vị trí 0 khác 1.
                _stt = 1;
            else
            {
                if (_co == true)//có lỗ trống.
                    _stt = ban_sachAll[luu].MaSach + 1;
                else
                    _stt = ban_sachAll[ban_sachAll.Count - 1].MaSach + 1;
            }
        }
        else
        {
            _stt = 1;
        }
        /*Kết thúc chèn*/
      bool   Co_Anh = false;                                            //Chèn picture
        if (filanh.HasFile)//không có ảnh up load 
        {
            // Make sure that a JPG has been uploaded
            if (string.Compare(System.IO.Path.GetExtension(filanh.FileName), ".jpg", true) != 0 && string.Compare(System.IO.Path.GetExtension(filanh.FileName), ".jpeg", true) != 0)
            {
                //  lbthongbao.Text= "Only JPG documents may be used for a category's picture.";
                _anh = "anh khong hop le";
                showMessage("phải là anh jpg");
                Co_Anh = false;
                //ham("phải là anh jpg");       
            }
            else
            {   const string BrochureDirectory = "~/ThuVien/Anh/";
                string brochurePath = BrochureDirectory + filanh.FileName;
                string fileNameWithoutExtension =
                System.IO.Path.GetFileNameWithoutExtension(filanh.FileName);
                int iteration = 1;
                while (System.IO.File.Exists(Server.MapPath(brochurePath)))
                {
                    brochurePath = string.Concat(BrochureDirectory, fileNameWithoutExtension,
                        "-", iteration, ".jpg");
                    iteration++;
                }

                // Save the file to disk and set the value of the brochurePath parameter
                filanh.SaveAs(Server.MapPath(brochurePath));
                // e.Values["brochurePath"] = brochurePath;
                _anh = brochurePath;
                Co_Anh = true;
            }
        }
        else
        {
            ham("Ảnh Bìa Sẽ Được Cập Nhật Sau");
            Co_Anh = true;
        }
                                        //Điều Kiện Thực Hiện Chèn

        if (txttensach.Text != "" && txtsoluong.Text != "" && txtsotrang.Text != "" &&
            txtNamXuatBan.Text != "" && txtgia.Text != "")
        {
            int _soluong = Convert.ToInt32(txtsoluong.Text.Trim()); 
            if (lsttacgia.Items.Count > 0)
                if (lstnxb.Items.Count > 0)
                {
                    if (Co_Anh == true)
                    {
                        S_ach.ThemSach(_stt, _maphanloai, _tensach, _namxb, _gia, _soluong, _strh, _tinhtrang, _sotrang, _Muon, _soluong, _anh);//thêm sách
                        for (int i = 0; i < lsttgvalue.Items.Count; i++)
                        {
                            _viet.ThemViet(Convert.ToInt32(lsttgvalue.Items[i].ToString()), _stt);//thêm thông tin bản viết
                        }

                        for (int j = 0; j < lstxbvalue.Items.Count; j++)
                        {
                            _xuatban.ThemXuatBan(Convert.ToInt32(lstxbvalue.Items[j].ToString()), _stt);//thêm thông tin bản xuất bản
                        }

                        lbgia.Visible = false;
                        lbsoluong.Visible = false;
                        lbsotrang.Visible = false;
                        lbtensach.Visible = false;
                        lbnamxuatban.Visible = false;

                        lbthongbao.Text = "Mã Sách " + _stt + " Đã Được Thêm";
                        lstnxb.Items.Clear();
                        lsttacgia.Items.Clear();
                        lsttgvalue.Items.Clear();
                        lstxbvalue.Items.Clear();

                        lsttacgia.Visible = false;
                        btxoaTG.Visible = false;
                        btxoanxb.Visible = false;
                        lstnxb.Visible = false;

                    }
                }
                else
                    lbthongbao.Text = "Nhà Xuất Bản Chưa Được Chọn";
            else
                lbthongbao.Text = "Tác Giả Chọn";
        }
        else
        {
            if (txttensach.Text == "")
                lbtensach.Visible = true;
            else
            { lbtensach.Visible = false; }
            if (txtgia.Text == "")
                lbgia.Visible = true;
            else { lbgia.Visible = false; }
            if (txtsoluong.Text == "")
                lbsoluong.Visible = true;
            else { lbsoluong.Visible = false; }
            if (txtsotrang.Text == "")
                lbsotrang.Visible = true;
            else { lbsotrang.Visible = false; }
            if (txtNamXuatBan.Text == "")
                lbnamxuatban.Visible = true;
            else { lbnamxuatban.Visible = false; }
            
        }
        
        //thực  hiện thao tác thêm
        
        
    }
    protected void tbchontg_Click(object sender, EventArgs e) //chon tác giả
    {
        bool co = false;
        lsttacgia.Visible = true;
        btxoaTG.Visible = true;
        if (lsttacgia.Items.Count <= 0)
        {
            lsttacgia.Items.Add(drptacgia.SelectedItem.ToString());
            lsttgvalue.Items.Add(drptacgia.SelectedValue);
        }
        else
        {
            for (int i = 0; i < lsttgvalue.Items.Count; i++)
            {
                if (Convert.ToInt32(drptacgia.SelectedValue) != Convert.ToInt32(lsttgvalue.Items[i].ToString()))
                {
                    co = true;
                }
                else
                {
                    co = false;
                    i = lsttacgia.Items.Count;
                }
            }
            if (co == true)
            {
                lsttacgia.Items.Add(drptacgia.SelectedItem.ToString());
                lsttgvalue.Items.Add(drptacgia.SelectedValue);
            }
            else
                ham("Tác Giả Đã Được Chọn");
        }
        lbthongbao.Text = "";
          
       //lấy tên tác giả*/
        
    }
    protected void lsttacgia_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btkhongdongy_Click(object sender, EventArgs e)
    {
        string duong_dan = Request.QueryString["themsach"];
        Response.Redirect("~/ThuVien/QuanLy/" + duong_dan.Trim());
    }

    protected void btchonxb_Click(object sender, EventArgs e)// chọn nhà xuất bản
    {
        bool conxb=false;
          
        btxoanxb.Visible = true;
        lstnxb.Visible = true;
        if (lstnxb.Items.Count<=0)
        {
            lstnxb.Items.Add(drpnhaxuatban.SelectedItem.ToString());
            lstxbvalue.Items.Add(drpnhaxuatban.SelectedValue);
        }
        else
        {
            for (int i = 0; i <lstxbvalue.Items.Count;i++)
            {
                if (Convert.ToInt32(drpnhaxuatban.SelectedValue) != Convert.ToInt32(lstxbvalue.Items[i].ToString()))
                {
                    conxb = true;
                }
                else
                {
                    conxb = false;
                    i = lstxbvalue.Items.Count;
                }
            }
            if (conxb == true)
            {

                lstnxb.Items.Add(drpnhaxuatban.SelectedItem.ToString());
                lstxbvalue.Items.Add(drpnhaxuatban.SelectedValue);
            }
            else
                ham("Nhà Xuất Bản Đã Được Chọn");
        }
        lbthongbao.Text = "";
        
    }


    protected void btxoanxb_Click(object sender, EventArgs e)//xóa nhà xuất bản
    {       
         if (lstnxb.SelectedIndex >= 0)
        {
            lstxbvalue.Items.RemoveAt(lstnxb.SelectedIndex);
        }
        lstnxb.Items.Remove(lstnxb.SelectedItem);
        if (lstnxb.Items.Count <= 0)
        {
            btxoanxb.Visible = false;
            lstnxb.Visible = false;
        }
       //lbthongbao.Text= lstnxb.SelectedIndex.ToString();
       
    }
    protected void btxoaTG_Click(object sender, EventArgs e)//xóa tác giả
    {
        if (lsttacgia.SelectedIndex >= 0)
        {
            lsttgvalue.Items.RemoveAt(lsttacgia.SelectedIndex);
        }
        lsttacgia.Items.Remove(lsttacgia.SelectedItem);        
        lbthongbao.Text = lsttacgia.SelectedIndex.ToString();
        if (lsttacgia.Items.Count <= 0)
        {
            lsttacgia.Visible = false;
            btxoaTG.Visible = false;
        }
    }
    public void showMessage(string mess)
    {
        string strBuilder = "<script language='javascript'>alert('" + mess + "')</script>";
        Response.Write(strBuilder);
    }

    protected void lnktacgia_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ThuVien/QuanLy/ThemTacGia.aspx?duongdan=ThemSach.aspx");
    }
    protected void lnkcapnhatnxb_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ThuVien/QuanLy/ThemNhaXuatBan.aspx?duongdan=ThemSach.aspx");
    }
   
}
