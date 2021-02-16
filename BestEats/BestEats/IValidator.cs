using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestEats
{
    interface IValidator<T> 
    {
        bool ValidateName(T t);
        bool ValidatePass(T t);

    }
}
