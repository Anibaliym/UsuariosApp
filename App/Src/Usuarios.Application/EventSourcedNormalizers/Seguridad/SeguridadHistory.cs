using Newtonsoft.Json;
using System.Web;
using Usuarios.Domain.Core.Enumerations;
using Usuarios.Domain.Core.Events;

namespace Usuarios.Application.EventSourcedNormalizers.Seguridad
{
    public static class SeguridadHistory
    {
        public static IList<SeguridadHistoryData> HistoryData { get; set; }
        public static IList<SeguridadHistoryData> ToJavaScriptCustomerHistory(IList<History> storedEvents)
        {
            HistoryData = new List<SeguridadHistoryData>();
            ClienteHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<SeguridadHistoryData>();
            var last = new SeguridadHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new SeguridadHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdUsuario = change.IdUsuario == Guid.Empty.ToString() || change.IdUsuario == last.IdUsuario ? "" : change.IdUsuario,
                    Contrasena = string.IsNullOrWhiteSpace(change.Contrasena) || change.Contrasena == last.Contrasena ? "" : change.Contrasena,
                    Intentos = string.IsNullOrWhiteSpace(change.Intentos) || change.Intentos == last.Intentos ? "" : change.Intentos,
                    FechaCreacion = string.IsNullOrWhiteSpace(change.FechaCreacion) || change.FechaCreacion == last.FechaCreacion ? "" : change.FechaCreacion,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdUsuario = HttpUtility.HtmlEncode(jsSlot.IdUsuario);
                jsSlot.Contrasena = HttpUtility.HtmlEncode(jsSlot.Contrasena);
                jsSlot.Intentos = HttpUtility.HtmlEncode(jsSlot.Intentos);
                jsSlot.FechaCreacion = HttpUtility.HtmlEncode(jsSlot.FechaCreacion);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void ClienteHistoryDeserializer(IEnumerable<History> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<SeguridadHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "SeguridadCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "SeguridadModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "SeguridadEliminarEvent":
                        historyData.Action = HistoryDataEnum.REMOVED.Name;
                        historyData.Who = e.User;
                        break;

                    default:
                        historyData.Action = HistoryDataEnum.UNRECOGNIZED.Name;
                        historyData.Who = e.User ?? "Anonymous";
                        break;
                }

                HistoryData.Add(historyData);
            }
        }
    }
}
