using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Member API 項目
    /// </summary>
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        Models.Member[] Member = new Models.Member[] {
            new Models.Member { Name="peter", Id="a000000000", Age=30, Email="peter@gmail.com" },
            new Models.Member { Name="justin", Id="a11111111", Age=28, Email="justin@gmail.com" },
            new Models.Member { Name="terry", Id="a222222222", Age=32, Email="terry@gmail.com" }
        };

        /// <summary>
        /// 取得所有成員資料
        /// </summary>
        /// <returns></returns>
        [Route("GetAllMember")]
        public IEnumerable<Models.Member> GetAllMember()
        {
            return Member;
        }

        /// <summary>
        /// 取得特定名稱成員資料
        /// </summary>
        /// <param name="id">成員ID</param>
        /// <returns></returns>
        [Route("GetMember")]
        [Route("GetMember/{id}")]
        public IHttpActionResult GetMember(string id)
        {
            var result = Member.FirstOrDefault(x => x.Id == id);
            if (result == null)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return Ok(result);
        }

        /// <summary>
        /// 取得特定名稱成員資料
        /// </summary>
        /// <param name="PostData">{ "Name": "justin", "Id": "a11111111", "Age": 28, "Email": "justin@gmail.com"}</param>
        /// <returns></returns>
        [Route("GetMember")]
        [HttpPost]
        public IHttpActionResult GetMember(JObject PostData)
        {
            var result = Member.FirstOrDefault(x => x.Name == PostData["Name"].ToString());
            if (result == null)
                return StatusCode(HttpStatusCode.NoContent);
            else
                return Ok(result);
        }
    }
}
