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
/// Summary description for TacGia
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class TacGia
{
		
	private TacGiaTableAdapter _tacgia = null;
	protected TacGiaTableAdapter tac_gia
    {get 
        {
            if (_tacgia == null)
                _tacgia = new TacGiaTableAdapter();
            return _tacgia;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.TacGiaDataTable GetTacGia()
    {
        return this.tac_gia.GetTacGia();
    }
     [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool ThemTacGia(int MaTG,string TenTG)
    {
        Data.TacGiaDataTable ban_tacgia= new Data.TacGiaDataTable();
         Data.TacGiaRow TacGia_row=ban_tacgia.NewTacGiaRow();
         TacGia_row.MaTacGia=MaTG;
         if (TenTG == null) TacGia_row.SetTenTacGiaNull();
         else TacGia_row.TenTacGia = TenTG;
         ban_tacgia.AddTacGiaRow(TacGia_row);
         int bien=tac_gia.Update(ban_tacgia);
         return bien == 1;        
    }
      
     [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
     public Data.TacGiaDataTable GetChiTietTacGia(int _masach)
    {
        return this.tac_gia.GetChiTietTacGia(_masach);
    }
}
	

