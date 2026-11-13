namespace ProjectAutoService.Entities
{
    public class SparePartPartUsage
    {
        public int Id { get; private set; }
        public int SparePartId { get; private set; }
        public int Count { get; private set; }

        public static SparePartPartUsage CreateElement(int id, int sparePartId, int count)
        {
            return new SparePartPartUsage
            {
                Id = id,
                SparePartId = sparePartId,
                Count = count
            };
        }
    }
}