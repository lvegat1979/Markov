using Newtonsoft.Json;
using Renders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WordMatrixUtils
{
    /// <summary>
    /// Read File sending by the user.
    /// Author: Luis Vega
    /// </summary>
    public class ReadFile
    {
        /// <summary>
        /// Method to get the file file and resolve it.
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="valuesPath"></param>
        /// <param name="cyperPath"></param>
        public List<string> ResolverForJSon(string basePath, string valuesPath, string cyperPath)
        {
            List<Base> bases;
            ListValue values = new ListValue();
            List<string> cyphers;
            try
            {
                //Contains a list (size M) with the base rules that will be used in Markov's algorithm
                bases = JsonConvert.DeserializeObject<List<Base>>(Resolver(basePath));

                //Contains a list of objects (size N)
                values.Values = JsonConvert.DeserializeObject<List<List<WValue>>>(Resolver(valuesPath));

                //Gets the ordered values
                var orderValues = values.GetOrderListDesc();

                //Process cyper from JSon
                cyphers = JsonConvert.DeserializeObject<List<string>>(Resolver(cyperPath));

                MarkovUitl markov = new MarkovUitl();

                return markov.ApplyRules(bases, orderValues, cyphers);
            }
            catch (Exception ex)
            {

                throw new Exception("Cannot process the files" + ex.Message);
            }
        }

        /// <summary>
        /// Return  words resolved
        /// </summary>
        /// <param name="wordPath"></param>
        /// <returns></returns>
        public List<Word> WordsResolver(string wordPath)
        {
            var output =  JsonConvert.DeserializeObject<List<string>>(Resolver(wordPath));
            List<Word> result = new List<Word>();
            var index = 0;
            foreach (var item in output)
            {
                result.Add(new Word(item, item + "_" + index));
                index++;
            }

            return result;
        }

        /// <summary>
        /// Return file content
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string Resolver(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
        /// <summary> 
        /// Get the information as Matrix
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string[,] GetMatrixText(List<string> list)
        {

            string[,] matrix = new string[list.Count, list[0].Length];
            for (int i = 0; i < list.Count; i++)
            {
                for (int n = 0; n < list[i].Length; n++)
                {
                    matrix[i, n] = list[i].Substring(n, 1);
                }
            }

            return matrix;
        }

        /// <summary>
        ///Get the resolved Markov as Matrix result 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<List<Letter>> GetMatrixTextEx(List<string> list)
        {
            try
            {
                List<List<Letter>> matrix = new List<List<Letter>>();
                List<Letter> characters = new List<Letter>();

                for (int i = 0; i < list.Count; i++)
                {
                    characters = new List<Letter>();
                    for (int n = 0; n < list[i].Length; n++)
                    {
                        characters.Add(new Letter(i, n, list[i].Substring(n, 1)));
                    }
                    matrix.Add(characters);
                }
                return matrix;
            }
            catch (Exception ex)
            {
                throw new Exception("Something wrong generating the matrix" + ex.Message);
            }
        }

    }
}


