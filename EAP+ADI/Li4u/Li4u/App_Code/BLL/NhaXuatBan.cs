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
/// Summary description for NhaXuatBan
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class NhaXuatBan
{
    private NhaXuatBanTableAdapter _nxb = null;
    protected NhaXuatBanTableAdapter nha_xuatban
    {
        get
        {
            if (_nxb == null)
                _nxb = new NhaXuatBanTableAdapter();
            return _nxb;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.NhaXuatBanDataTable GetNXB()
    {
        return this.nha_xuatban.GetNXB();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.NhaXuatBanDataTable GetChiTetNXB(int MaSach)
    {
        return this.nha_xuatban.GetChiTetNXB(MaSach);
    }
}
