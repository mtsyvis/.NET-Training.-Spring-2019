using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    public class TransformStringToNumber : ITransform<int, string>
    {
        private int numeralSystem;

        public TransformStringToNumber(int numeralSystem)
        {
            if (numeralSystem < 2 || numeralSystem > 16)
            {
                throw new ArgumentNullException($"wrong numeral system{nameof(numeralSystem)}");
            }

            this.numeralSystem = numeralSystem;
        }

        public int Transform(string source)
        {
            return 0;
        }
    }
}
