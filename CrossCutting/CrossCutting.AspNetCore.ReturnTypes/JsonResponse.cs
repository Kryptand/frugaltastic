using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrossCutting.AspNetCore.ReturnTypes
{
    public class JsonResponse : JsonResult
    {
        public JsonResponse(object value, JsonSerializerSettings serializerSettings) : base(value, serializerSettings)
        {
        }
    }
}
