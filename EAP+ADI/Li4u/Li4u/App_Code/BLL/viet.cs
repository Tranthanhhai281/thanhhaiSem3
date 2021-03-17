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
using DataTableAdapters;

/// <summary>
/// Summary description for viet
/// </summary>
public class viet
{
    private VietTableAdapter _viet = null;
    protected VietTableAdapter v_iet
    {
        get
        {
            if (_viet == null)
                _viet = new VietTableAdapter();
            return _viet;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Data.VietDataTable GetViet()
    {
        return this.v_iet.GetViet();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemViet(int MaTG, int MaSach)
    {
        Data.VietDataTable ban_viet = new Data.VietDataTable();
        Data.VietRow viet_row = ban_viet.NewVietRow();
        viet_row.MaTacGia = MaTG;
        viet_row.MaSach = MaSach;
        ban_viet.AddVietRow(viet_row);
        int bien = v_iet.Update(ban_viet);
        return bien == 1;
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteViet(int MaTacGia,int MaSach)
    {
        int xoahang = v_iet.Delete(MaTacGia, MaSach);
        return xoahang == 1;
    }
}
