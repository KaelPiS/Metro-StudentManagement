using System;

namespace StudentManagement.ViewModel
{
    public static class Messager
    {
        public static void AnouncementBroadCast(bool isAnouncementOpen, bool isDetailAnouncementOpen, bool isMoreAnouncementOpen)
        {
            if (AnouncementMessageTransmitted != null)
                AnouncementMessageTransmitted(isAnouncementOpen, isDetailAnouncementOpen, isMoreAnouncementOpen);
        }
        public static void AnouncementDetailBroadCast(string value)
        {
            if (AnouncementDetailMessageTransmitted != null)
                AnouncementDetailMessageTransmitted(value);
        }
        public static void CurrentPageBroadCast(string value)
        {
            if (CurrentPageTransmitted != null)
                CurrentPageTransmitted(value);
        }

        public static void PreviousTabBroadCast(bool isAnouncementOpen, bool isDetailAnouncementOpen, bool isMoreAnouncementOpen, string PreviousTab)
        {
            if (PreviousTabTransmitted != null)
                PreviousTabTransmitted(isAnouncementOpen, isDetailAnouncementOpen, isMoreAnouncementOpen, PreviousTab);
        }

        public static void CurrentTabBroadCast(string value)
        {
            if (CurrentTabTransmitted != null)
                CurrentTabTransmitted(value);
        }

        public static void TypeOfAnouncementBroadCast(string value)
        {
            if (TypeOfAnouncementTransmitted != null)
                TypeOfAnouncementTransmitted(value);
        }

        public static void TypeOfMoreAnouncementBroadCast(string value)
        {
            if (TypeOfMoreAnouncementTransmitted != null)
                TypeOfMoreAnouncementTransmitted(value);
        }

        public static Action<bool, bool, bool> AnouncementMessageTransmitted;
        public static Action<string> AnouncementDetailMessageTransmitted;
        public static Action<string> CurrentPageTransmitted;
        public static Action<bool, bool, bool, string> PreviousTabTransmitted;
        public static Action<string> CurrentTabTransmitted;
        public static Action<string> TypeOfAnouncementTransmitted;
        public static Action<string> TypeOfMoreAnouncementTransmitted;
    }
}
