namespace HomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(vw_CustomerInfoMetaData))]
    public partial class vw_CustomerInfo
    {
    }
    
    public partial class vw_CustomerInfoMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        public Nullable<int> 銀行帳戶數量 { get; set; }
        public Nullable<int> 聯絡人數量 { get; set; }
    }
}
