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

public partial class ThuVien_QuanLy_TraSach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { btXoa.Attributes.Add("onClick", "return confirm('Bạn Muốn Xóa Lượt Mượn Không?');");
        if (grwthongtin.Rows.Count <= 0)
            lbcanhbao.Text = "Chưa Có Thông Tin";
    }
    protected void grwThongTin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected string TreHen(object NgayTra)
    {   DateTime _ngay_ht = DateTime.Now;
        string _date0 = Convert.ToString(NgayTra);
        string[] mang = _date0.Trim().Split('/');
        int _date = Convert.ToInt32(mang[0]);
        int _month = Convert.ToInt32(mang[1]);
        int _year = Convert.ToInt32(mang[2]);
        string _ngay1 = DateTime.Parse(_month + "/" + _date + "/" + _year).ToString("dd/MM/yyyy");
        if (mang.Length == 3)                       //chưa trả sách
        {
            LayThoiGian _tghh = new LayThoiGian();
            int _ngayht = Convert.ToInt32(_tghh.Get_Day());
            int _thanght = Convert.ToInt32(_tghh.Get_Month());
            int _namht = Convert.ToInt32(_tghh.Get_Year());
            bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _date, _month, _year);

            if (_kiemtra == false)
            { return "TreHen"; }
            else
            { return _date0; }
        }
        else
            return _ngay1;
    }
    protected string Eval_ngay(object NgayTra)
    {
        string _ngay = Convert.ToString(NgayTra);
        string[] mang = _ngay.Split('/');
        return mang[0];

    }
    protected string Eval_thang(object NgayTra)
    {
        string _thang = Convert.ToString(NgayTra);
        string[] mang = _thang.Split('/');
        return mang[1];
    }
    protected string Eval_nam(object NgayTra)
    {
        string _nam = Convert.ToString(NgayTra);
        string[] mang = _nam.Split('/');
        return mang[2];
    }
    protected string trachua(object Tra)
    {

        string tinhtrang = Convert.ToString(Tra);
        if (tinhtrang.Trim() == "Chua")
        {
            return "Chua";
        }
        else
        {
            return "Roi";
        }
    }

    protected void btTim_Click(object sender, EventArgs e)
    {
        LuotMuonTableAdapter L_Muon=new LuotMuonTableAdapter();
        L_Muon.DeleteLuotMuon(1);
    }   
    protected void grwthongtin_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        grwthongtin.Columns[2].Visible = true;
    }
    protected void grwthongtin_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grwthongtin.Columns[2].Visible = false;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int _row = grwthongtin.EditIndex;
        Label _lbSoThuTu = (Label)grwthongtin.Rows[_row].FindControl("lbSoThuTu");
        LuotMuonTableAdapter L_Muon = new LuotMuonTableAdapter();
        DropDownList _drpGiaHan = (DropDownList)grwthongtin.Rows[_row].FindControl("drpMaGiaHan");
        DropDownList _drpNgayMuon = (DropDownList)grwthongtin.Rows[_row].FindControl("drpNgayMuon");
        DropDownList _drpThangMuon = (DropDownList)grwthongtin.Rows[_row].FindControl("drpThangMuon");
        TextBox _txtNamMuon = (TextBox)grwthongtin.Rows[_row].FindControl("txtNamMuon");
        DropDownList _drpNgayTra = (DropDownList)grwthongtin.Rows[_row].FindControl("drpNgayTra");
        DropDownList _drpThangTra = (DropDownList)grwthongtin.Rows[_row].FindControl("drpThangTra");
        TextBox _txtNamTra = (TextBox)grwthongtin.Rows[_row].FindControl("txtNamMuon");
        DropDownList _drpTraChua = (DropDownList)grwthongtin.Rows[_row].FindControl("drptrachua");
        int _MaGiaHan = int.Parse(_drpGiaHan.SelectedValue);
        string _NgayMuon = _drpNgayMuon.SelectedValue;
        string _ThangMuon = _drpThangMuon.SelectedValue;
        string _NamMuon = _txtNamMuon.Text;
        string _NgayTra = _drpNgayTra.SelectedValue;
        string _ThangTra = _drpThangTra.SelectedValue;
        string _NamTra = _txtNamTra.Text;
        int _SoThuTu = int.Parse(_lbSoThuTu.Text);
        string _TraChua="";

        if(_drpTraChua.SelectedValue=="Chua")// Kiểm tra thuộc tính trả sách
        {
          _TraChua= _drpTraChua.SelectedValue;}
        else{
            _TraChua= _drpTraChua.SelectedValue+"/R";}

        string _strNgayMuon = _NgayMuon + "/" + _ThangMuon + "/" + _NamMuon;
        string _strNgayTra = _NgayTra + "/" + _ThangTra + "/" + _NamTra;

        LayThoiGian _tg = new LayThoiGian();
        bool _kiemtratg = _tg.Luot_Muon(Convert.ToInt32(_NgayTra), Convert.ToInt32(_ThangTra), Convert.ToInt32(_NamTra), Convert.ToInt32(_NgayMuon), Convert.ToInt32(_ThangMuon), Convert.ToInt32(_NamMuon));
        if (_kiemtratg == true)              // thời gian mượn lớn hơn hoặc băng thời gian trả
        {
            L_Muon.SuaLuotMuon(_MaGiaHan, "A08020048", _strNgayMuon, _strNgayTra, _TraChua, _SoThuTu);
            lbcanhbao.Text = "";
        }
        lbcanhbao.Text = "Cảnh Báo Không Thể Trướ Ngày Trả!";
       
        // lbcanhbao.Text = _drpNgayMuon.SelectedValue;
    }
    protected void ActiveCheckAll(bool _state)
    {
        foreach (GridViewRow _row in grwthongtin.Rows)
        {
            CheckBox ckb = (CheckBox)_row.FindControl("chbxCheck");
            if (ckb != null)
                ckb.Checked = _state;
        }
    }    

    protected void lnkcheckkAll_Click(object sender, EventArgs e)
    {
        ActiveCheckAll(true);
    }
    protected void lnkUnCheck_Click(object sender, EventArgs e)
    {
        ActiveCheckAll(false);
    }
    protected void btXoa_Click(object sender, EventArgs e)
    {
        LuotMuonTableAdapter L_Muon = new LuotMuonTableAdapter();
        foreach (GridViewRow _row in grwthongtin.Rows)             //biến _row lần lượt duyệt tất cả các dòng của gridview
        {
            CheckBox cbx = (CheckBox)_row.FindControl("chbxCheck");
            if (cbx != null && cbx.Checked)
            {
                int _ForKeys = Convert.ToInt32(grwthongtin.DataKeys[_row.RowIndex].Value);//DataKeys[i]lấy về khóa chính của ban database ;i là thứ tự hàng của gridview
                L_Muon.DeleteLuotMuon(_ForKeys);                
            }
        }
    }
}
