namespace ProjectAutoService.Entities
{
    public class ServiceOrder
    {
        public int Id { get; private set; }
        public int ServiceWorkId { get; private set; }
        public int MechanicId { get; private set; }
        public int SparePartId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int WorkVolume { get; private set; }

        public static ServiceOrder CreateOperation(int id, int serviceWorkId, int mechanicId, int sparePartId, int workVolume)
        {
            return new ServiceOrder
            {
                Id = id,
                ServiceWorkId = serviceWorkId,
                MechanicId = mechanicId,
                SparePartId = sparePartId,
                OrderDate = DateTime.Now,
                WorkVolume = workVolume
            };
        }
    }
}