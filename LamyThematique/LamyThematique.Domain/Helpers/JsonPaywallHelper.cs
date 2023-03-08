using System;
using Schema.NET;

namespace LamyThematique.Domain.Helpers
{
    public static class JsonPaywallHelper
    {
        public static void GeneratePersonAndOrganization(out Person person, out Organization organization)
        {
            person = new Person()
            {
                Name = "Lamy Liaisons",
                //Email = "XXX",
                Address = new PostalAddress()
                {
                    StreetAddress = "7 Rue Emmy Noether",
                    AddressLocality = "Saint-Ouen-sur-Seine",
                    AddressRegion = "Saint-Ouen-sur-Seine",
                    PostalCode = "93400",
                    AddressCountry = "France"
                }
            };
            organization = new Organization()
            {
                Name = "Lamy Liaisons",
                //Email = "XXX",
                Address = new PostalAddress()
                {
                    StreetAddress = "7 Rue Emmy Noether",
                    AddressLocality = "Saint-Ouen-sur-Seine",
                    AddressRegion = "Saint-Ouen-sur-Seine",
                    PostalCode = "93400",
                    AddressCountry = "France"
                },
                Url = new Uri("https://www.lamy-liaisons.fr/"),
                Logo = new Uri("https://www.lamy-liaisons.fr/wp-content/uploads/2022/09/cropped-Lamy-Liaisons_Negativ-Box.png")
            };
        }
    }
}