using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    internal class ClientConverter
    {
        public Models.Client Convert(Entities.Client client)
        {
            return new Models.Client
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                Surname = client.Surname
            };
        }

        public IEnumerable<Models.Client> Convert(IEnumerable<Entities.Client> clients)
        {
            return clients.Select(x => Convert(x));
        }
    }
}
