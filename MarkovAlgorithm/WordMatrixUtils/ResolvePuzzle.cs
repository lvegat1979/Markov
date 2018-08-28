using Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordMatrixUtils
{
    /// <summary>
    /// Class to resolved  the puzzle
    /// Author: Luis Vega
    /// </summary>
    public class ResolvePuzzle
    {


        /// <summary>
        /// Rule how to it should be move
        ///  //Row = X, Column = Y
        ///   N	 -1	 0
        ///   S	  1	 0
        ///   E	  0	 1
        ///   O	  0	-1
        ///   NO -1	-1
        ///   NE -1	 1
        ///   SO  1	-1
        ///   SE  1	 1
        /// </summary>
        private int[,] xy = new int[,] { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        List<Letter> aux = new List<Letter>(); //
        List<List<Letter>> Source { get; set; }
        bool FoundFirtsLetter { get; set; }

        bool FindAnotherSite { get; set; }

        public Letter LastLetterNode { get; set; }
        public ResolvePuzzle (List<List<Letter>> source)
        {
            this.Source = source;
            this.aux = new List<Letter>();
            this.FoundFirtsLetter = false;
            this.LastLetterNode = new Letter();
        }
        /// <summary>
        /// Read each character of the word this method is recursive. 
        /// </summary>
        /// <param name="word">represent a one character</param>
        /// <param name="rStar">row should star</param>
        /// <param name="cStar">column should star</param>
        /// <returns></returns>
        public List<Letter> ResolveByLetter(string word,int rStar = 0, int cStar = 0)
        {

            for (int i = 0; i < word.Length; i++)//Letter
            {
                var found = Resolve(word.Substring(i, 1),rStar,cStar);
                if (found)
                    continue;
                else
                {
                    Console.WriteLine("no found");
                    int row = 0;
                    int column = 0;

                    if (aux.Count > 0)
                    {
                        row = aux[aux.Count - 1].Row;

                        if (this.Source[0].Count - 1 == aux[aux.Count - 1].Column)
                            column = 0;
                        else
                            column = aux[aux.Count - 1].Column + 1;
                    }


                    if (!this.FindAnotherSite)
                    {
                        if (aux.Count > 0)
                        {
                            row = aux[0].Row;

                            if (this.Source[0].Count - 1 == aux[0].Column)
                                column = 0;
                            else
                                column = aux[0].Column + 1;
                        }

                        this.aux.Clear();//Clearing all data in Auxiliar
                        this.FoundFirtsLetter = false;
                    }

                    ResolveByLetter(word,row, column);
                    return this.aux;
                    //Execute again firt ocurrencie from the las position
                }
           }
            return this.aux;
        }
        

        /// <summary>
        ///Find letter 
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="rStar"></param>
        /// <param name="cStar"></param>
        /// <returns></returns>
        private bool Resolve(string letter, int rStar = 0, int cStar = 0)
        {

            
             if (!this.FoundFirtsLetter) {
                for (int r = rStar; r < this.Source.Count; r++)//Moving Row
                {
                    for (int c = cStar; c < this.Source[r].Count; c++)//Moving Column
                    {
                        if (this.Source[r].Count() - 1 == c)//Restar column to find star of 0
                            cStar = 0;

                        if (letter == this.Source[r][c].Character && !this.FoundFirtsLetter) // if the first letter found
                        {
                            aux.Add(new Letter(r, c, this.Source[r][c].Character));
                            this.FoundFirtsLetter = true;
                            return true;
                        }
                    }
                }
            }
             else
            {
                var rowDir = 0;
                var colDir = 0;
                if (this.aux.Count > 0)
                {
                    rowDir = this.aux[this.aux.Count-1].Row;
                    colDir = this.aux[this.aux.Count -1].Column;
                }

                this.FindAnotherSite = EvaluateDirecctions(rowDir, colDir, letter); //review in all sites.
                return FindAnotherSite;
            }

            return false;
        }


        /// <summary>
        /// Directions       
        ///   N	 -1	 0
        ///   S	  1	 0
        ///   E	  0	 1
        ///   O	  0	-1
        ///   NO -1	-1
        ///   NE -1	 1
        ///   SO  1	-1
        ///   SE  1	 1
        /// </summary>
        /// <param name="actualRow"></param>
        /// <param name="actualColumn"></param>
        /// <param name="wordToFind"></param>
        /// <returns></returns>
        private bool EvaluateDirecctions(int actualRow, int actualColumn, string wordToFind)
        {
            //Asumming that it has the same amout of columns in all rows
            for (int i = 0; i < xy.GetLength(0); i++)
            {
                var x = xy[i, 0];
                var y = xy[i, 1];

                try
                {
                    var chr = this.Source[actualRow-y][actualColumn -x];
                    if (chr.Character == wordToFind)
                    {
                        this.aux.Add(chr);
                        this.LastLetterNode = chr;
                        return true;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return false;

        }

    }
}
