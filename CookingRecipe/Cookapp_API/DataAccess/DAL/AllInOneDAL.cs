using Azure.Identity;
using Cookapp_API.Data;
using Cookapp_API.DataAccess.DTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.BlacklistDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CategoryDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.CommentDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.IngredientDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.NutriDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PlanDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol;
using System;
using System.Collections;
using System.Numerics;

namespace Cookapp_API.DataAccess.DAL
{
    public class AllInOneDAL : MSSQLSERVERDataAccess
    {
        public const string _TABLE_NAME_ACCOUNT = "Accounts";
        public const string _TABLE_NAME_POST = "recipeposts";
        public const string _TABLE_NAME_CATEGORY = "category";
        public const string _TABLE_NAME_COMMENT = "comments";
        public const string _TABLE_NAME_BLACKLIST = "blacklist";
        public const string _TABLE_NAME_NUTRI = "nutrition";
        public const string _TABLE_NAME_INGRE = "ingredients";
        public const string _TABLE_NAME_PLAN = "[CookingRecipeDB].[dbo].[plan]";
        public AllInOneDAL() : base() { }

        public AllInOneDAL(string connectionString) : base(connectionString) { }

        public AllInOneDAL(string connectionString, int timeout) : base(connectionString, timeout) { }
        public List<CategoryDTO> GetCategory()
        {
            try
            {
                string query = "select * from " + _TABLE_NAME_CATEGORY;
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                CategoryDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<CategoryDTO> arrRes = new List<CategoryDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new CategoryDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<CategoryDTO> { };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<IngredientDTO> GetIngre()
        {
            try
            {
                string query = "select * from " + _TABLE_NAME_INGRE;
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                IngredientDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<IngredientDTO> arrRes = new List<IngredientDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new IngredientDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<IngredientDTO> { };
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
                string query = "select * from " + _TABLE_NAME_NUTRI;
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                NutriDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<NutriDTO> arrRes = new List<NutriDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new NutriDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<NutriDTO> { };
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
                string query = "Select a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName, STRING_AGG(g.tagname,',') as tag, STRING_AGG(i.name,',') as ingredient, STRING_AGG(k.name,',') as nutrition from recipeposts a " +
                    "left join category b on a.ref_cate = b.id " +
                    "left join accounts c on a.ref_account = c.id " +
                    "left join tag_post f on a.id = f.ref_post " +
                    "left join tags g on f.ref_tag = g.id " +
                    "left join ingre_post h on a.id = h.ref_post " +
                    "left join ingredients i on h.ref_ingredient = i.id " +
                    "left join nutri_post j on a.id = j.ref_post " +
                    "left join nutrition k on j.ref_nutri = k.Id " +
                    "group by a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                PostDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<PostDTO> arrRes = new List<PostDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new PostDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<PostDTO> { };
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
                string query = "Select a.id, b.FullName, a.isBan, a.reason, c.content from "+ _TABLE_NAME_BLACKLIST +" a " +
                    "left join "+ _TABLE_NAME_ACCOUNT +" b on a.ref_user = b.id " +
                    "left join "+ _TABLE_NAME_COMMENT +" c on a.ref_comment = c.id";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                BlacklistDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<BlacklistDTO> arrRes = new List<BlacklistDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new BlacklistDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<BlacklistDTO> { };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PostDTO> GetPostbyID(string id)
        {
            try
            {
                string query = "Select a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName, STRING_AGG(g.tagname,',') as tag, STRING_AGG(i.name,',') as ingredient, STRING_AGG(k.name,',') as nutrition from recipeposts a " +
                    "left join category b on a.ref_cate = b.id " +
                    "left join accounts c on a.ref_account = c.id " +
                    "left join tag_post f on a.id = f.ref_post " +
                    "left join tags g on f.ref_tag = g.id " +
                    "left join ingre_post h on a.id = h.ref_post " +
                    "left join ingredients i on h.ref_ingredient = i.id " +
                    "left join nutri_post j on a.id = j.ref_post " +
                    "left join nutrition k on j.ref_nutri = k.Id " +
                    "where a.id='" + id + "' " +
                    "group by a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";

                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                PostDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<PostDTO> arrRes = new List<PostDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new PostDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<PostDTO> { };
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
                string query = "Select a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName, STRING_AGG(g.tagname,',') as tag, STRING_AGG(i.name,',') as ingredient, STRING_AGG(k.name,',') as nutrition from recipeposts a " +
                    "left join category b on a.ref_cate = b.id " +
                    "left join accounts c on a.ref_account = c.id " +
                    "left join tag_post f on a.id = f.ref_post " +
                    "left join tags g on f.ref_tag = g.id " +
                    "left join ingre_post h on a.id = h.ref_post " +
                    "left join ingredients i on h.ref_ingredient = i.id " +
                    "left join nutri_post j on a.id = j.ref_post " +
                    "left join nutrition k on j.ref_nutri = k.Id " +
                    "where a.ref_cate='" + category + "' " +
                    "group by a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";

                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                PostDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<PostDTO> arrRes = new List<PostDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new PostDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<PostDTO> { };
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
                string query = "Select a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName, STRING_AGG(g.tagname,',') as tag, STRING_AGG(i.name,',') as ingredient from recipeposts a " +
                    "left join category b on a.ref_cate = b.id " +
                    "left join accounts c on a.ref_account = c.id " +
                    "left join tag_post f on a.id = f.ref_post " +
                    "left join tags g on f.ref_tag = g.id " +
                    "left join ingre_post h on a.id = h.ref_post " +
                    "left join ingredients i on h.ref_ingredient = i.id " +
                    "left join nutri_post j on a.id = j.ref_post " +
                    "left join nutrition k on j.ref_nutri = k.Id " +
                    "WHERE EXISTS (SELECT 1 FROM nutri_post h2 INNER JOIN nutrition i2 ON h2.ref_nutri = i2.id WHERE h2.ref_post = a.id AND i2.name = '" + nutri + "')" +
                    "group by a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";

                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                PostDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<PostDTO> arrRes = new List<PostDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new PostDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<PostDTO> { };
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
                string query = "Select a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName, STRING_AGG(g.tagname,',') as tag, STRING_AGG(k.name,',') as nutrition, STRING_AGG(i.name,',') as ingredient from recipeposts a " +
                    "left join category b on a.ref_cate = b.id " +
                    "left join accounts c on a.ref_account = c.id " +
                    "left join tag_post f on a.id = f.ref_post " +
                    "left join tags g on f.ref_tag = g.id " +
                    "left join ingre_post h on a.id = h.ref_post " +
                    "left join ingredients i on h.ref_ingredient = i.id " +
                    "left join nutri_post j on a.id = j.ref_post " +
                    "left join nutrition k on j.ref_nutri = k.Id " +
                    "WHERE EXISTS (SELECT 1 FROM ingre_post h2 INNER JOIN ingredients i2 ON h2.ref_ingredient = i2.id WHERE h2.ref_post = a.id AND i2.name = '"+ ingre +"')" +
                    "group by a.id,a.title,a.content,a.create_time,a.update_time, a.cooktime,a.addtime,a.preptime,a.totaltime,a.image, b.catetitle, c.FullName";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";

                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                PostDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<PostDTO> arrRes = new List<PostDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new PostDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<PostDTO> { };
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
                string query = "update " + _TABLE_NAME_POST;
                string filed = " SET ";
                if (post != null)
                {
                    if (!string.IsNullOrEmpty(post.Title))
                    {
                        filed += " title='" + post.Title + "'";
                    }

                    if (!string.IsNullOrEmpty(post.Content))
                    {
                        filed += (filed != " SET " ? "," : "") + " content='" + post.Content + "'";
                    }
                    filed += (filed != " SET " ? "," : "") + " update_time='" + DateTime.Now + "'";
                    if (post.Image != null)
                    {
                        filed += (filed != " values " ? "," : "") + " CONVERT(varbinary(max), '" + Convert.ToBase64String(post.Image) + "')";
                    }

                    if (post.preptime > 0)
                    {
                        filed += (filed != " SET " ? "," : "") + " preptime='" + post.preptime + "'";
                    }
                    if (post.cooktime > 0)
                    {
                        filed += (filed != " SET " ? "," : "") + " cooktime='" + post.cooktime + "'";
                    }
                    if (post.addtime > 0)
                    {
                        filed += (filed != " SET " ? "," : "") + " addtime='" + post.addtime + "'";
                    }
                    filed += (filed != " SET " ? "," : "") + " totaltime='" + (post.preptime + post.cooktime + post.addtime).ToString() + "'";
                    //if (!string.IsNullOrEmpty(post.tag))
                    //{
                    //    filed += (filed != " SET " ? "," : "") + " tag='" + post.tag + "'";
                    //}    


                }
                if (filed != " SET ")
                {
                    query += filed + " where id='" + id + "'";
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "update " + _TABLE_NAME_BLACKLIST;
                string filed = " SET ";
                if (set != null)
                {
                        filed += " isBan='" + set.isBan + "'";
                }
                if (filed != " SET ")
                {
                    query += filed + " where id='" + id + "'";
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "insert into " + _TABLE_NAME_POST;
                string filed = " values ";
                if (post != null)
                {
                    filed += "('" + Guid.NewGuid().ToString() + "'";
                    if (!string.IsNullOrEmpty(post.Title))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.Title + "'";
                    }

                    if (!string.IsNullOrEmpty(post.RefTag))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.RefTag + "'";
                    }
                    if (!string.IsNullOrEmpty(post.Content))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.Content + "'";
                    }
                    filed += (filed != " values " ? "," : "") + "'" + DateTime.Now + "'";


                    filed += (filed != " values " ? "," : "") + "null";

                    if (!string.IsNullOrEmpty(post.RefAccount))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.RefAccount + "'";
                    }
                    if (post.Image != null)
                    {
                        filed += (filed != " values " ? "," : "") + " CONVERT(varbinary(max), '" + Convert.ToBase64String(post.Image) + "')";
                    }

                    if (!string.IsNullOrEmpty(post.RefCategory))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.RefCategory + "'";
                    }
                    if (post.preptime > 0)
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.preptime + "'";
                    }
                    if (post.addtime > 0)
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.addtime + "'";
                    }

                    if (post.cooktime > 0)
                    {
                        filed += (filed != " values " ? "," : "") + "'" + post.cooktime + "'";
                    }

                    filed += (filed != " values " ? "," : "") + "'" + (post.preptime + post.cooktime + post.addtime).ToString() + "')";



                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "insert into " + _TABLE_NAME_CATEGORY;
                string filed = " values ";
                if (category != null)
                {
                    if (!string.IsNullOrEmpty(category.catetitle))
                    {
                        filed += "('" + category.catetitle + "'";
                    }
                    filed += (filed != " values " ? "," : "") + "'" + Guid.NewGuid().ToString() + "')";
                   

                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CreateIngre(HandleIngre ingre)
        {
            try
            {
                string query = "insert into " + _TABLE_NAME_INGRE;
                string filed = " values ";
                if (ingre != null)
                {
                    
                    filed += (filed != " values " ? "," : "") + "('" + Guid.NewGuid().ToString() + "'";
                   if (!string.IsNullOrEmpty(ingre.name))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + ingre.name + "')";
                    }

                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "insert into " + _TABLE_NAME_NUTRI;
                string filed = " values ";
                if (nutri != null)
                {
                    
                    filed += (filed != " values " ? "," : "") + "('" + Guid.NewGuid().ToString() + "'";
                   if (!string.IsNullOrEmpty(nutri.Name))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + nutri.Name + "')";
                    }

                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "Update " + _TABLE_NAME_CATEGORY;
                string filed = " SET ";
                if (category != null)
                {
                    if (!string.IsNullOrEmpty(category.catetitle))
                    {
                        filed += " catetitle='" + category.catetitle + "'";
                    }
                    filed += "where id='" + id + "'"; 
                }
                if (filed != " SET ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateIngre(string id, HandleIngre ingre)
        {
            try
            {
                string query = "Update " + _TABLE_NAME_INGRE;
                string filed = " SET ";
                if (ingre != null)
                {
                    if (!string.IsNullOrEmpty(ingre.name))
                    {
                        filed += " name='" + ingre.name + "'";
                    }
                    filed += "where id='" + id + "'"; 
                }
                if (filed != " SET ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "Update " + _TABLE_NAME_NUTRI;
                string filed = " SET ";
                if (nutri != null)
                {
                    if (!string.IsNullOrEmpty(nutri.Name))
                    {
                        filed += " name='" + nutri.Name + "'";
                    }
                    filed += "where id='" + id + "'"; 
                }
                if (filed != " SET ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "insert into " + _TABLE_NAME_COMMENT;
                string filed = " values ";
                if (comment != null)
                {
                    filed += "('" + Guid.NewGuid().ToString() + "'";
                    if (!string.IsNullOrEmpty(comment.Content))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + comment.Content + "'";
                    }

                        filed += (filed != " values " ? "," : "") + "'" + DateTime.Now + "'";
                        filed += (filed != " values " ? "," : "") + "'" + accountid + "'";
                        filed += (filed != " values " ? "," : "") + "'" + postid + "')";
                    

                    

                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "insert into " + _TABLE_NAME_BLACKLIST;
                string filed = " values ";
                
                    
                filed += "('" + accountid + "'";
                if (!string.IsNullOrEmpty(blacklist.reason))
                {
                    filed += (filed != " values " ? "," : "") + "'" + blacklist.reason + "'";
                }
                filed += (filed != " values " ? "," : "") + "'false'";
                filed += (filed != " values " ? "," : "") + "'" + id + "'";
                filed += (filed != " values " ? "," : "") + "'" + Guid.NewGuid().ToString() + "')";
                    

                
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

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
                string query = "Select a.id, a.content, a.ref_post, a.ref_user, a.create_time, b.FullName, b.avatar  from " + _TABLE_NAME_COMMENT + " a " +
                    "left join " + _TABLE_NAME_ACCOUNT + " b on a.ref_user = b.id ";
                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                CommentDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<CommentDTO> arrRes = new List<CommentDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new CommentDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<CommentDTO> { };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<CommentDTO> GetCommentbyPostID(string id)
        {
            try
            {
                string query = "Select a.id, a.content, a.ref_post, a.ref_user, a.create_time, b.FullName, b.avatar  from " + _TABLE_NAME_COMMENT + " a " +
                    "left join " + _TABLE_NAME_ACCOUNT + " b on a.ref_user = b.id " +
                    "where ref_post = '" + id + "'";

                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";

                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                CommentDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<CommentDTO> arrRes = new List<CommentDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new CommentDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<CommentDTO> { };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GetPlanDTO> GetPlan(List<string> ids)
        {
            try
            {
                string query = "SELECT a.starttime, a.endtime, a.dayinschedule,a.ref_post, a.ref_account, b.title, b.image FROM " + _TABLE_NAME_PLAN + " a " +
                    "left join " + _TABLE_NAME_POST + " b on a.ref_post = b.id ";
                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                GetPlanDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<GetPlanDTO> arrRes = new List<GetPlanDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new GetPlanDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<GetPlanDTO> { };
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
                string query = "SELECT a.starttime, a.endtime, a.dayinschedule,a.ref_post, a.ref_account, b.title, b.image FROM " + _TABLE_NAME_PLAN + " a " +
                    "left join " + _TABLE_NAME_POST + " b on a.ref_post = b.id "+
                    "where a.ref_account = '" + id + "'";
                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                GetPlanDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<GetPlanDTO> arrRes = new List<GetPlanDTO>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new GetPlanDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<GetPlanDTO> { };
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
                if(plan == null)
                    return 0;
                if (plan.starttime == null)
                    plan.starttime = new TimeOnly(0, 0, 0);
                if (plan.endtime == null)
                    plan.endtime = new TimeOnly(0, 0, 0);
                string query = "insert into " + _TABLE_NAME_PLAN;
                string filed = " values ";
                if (plan != null)
                {
                    filed += "('" + Guid.NewGuid().ToString() + "'";
                    filed += (filed != " values " ? "," : "") + "'" + plan.starttime.ToString("HH:mm:ss") + "'";
                    filed += (filed != " values " ? "," : "") + "'" + plan.endtime.ToString("HH:mm:ss") + "'";
                    if (!string.IsNullOrEmpty(plan.dayinschedule))
                    {
                        filed += (filed != " values " ? "," : "") + "'" + plan.dayinschedule + "'";
                    }

                    
                    filed += (filed != " values " ? "," : "") + "'" + accountid + "'";


                    filed += (filed != " values " ? "," : "") + "'" + postid  + "')";

                    



                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CreatePlanAtExistTime(ConfirmAdd plan, string postid, string accountid, string day, string starttime, string endtime)
        {
            try
            {
                string query = "insert into " + _TABLE_NAME_PLAN;
                string filed = " values ";
                if (plan != null)
                {
                    filed += "('" + Guid.NewGuid().ToString() + "'";
                    filed += (filed != " values " ? "," : "") + "'" + starttime + "'";
                    filed += (filed != " values " ? "," : "") + "'" + endtime + "'";
                   filed += (filed != " values " ? "," : "") + "'" + day + "'";
                    filed += (filed != " values " ? "," : "") + "'" + accountid + "'";
                    filed += (filed != " values " ? "," : "") + "'" + postid  + "')";
                }
                if (filed != " values ")
                {
                    query += filed;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeletePostFromPlan (string id)
        {
            try
            {
                string query = "DELETE FROM " + _TABLE_NAME_PLAN + " WHERE id = '" + id + "'";
                return ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public int DeleteNutri (string id)
        {
            try
            {
                string query = "DELETE FROM " + _TABLE_NAME_NUTRI + " WHERE id = '" + id + "'";
                return ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public int DeleteIngre (string id)
        {
            try
            {
                string query = "DELETE FROM " + _TABLE_NAME_INGRE + " WHERE id = '" + id + "'";
                return ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public int DeleteCate (string id)
        {
            try
            {
                string query = "DELETE FROM " + _TABLE_NAME_CATEGORY + " WHERE id = '" + id + "'";
                return ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public int UpdateAccountStatus ()
        {
            try
            {
                string query = "UPDATE " + _TABLE_NAME_ACCOUNT +
                    " SET isActive = CASE " +
                    "WHEN isBan = 1 THEN 0 " +
                    "ELSE 1 " +
                    "END FROM " + _TABLE_NAME_ACCOUNT +
                    " AS a JOIN "+_TABLE_NAME_BLACKLIST+" AS b ON a.id = b.ref_user";
                return ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<GetTimeByDay> GetlistByDay(string id,string day)
        {
            try
            {
                string query = "SELECT starttime,endtime,dayinschedule, STRING_AGG(b.title,',') as title FROM" + _TABLE_NAME_PLAN + " a " +
                    "left join " + _TABLE_NAME_POST + " b on a.ref_post = b.id " +
                    "where a.ref_account = '" + id + "' AND a.dayinschedule = '" + day + "'" +
                    "  group by starttime, endtime, dayinschedule ";
                //if (ids != null && ids.Count > 0)
                //    query += "where a.id in(" + GlobalFuncs.ArrayStringToStringFilter(ids) + ")";
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                GetTimeByDay acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<GetTimeByDay> arrRes = new List<GetTimeByDay>(arrHsObj.Count);
                    for (int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new GetTimeByDay(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<GetTimeByDay> { };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
