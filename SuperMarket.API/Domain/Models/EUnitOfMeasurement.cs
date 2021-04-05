using System.ComponentModel;

namespace SuperMarket.API.Domain.Models
{
    public enum EUnitOfMeasurement : byte
    {
        [Description("UN")]
        Unity =1,
        [Description("MG")]
        Milligram = 2,
        [Description("GR")]
        Gram = 3,
        [Description("KG")]
        Kilogram = 4,
        [Description("L")]
        Liter = 5
    }
}