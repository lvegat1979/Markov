using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Renders;
using WordMatrixUtils;

namespace WebAppMarkov.Controllers
{
    [Route("api/[controller]")]
    public class MarkovDataController : Controller
    {

        [HttpGet("[action]")]
        public List<List<Letter>> MarkovResult()
        {
            return GetMatrix();
        }


        /// <summary>
        /// Return JSon with hte list of words
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public List<Word> WordsPuzzle()
        {

            ReadFile fileUtil = new ReadFile();
            var outPut = ReadJSonWords();
            return outPut;
        }

        /// <summary>
        ///Resolve finding a word inside the matrix ang return a List with the ocurrencies 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public List<Letter> WordsPuzzleByWord(string word)
        {
            ResolvePuzzle resolve = new ResolvePuzzle(GetMatrix());
            return resolve.ResolveByLetter(word);
        }
        
        /// <summary>
        ///Read Json file words 
        /// </summary>
        /// <returns></returns>
        private List<Word> ReadJSonWords()
        {
            ReadFile fileUtil = new ReadFile();
            return fileUtil.WordsResolver(Environment.CurrentDirectory + @"\Files\json\words.json");
           
        }

        /// <summary>
        /// Read 3 files (base,values,cyphers) to get output as matrix
        /// </summary>
        /// <returns></returns>
        private List<List<Letter>> GetMatrix()
        {
            ReadFile fileUtil = new ReadFile();
            var outPut = fileUtil.ResolverForJSon(Environment.CurrentDirectory + @"\Files\json\base.json",
                                              Environment.CurrentDirectory + @"\Files\json\values.json",
                                              Environment.CurrentDirectory + @"\Files\json\cypher.json");

            return fileUtil.GetMatrixTextEx(outPut);
        }
    }
}
