//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjMDA
{
    using System;
    using System.Collections.Generic;
    
    public partial class 影廳Cinema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 影廳Cinema()
        {
            this.場次Screening = new HashSet<場次Screening>();
        }
    
        public int 影廳編號Cinema_ID { get; set; }
        public string 影廳名稱Cinema_Name { get; set; }
        public int 電影院編號Theater_ID { get; set; }
        public string 廳種名稱Cinema_Cls_Name { get; set; }
        public string 座位資訊SeatInfo { get; set; }
        public byte[] 影廳照片Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<場次Screening> 場次Screening { get; set; }
        public virtual 電影院Theater 電影院Theater { get; set; }
    }
}
