using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    class UpdateCloseTimeRegister
    {
        public static void BroadCast(bool message)
        {
            if (OnMessageTransmitted != null)
                OnMessageTransmitted(message);
        }

        public static Action<bool> OnMessageTransmitted;
    }
}
