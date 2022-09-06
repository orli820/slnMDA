
using prjMDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.ViewModul
{
    public class viewMDA
    {
        protected MDAEntities1 dbContext = new MDAEntities1();

        public virtual List<片單總表MovieLists> get片單總表MovieLists()
        {
            return dbContext.片單總表MovieLists.ToList();
        }

        public virtual List<片種總表TotalTypes> get片種總表TotalTypes()
        {
            return dbContext.片種總表TotalTypes.ToList();
        }

        public virtual List<出售座位明細SeatSold> get出售座位明細SeatSold()
        {
            return dbContext.出售座位明細SeatSold.ToList();
        }

        public virtual List<出售座位狀態SeatStatus> get出售座位狀態SeatStatus()
        {
            return dbContext.出售座位狀態SeatStatus.ToList();
        }

        public virtual List<回覆樓數Floor> get回覆樓數Floor()
        {
            return dbContext.回覆樓數Floor.ToList();
        }

        public virtual List<次片種總表Types> get次片種總表Types()
        {
            return dbContext.次片種總表Types.ToList();
        }

        public virtual List<我的片單MyMovieLists> get我的片單MyMovieLists()
        {
            return dbContext.我的片單MyMovieLists.ToList();
        }

        public virtual List<我的追蹤清單MyFollowLists> get我的追蹤清單MyFollowLists()
        {
            return dbContext.我的追蹤清單MyFollowLists.ToList();
        }

        public virtual List<系列電影MovieSeries> get系列電影MovieSeries()
        {
            return dbContext.系列電影MovieSeries.ToList();
        }

        public virtual List<訂單明細OrderDetail> get訂單明細OrderDetail()
        {
            return dbContext.訂單明細OrderDetail.ToList();
        }

        public virtual List<訂單狀態OrderStatus> get訂單狀態OrderStatus()
        {
            return dbContext.訂單狀態OrderStatus.ToList();
        }

        public virtual List<訂單總表Orders> get訂單總表Orders()
        {
            return dbContext.訂單總表Orders.ToList();
        }

        public virtual List<追讚倒ActionTypes> get追讚倒ActionTypes()
        {
            return dbContext.追讚倒ActionTypes.ToList();
        }

        public virtual List<商品資料Products> get商品資料Products()
        {
            return dbContext.商品資料Products.ToList();
        }

        public virtual List<國家總表Countrys> get國家總表Countrys()
        {
            return dbContext.國家總表Countrys.ToList();
        }

        public virtual List<票種TicketType> get票種TicketType()
        {
            return dbContext.票種TicketType.ToList();
        }

        public virtual List<票價資訊TicketPrice> get票價資訊TicketPrice()
        {
            return dbContext.票價資訊TicketPrice.ToList();
        }

        public virtual List<場次Screening> get場次Screening()
        {
            return dbContext.場次Screening.ToList();
        }

        public virtual List<評論圖片明細CommentImagesList> get評論圖片明細CommentImagesList()
        {
            return dbContext.評論圖片明細CommentImagesList.ToList();
        }

        public virtual List<評論圖片總表CommentImages> get評論圖片總表CommentImages()
        {
            return dbContext.評論圖片總表CommentImages.ToList();
        }

        public virtual List<會員Members> get會員Members()
        {
            return dbContext.會員Members.ToList();
        }

        public virtual List<電影Movies> get電影Movies()
        {
            return dbContext.電影Movies.ToList();
        }

        public virtual List<電影分級MovieRating> get電影分級MovieRating()
        {
            return dbContext.電影分級MovieRating.ToList();
        }

        public virtual List<電影片種MovieType> get電影片種MovieType()
        {
            return dbContext.電影片種MovieType.ToList();
        }

        public virtual List<電影主演Cast> get電影主演Cast()
        {
            return dbContext.電影主演Cast.ToList();
        }

        public virtual List<電影代碼MovieCode> get電影代碼MovieCode()
        {
            return dbContext.電影代碼MovieCode.ToList();
        }

        public virtual List<電影院Theater> get電影院Theater()
        {
            return dbContext.電影院Theater.ToList();
        }

        public virtual List<電影產地MovieOrigin> get電影產地MovieOrigin()
        {
            return dbContext.電影產地MovieOrigin.ToList();
        }

        public virtual List<電影評論MovieComment> get電影評論MovieComment()
        {
            return dbContext.電影評論MovieComment.ToList();
        }

        public virtual List<電影圖片MovieIImagesList> get電影圖片MovieIImagesList()
        {
            return dbContext.電影圖片MovieIImagesList.ToList();
        }

        public virtual List<電影圖片總表MovieImages> get電影圖片總表MovieImages()
        {
            return dbContext.電影圖片總表MovieImages.ToList();
        }

        public virtual List<電影語言MovieLanguage> get電影語言MovieLanguage()
        {
            return dbContext.電影語言MovieLanguage.ToList();
        }

        public virtual List<電影導演MovieDirector> get電影導演MovieDirector()
        {
            return dbContext.電影導演MovieDirector.ToList();
        }

        public virtual List<對象Targets> get對象Targets()
        {
            return dbContext.對象Targets.ToList();
        }

        public virtual List<演員總表Actors> get演員總表Actors()
        {
            return dbContext.演員總表Actors.ToList();
        }

        public virtual List<影城MainTheater> get影城MainTheater()
        {
            return dbContext.影城MainTheater.ToList();
        }

        public virtual List<影廳Cinema> get影廳Cinema()
        {
            return dbContext.影廳Cinema.ToList();
        }

        public virtual List<標籤明細HashtagsList> get標籤明細HashtagsList()
        {
            return dbContext.標籤明細HashtagsList.ToList();
        }

        public virtual List<標籤總表Hashtags> get標籤總表Hashtags()
        {
            return dbContext.標籤總表Hashtags.ToList();
        }

        public virtual List<導演總表Director> get導演總表Director()
        {
            return dbContext.導演總表Director.ToList();
        }

        public virtual List<優惠明細CouponLists> get優惠明細CouponLists()
        {
            return dbContext.優惠明細CouponLists.ToList();
        }

        public virtual List<優惠總表Coupon> get優惠總表Coupon()
        {
            return dbContext.優惠總表Coupon.ToList();
        }

        public virtual List<購買商品明細Receipt> get購買商品明細Receipt()
        {
            return dbContext.購買商品明細Receipt.ToList();
        }

    }
}
