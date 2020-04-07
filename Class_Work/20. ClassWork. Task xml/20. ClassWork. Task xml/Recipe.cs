using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.ClassWork.Task_xml
{
    class Recipe
    {
        public string Title { get; set; }
        public string[] Ingredients;
        public string Preparati { get; set; }
        public int Serving { get; set; }
        public int[] Energy{ get; set; }

        

        public static List<Recipe> GetRecipe()
        {
            List<Recipe> recipes = new List<Recipe>();


            Recipe recipe1 = new Recipe()
            {
                Title = "Potato",
                Ingredients = new string[3] { "1", "2", "3" },
                Preparati = "gsfdig sdv feiwpouj cvfpgosd v",
                Serving = 2,
                Energy = new int[3] { 5, 5, 5 }
            };
            Recipe recipe2 = new Recipe()
            {
                Title = "Carot",
                Ingredients = new string[3] { "3", "3", "3" },
                Preparati = "gfrsde;igj; [;iopuwevg [ijvx s;",
                Serving = 5,
                Energy = new int[3] { 1, 1, 1 }
            };



            recipes.Add(recipe1);
            recipes.Add(recipe2);


            return recipes;
        }

    }
}
