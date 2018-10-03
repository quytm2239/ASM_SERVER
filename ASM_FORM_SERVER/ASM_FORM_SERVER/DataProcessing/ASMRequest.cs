using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FORM_SERVER.DataProcessing
{
    [Serializable]
    class ASMRequest
    {
        ASMRequest()
        {
            Name = "ASMRequest";
        }
        public string Name { get; set; }
    }
}
