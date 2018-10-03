using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FORM_SERVER.DataProcessing
{
    [Serializable]
    class ASMResponse
    {
        ASMResponse()
        {
            Name = "ASMResponse";
        }
        public string Name { get; set; }
    }
}
