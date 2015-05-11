using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romfix.ViewModel.DesignData
{
    public class DictionaryDesignDataAPI : IDictionaryAPI
    {
        public async Task<Translation> TranslateQueryAsync(string query)
        {
            //return new Translation()
            //{
            //    Result = ResultType.Match,
            //    Type = TranslationType.FromHebrew,
            //    CorrectionWords = new List<string> { "take", "make", "wallak" },
            //    Words = new List<Word> { 
            //        new Word() { InputMeaning = "לקחת", PartOfSpeech = "פועל", SampleSentences = new List<string> { "Please <b>take<b> me from here", "Please <b>take<b> me from here" }, Inflections = new List<string> { }, OutputMeanings = new List<string> { "take", "takes", "baby" } },
            //        new Word() { InputMeaning = "לוקחים", PartOfSpeech = "שם פעלה", SampleSentences = new List<string> { "Please <b>take<b> me from here", "Please <b>take<b> me from here" }, Inflections = new List<string> {  }, OutputMeanings = new List<string> { "take", "takes", "baby" } },
            //},
            //};

            return new Translation()
            {
                Result = ResultType.Match,
                Type = TranslationType.FromEnglish,
                Words = new List<Word> { 
                    new Word() { InputMeaning = "take", PartOfSpeech = "verb", SampleSentences = new List<string> { "Please <b>take<b> me from here", "Please <b>take<b> me from here" }, Inflections = new List<string> { "took, takes" }, OutputMeanings = new List<string> { "לקח", "לוקח", "יאללה בויה" } },
                    new Word() { InputMeaning = "takes", PartOfSpeech = "noun", SampleSentences = new List<string> { "Please <b>take<b> me from here", "Please <b>take<b> me from here" }, Inflections = new List<string> { "took, takes" }, OutputMeanings = new List<string> { "לקח", "לוקח", "יאללה בויה" } },
            },
            };
        }
    }
}
