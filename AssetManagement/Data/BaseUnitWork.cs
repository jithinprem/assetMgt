namespace AssetManagement.Data
{
    public class BaseUnitWork : IUnitwork
    {

        private readonly SeatManagementDbContext _repository;

        public BaseUnitWork(SeatManagementDbContext repository)
        {
            _repository = repository;
        }
        public void Commit()
        {
            _repository.SaveChanges();
        }


    }
}
