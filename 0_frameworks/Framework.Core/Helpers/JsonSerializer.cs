using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Framework.Core.Helpers
{
    public static class JsonSerializerHelper
    {
        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static TEntity DesSerialize<TEntity>(string input)
        {
            return JsonSerializer.Deserialize<TEntity>(input);
        }

        public static object DesSerialize(string input , Type returnType )
        {
            return JsonSerializer.Deserialize(input, returnType);
        }
    }
}
