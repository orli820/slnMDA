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
    
    public partial class 國家總表Countrys
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 國家總表Countrys()
        {
            this.電影產地MovieOrigin = new HashSet<電影產地MovieOrigin>();
        }
    
        public string 國家編號Country_ID { get; set; }
        public string 國家名稱Country_Name { get; set; }
        public byte[] 國旗Country_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<電影產地MovieOrigin> 電影產地MovieOrigin { get; set; }
    }
}
