﻿using Cookapp_API.DataAccess.DTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CommentDTO;
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
        }public List<GetPlanDTO> GetPlanByAccountID(string id)
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
        public int CreatePlan(AddNewPlan plan, string postid, string accountid)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AllInOneDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreatePlan(plan, postid,accountid);
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
