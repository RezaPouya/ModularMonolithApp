using Framework.Core.CacheService;
using Framework.Core.CacheService.DtoModels;
using Framework.Core.Exceptions;
using Framework.Core.Extensions;
using gFramework.Web.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace gFramework.Web.Cache
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiOutputDataCacheAttribute : ActionFilterAttribute
    {
        private readonly int _expireTimeMinute;
        private readonly string _key;
        private readonly string _dbKey;
        private readonly bool _isAnonymous;
        private readonly Type _outType;
        private ICacheService _cacheService;

        /// <summary>
        ///  برای کش کردن دیتا خروجی ای پی آی ها
        /// ای پی آی های پّست که ورودی سنگین دارند کش نشوند
        /// </summary>
        /// <param name="expireTimeMinute">مدت زمان معتر بودن دیتا در کش</param>
        /// <param name="businessKey">کلیدی برای جدا سازی نوع داده در ذخیره سازی دیتا ، مثلا برای کش کردن Api های جاب پست از کلید JobPost استفاده شود.</param>
        /// <param name="outType">جنس کلاس خروجی ای پی آی ، مانند typeof(List<EmployeeDetailDto>)</param>
        /// <param name="key">در صورتی که میخواهید کلید اصلی مربوط به ذخیره سازی را دستی وارد کنید</param>
        /// <param name="isAnonymous">اگر جنس خروجی برای یوزر های مختلف متفاوت است میتوان از این مورد برای کش کردن استفاده کرد</param>
        /// [CacheData(60, "ApplicationManagment", typeof(ApplicationInDetailDto))]
        public ApiOutputDataCacheAttribute(int expireTimeMinute, string businessKey, Type outType, string key = "", bool isAnonymous = true)
        {
            _expireTimeMinute = expireTimeMinute;
            _key = key;
            _dbKey = businessKey;
            _isAnonymous = isAnonymous;
            _outType = outType;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _cacheService = context.HttpContext.RequestServices.GetService<ICacheService>();

            var request = context.HttpContext.Request;

            var key = string.IsNullOrEmpty(_key) ? await GenerateKey(request) : _key;

            if (!_isAnonymous)
            {
                var userId = context.HttpContext.User.Identity.GetUserId();

                if (!string.IsNullOrEmpty(userId))
                    key = userId + "-" + key;
            }

            var (exist, data) = await _cacheService.TryGetValue<string>(new CacheKeyDto() { DbKey = _dbKey, Key = key });
            if (exist)
            {
                var response = JsonConvert.DeserializeObject(data, _outType);
                var apiResult = new ApiResult<object>(true, ApiResultStatusCode.Success, response);
                context.Result = new JsonResult(apiResult) { StatusCode = 200 };
                return;
            }

            var executedContext = await next();

            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                await _cacheService.Add(new CacheItemDto<object>()
                {
                    Key = key,
                    DbKey = _dbKey,
                    Data = okObjectResult.Value,
                    ExpireTime = DateTime.Now.AddMinutes(_expireTimeMinute)
                });
            }
        }

        private async Task<string> GenerateKey(HttpRequest request)
        {
            string key = "";
            if (request.Method == "POST")
            {
                string requestBody;
                request.Body.Position = 0;

                using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                key = request.Path.ToString() + "-" + requestBody;
            }
            else if (request.Method == "GET")
            {
                key = request.Path + request.QueryString;
            }

            return key;
        }
    }
}