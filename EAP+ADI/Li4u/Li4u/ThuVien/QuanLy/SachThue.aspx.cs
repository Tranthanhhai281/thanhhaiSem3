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

public partial class ThuVien_DocGia_SachTinHoc : System.Web.UI.Page
{
    SachTableAdapter S_ach = new SachTableAdapter();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SachTableAdapter S_ach = new SachTableAdapter();
        Data.SachDataTable ban_sach = S_ach.GetSachPhanLoai(6);
        if (ban_sach.Count > 0)
        {

            lbThongBao.Visible = false;
            CollectionPager1.MaxPages = 10000;
            CollectionPager1.PageSize = 10; // số items hiển thị trên một trang.
            CollectionPager1.DataSource = S_ach.GetSachPhanLoai(6).DefaultView;
            CollectionPager1.BindToControl = lvDemo;
            lvDemo.DataSource = CollectionPager1.DataSourcePaged;
            lvDemo.DataBind();
           
       }
        else {
            lbThongBao.Visible = true;
            lbThongBao.Text = "0 Kết Quả";
        }
        
        
    }
    protected string Anh_Bia(object AnhBia)
    {
        string _anh = Convert.ToString(AnhBia);
        if (string.IsNullOrEmpty(_anh)==true)
            return "~/ThuVien/Anh/khongsach.jpg";
        else
            return _anh.Trim();
    }
    
    
    protected void lvDemo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected string ten_sach(object TenSach)//xử lý tên sách quá dài
    {
        string _ten = Convert.ToString(TenSach);
        string[] substr = _ten.Split(' ');
        if (substr.Length <= 4)
            return _ten;
        else
            return substr[0] + " " + substr[1] + " " + substr[2] + " " + substr[3] + " ...";
    }  
}
