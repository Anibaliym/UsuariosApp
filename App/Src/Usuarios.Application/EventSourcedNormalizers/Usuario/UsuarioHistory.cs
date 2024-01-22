using Newtonsoft.Json;
using System.Web;
using Usuarios.Domain.Core.Enumerations;
using Usuarios.Domain.Core.Events;

namespace Usuarios.Application.EventSourcedNormalizers.Usuario
{
    public static class UsuarioHistory
    {
        public static IList<UsuarioHistoryData> HistoryData { get; set; }

        public static IList<UsuarioHistoryData> ToJavaScriptCustomerHistory(IList<History> storedEvents)
        {
            HistoryData = new List<UsuarioHistoryData>();
            ClienteHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<UsuarioHistoryData>();
            var last = new UsuarioHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new UsuarioHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdPersona = change.IdPersona == Guid.Empty.ToString() || change.IdPersona == last.IdPersona ? "" : change.IdPersona,
                    Nick = string.IsNullOrWhiteSpace(change.Nick) || change.Nick == last.Nick ? "" : change.Nick,
                    Tipo = string.IsNullOrWhiteSpace(change.Tipo) || change.Tipo == last.Tipo ? "" : change.Tipo,
                    Estado = string.IsNullOrWhiteSpace(change.Estado) || change.Estado == last.Estado ? "" : change.Estado,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdPersona = HttpUtility.HtmlEncode(jsSlot.IdPersona);
                jsSlot.Nick = HttpUtility.HtmlEncode(jsSlot.Nick);
                jsSlot.Tipo = HttpUtility.HtmlEncode(jsSlot.Tipo);
                jsSlot.Estado = HttpUtility.HtmlEncode(jsSlot.Estado);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void ClienteHistoryDeserializer(IEnumerable<History> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<UsuarioHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "UsuarioCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "UsuarioModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "UsuarioEliminarEvent":
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
