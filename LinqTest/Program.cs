using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1())
            {
                List<Creator> creatorsList = context.Creators.ToList();

                List<Creator> resultWithA = new List<Creator>();
                foreach (var creator in creatorsList)
                {
                    if (creator.Name.Contains("а"))
                    {
                        resultWithA.Add(creator);
                    }
                }
            }

            using (var context = new Model1())
            {
                var result = from creator in context.Creators where creator.Name.Contains("a") select creator;

                var anonymResult = from creator in context.Creators where creator.Name.Contains("a") select new { Title = creator.Name, Text = creator.Description, Age = 309 };

                result = context.Creators.Where(creator => creator.Name.Contains("a"));

                var singleResult = context.Creators.Single(creator => creator.Name == "qwer");
                var singleOrDefaultResult = context.Creators.SingleOrDefault(creator => creator.Name == "qwer");
            }
        }
    }
}
