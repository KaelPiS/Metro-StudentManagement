using System;

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
