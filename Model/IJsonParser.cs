using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romfix.Model
{
    public interface IJsonParser
    {
        Translation ParseJsonResponse(string jsonResponse);
    }
}
