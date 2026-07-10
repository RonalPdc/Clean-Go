using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Go_BusinessLogic.Validator
{
    public interface IValidator <T>
    {
        void Validate (T entidad);
    }
}
