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
    
    public partial class 追讚倒ActionTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 追讚倒ActionTypes()
        {
            this.我的追蹤清單MyFollowLists = new HashSet<我的追蹤清單MyFollowLists>();
        }
    
        public int 追讚倒編號ActionType_ID { get; set; }
        public string 追讚倒名稱ActionType_Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<我的追蹤清單MyFollowLists> 我的追蹤清單MyFollowLists { get; set; }
    }
}
