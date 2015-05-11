using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romfix.Model.DictionaryAPI
{
    public class Translation
    {
        public Translation()
        {
            Words = new List<Word>();
            CorrectionWords = new List<string>();
            Result = ResultType.NoResult;
        }

        public ResultType Result { get; set; }
        public TranslationType Type { get; set; }
        public List<Word> Words { get; set; }
        public List<string> CorrectionWords { get; set; }

    }

    public class Word
    {
        public string InputMeaning { get; set; }
        public List<string> OutputMeanings { get; set; }
        public List<string> Inflections { get; set; }
        public string PartOfSpeech { get; set; }
        public List<string> SampleSentences { get; set; }
    }


    public enum TranslationType
    {
        FromHebrew, FromEnglish
    }

    public enum ResultType
    {
        Match, Suggestions, NoResult
    }


}
