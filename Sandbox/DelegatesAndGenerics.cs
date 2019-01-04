using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class NumberWang
    {
        private int SquareInt32(int x)
        {
            return x * x;
        }

        //DELEGATE
        private Converter<int, double> _converter = delegate (int x)
         {
             return Math.Sqrt(x);
         };

        //LAMBDA
        private Converter<int, double> _converterLambda = x => Math.Sqrt(x);

        public IList<int> SquareList(IList<int> list)
        {
            list = (list as List<int>).ConvertAll(SquareInt32);

            return list;
        }

        public IList<double> SquareRootList(IList<int> list)
        {
            var returnValue = (list as List<int>).ConvertAll(_converter);

            //OR

            returnValue = (list as List<int>).ConvertAll(delegate (int x)
            {
                return Math.Sqrt(x);
            });

            return returnValue;
        }
    }
}