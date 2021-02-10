using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace VemDeZap.Domain.Commands
{
    public class Response
    {
        public IEnumerable<Notification> Notifications { get; set; }        

        public bool Success { get; private set; }

        public object Data { get; private set; }


        public Response(INotifiable notifiable)
        {
            this.Success = notifiable.IsValid();

            this.Notifications = notifiable.Notifications;
        }

        public Response(INotifiable notifiable, object data)
        {
            this.Notifications = notifiable.Notifications;
            this.Success = notifiable.IsValid();
            this.Data = data;
        }
    }
}
