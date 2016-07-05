namespace FurnitureManufacturer
{
    using Engine;

    public class FurnitureProgram
    {
        public static void Main()
        {
            var engine = FurnitureManufacturerEngine.Instance;

            engine.Start();
        }
    }
}
