using System.Diagnostics;

namespace SignalRTracing.Web
{
    public static class ChatActivity
    {
        public static readonly ActivitySource ActivitySource = new("ChatClient");
    }
}
