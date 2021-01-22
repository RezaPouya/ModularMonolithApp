using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Framework.Core.Helpers
{
    public class JsonSerializerHelper
    {
        public string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public TEntity DesSerialize<TEntity>(string input)
        {
            return JsonSerializer.Deserialize<TEntity>(input);
        }
    }
}
