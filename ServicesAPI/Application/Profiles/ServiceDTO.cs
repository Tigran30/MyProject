namespace ServicesAPI.Application.Profiles
{
    public class ServiceDTO
    {
        public ServiceDTO(int id, string serviceName, int serviceCost)
        {
            Id = id;
            ServiceName = serviceName;
            ServiceCost = serviceCost;
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public int ServiceCost { get; set; }
    }
}
