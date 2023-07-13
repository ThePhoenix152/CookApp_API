using Cookapp_API.DataAccess.DTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.BlacklistDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CategoryDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CommentDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.NutriDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PlanDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;

namespace Cookapp_API.DataAccess.BLL
{
    public class AllInOneBLL
    {
        string _connetionString;
        int _timeout;
        ESqlProvider _sqlProvider;
        public AllInOneBLL(string connetionString, ESqlProvider sqlProvider, int timeout)
        {
            _connetionString = connetionString;
            _sqlProvider = sqlProvider;
            _timeout = timeout;
        }
        private DAL.AllInOneDAL GetDAL_MSSQLSERVER()
        {
            if (!string.IsNullOrEmpty(_connetionString))
            {
                return new DAL.AllInOneDAL(_connetionString
                    , _timeout);
            }
            else
            {
                throw new Exception("SqlConnectionString is Empty");
            }
        }
        public List<CategoryDTO> GetCategory()
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetCategory();
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<NutriDTO> GetNutri()
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetNutri();
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PostDTO> GetPosts(List<string> ids)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPosts(ids);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<BlacklistDTO> GetBlackList(List<string> ids)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetBlackList(ids);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CommentDTO> GetComments(List<string> ids)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetComments(ids);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GetPlanDTO> GetPlans(List<string> ids)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPlan(ids);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdatePost(string id, UpdatePostDTO post)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdatePost(id, post);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PostDTO> GetPostByID(string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPostbyID(id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PostDTO> GetPostbyCategory(string category)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPostbyCategory(category);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PostDTO> GetPostbyNutri(string nutri)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPostbyNutri(nutri);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PostDTO> GetPostbyIngre(string ingre)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPostbyIngre(ingre);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CommentDTO> GetCommentsByPostID(string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetCommentbyPostID(id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GetPlanDTO> GetPlanByAccountID(string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetPlanByAccountID(id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GetTimeByDay> GetlistByDay(string id, string day)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetlistByDay(id,day);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CreatePost(CreatePostDTO post)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreatePost(post);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateNutri(HandleNutri nutri)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreateNutri(nutri);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateCate(AddCategory category)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreateCate(category);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateNutri(string id, HandleNutri nutri)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdateNutri( id, nutri);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateCate(string id, AddCategory category)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdateCate( id, category);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteNutri(string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.DeleteNutri(id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteCate(string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.DeleteCate(id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateBanBlackList(string id, banblacklist set)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdateBanBlackList(id, set);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateAccountStatus()
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdateAccountStatus();
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ReportComment(AddBlacklist blacklist, string accountid, string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.ReportComment(blacklist, accountid, id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int DeletePostFromPlan(string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.DeletePostFromPlan(id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        public int CreatePlanAtNewTime(AddNewPlan plan, string postid, string accountid)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreatePlanAtNewTime(plan, postid,accountid);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateComment(AddNewComment comment, string accountid, string postid)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreateComment(comment, accountid,postid);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreatePlanAtExistTime(ConfirmAdd plan, string postid, string accountid,string day, string starttime, string endtime)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreatePlanAtExistTime(plan, postid,accountid,day,starttime, endtime);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
