using Newtonsoft.Json.Linq;
using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Romfix.Model.Utilities;

namespace Romfix.Model.MorfixAPI
{
    public class MorfixJsonParser : IJsonParser
    {
        public Translation ParseJsonResponse(string jsonResponse)
        {
            JObject queryResult = JObject.Parse(jsonResponse);
            Translation translation = new Translation();

            translation.Result = queryResult["ResultType"].ToString().ToEnum<ResultType>();
            translation.Type = queryResult["TranslationType"].ToString() == "ToEnglish" ? TranslationType.FromHebrew : TranslationType.FromEnglish;

            if (translation.Result == ResultType.Match)
            {
                List<JToken> words = queryResult["Words"].Children().ToList();

                foreach (var word in words)
                {
                    translation.Words.Add(new Word
                    {
                        InputMeaning = word["InputLanguageMeanings"].ToList()[0].ToList()[0]["DisplayText"].ToString(),
                        OutputMeanings = GetOutputMeanings(word["OutputLanguageMeanings"]),
                        Inflections = GetInflections(word["Inflections"]),
                        PartOfSpeech = word["PartOfSpeech"].ToString(),
                        SampleSentences = (from sentence in word["SampleSentences"].ToList()
                                           select sentence.ToString()).ToList()
                    });
                }
            }
            else if (translation.Result == ResultType.Suggestions)
            {
                List<JToken> suggestions = queryResult["CorrectionList"].Children().ToList();

                foreach (var suggestion in suggestions)
                {
                    translation.CorrectionWords.Add(suggestion["Word"].ToString());
                }
            }

            return translation;
        }

        private List<string> GetOutputMeanings(JToken outputLanguageMeanings)
        {
            List<string> result = new List<string>();

            foreach (var output in outputLanguageMeanings)
            {
                result.Add(output.ToList()[0]["DisplayText"].ToString());
            }

            return result;
        }

        private List<string> GetInflections(JToken inflections)
        {
            List<string> result = new List<string>();

            foreach (var inflection in inflections)
            {
                result.Add(inflection["Text"].ToString());
            }

            return result;
        }

    }
}
