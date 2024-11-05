using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurneroApp.MVVM.Models.ModelsDTO
{
    public class ResponseWrapper<T>
    {
        [JsonPropertyName("$values")]
        public List<T> Values { get; set; }
    }
}