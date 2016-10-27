namespace HomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MyValidationAtrribute;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人:IValidatableObject 
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            客戶資料Entities db = new 客戶資料Entities();

            var data = db.客戶聯絡人;

            foreach (var item in data)
            {
                if ((item.Email.Trim().ToString() == this.Email.Trim()) && (item.客戶Id == this.客戶Id))
                {
                    yield return new ValidationResult("Email重覆", new string[] { "Email" });
                }
                yield break;                
            }
            
        }
    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string Email { get; set; }

        //[RegularExpression(@"^\d{4}-\d{6}")]
        [CellPhoeValid]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
