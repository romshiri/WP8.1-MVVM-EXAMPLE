using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romfix.Model.DictionaryAPI
{
    public interface IDictionaryAPI
    {
        Task<Translation> TranslateQueryAsync(string query);
    }
}
