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
/// Summary description for ChiTiet
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class ChiTiet
{
    private ChiTietTableAdapter _chitiet = null;
    protected ChiTietTableAdapter chi_tiet
    {
        get
        {
            if (_chitiet == null)
                _chitiet = new ChiTietTableAdapter();
            return _chitiet;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.ChiTietDataTable GetChiTiet()
    {
        return this.chi_tiet.GetChiTiet();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.ChiTietDataTable GetByMaDG(String MaDG)
    {
        return this.chi_tiet.GetByMaDG(MaDG);
    }
	
}
