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
    
    public partial class 我的追蹤清單MyFollowLists
    {
        public int 我的追蹤清單編號CF_ID { get; set; }
        public int 會員編號Member_ID { get; set; }
        public int 對象Target_ID { get; set; }
        public int 追讚倒編號ActionType_ID { get; set; }
        public int 連接編號Connect_ID { get; set; }
        public string 檢舉理由ReportReason { get; set; }
    
        public virtual 回覆樓數Floor 回覆樓數Floor { get; set; }
        public virtual 追讚倒ActionTypes 追讚倒ActionTypes { get; set; }
        public virtual 會員Members 會員Members { get; set; }
        public virtual 電影評論MovieComment 電影評論MovieComment { get; set; }
        public virtual 對象Targets 對象Targets { get; set; }
    }
}
